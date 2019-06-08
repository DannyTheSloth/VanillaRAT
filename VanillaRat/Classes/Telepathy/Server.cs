using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Telepathy
{
    public class Server : Common
    {
        private static int counter;

        private readonly ConcurrentDictionary<int, ClientToken> clients = new ConcurrentDictionary<int, ClientToken>();
        public TcpListener listener;
        private Thread listenerThread;

        public bool Active => listenerThread != null && listenerThread.IsAlive;

        public static int NextConnectionId()
        {
            int id = Interlocked.Increment(ref counter);
            if (id == int.MaxValue) throw new Exception("connection id limit reached: " + id);

            return id;
        }

        private void Listen(int port)
        {
            try
            {
                listener = new TcpListener(new IPEndPoint(IPAddress.Any, port));
                listener.Server.NoDelay = NoDelay;
                listener.Server.SendTimeout = SendTimeout;
                listener.Start();
                Logger.Log("Server: listening port=" + port);

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();

                    int connectionId = NextConnectionId();

                    ClientToken token = new ClientToken(client);
                    clients[connectionId] = token;

                    Thread sendThread = new Thread(() =>
                    {
                        try
                        {
                            SendLoop(connectionId, client, token.sendQueue, token.sendPending);
                        }
                        catch (ThreadAbortException) { }
                        catch (Exception exception)
                        {
                            Logger.LogError("Server send thread exception: " + exception);
                        }
                    });
                    sendThread.IsBackground = true;
                    sendThread.Start();

                    Thread receiveThread = new Thread(() =>
                    {
                        try
                        {
                            ReceiveLoop(connectionId, client, receiveQueue, MaxMessageSize);

                            clients.TryRemove(connectionId, out ClientToken _);

                            sendThread.Interrupt();
                        }
                        catch (Exception exception)
                        {
                            Logger.LogError("Server client thread exception: " + exception);
                        }
                    });
                    receiveThread.IsBackground = true;
                    receiveThread.Start();
                }
            }
            catch (ThreadAbortException exception)
            {
                Logger.Log("Server thread aborted. That's okay. " + exception);
            }
            catch (SocketException exception)
            {
                Logger.Log("Server Thread stopped. That's okay. " + exception);
            }
            catch (Exception exception)
            {
                Logger.LogError("Server Exception: " + exception);
            }
        }

        public bool Start(int port)
        {
            if (Active) return false;

            receiveQueue = new ConcurrentQueue<Message>();

            Logger.Log("Server: Start port=" + port);
            listenerThread = new Thread(() => { Listen(port); });
            listenerThread.IsBackground = true;
            listenerThread.Priority = ThreadPriority.BelowNormal;
            listenerThread.Start();
            return true;
        }

        public void Stop()
        {
            if (!Active) return;

            Logger.Log("Server: stopping...");

            listener?.Stop();

            listenerThread?.Interrupt();
            listenerThread = null;

            foreach (KeyValuePair<int, ClientToken> kvp in clients)
            {
                TcpClient client = kvp.Value.client;
                try
                {
                    client.GetStream().Close();
                }
                catch { }

                client.Close();
            }

            clients.Clear();
        }

        public bool Send(int connectionId, byte[] data)
        {
            if (data.Length <= MaxMessageSize)
            {
                ClientToken token;
                if (clients.TryGetValue(connectionId, out token))
                {
                    token.sendQueue.Enqueue(data);
                    token.sendPending.Set();
                    return true;
                }

                Logger.Log("Server.Send: invalid connectionId: " + connectionId);
                return false;
            }

            Logger.LogError("Client.Send: message too big: " + data.Length + ". Limit: " + MaxMessageSize);
            return false;
        }

        public string GetClientAddress(int connectionId)
        {
            ClientToken token;
            if (clients.TryGetValue(connectionId, out token))
                return ((IPEndPoint) token.client.Client.RemoteEndPoint).Address.ToString();
            return "";
        }

        public bool Disconnect(int connectionId)
        {
            ClientToken token;
            if (clients.TryGetValue(connectionId, out token))
            {
                token.client.Close();
                Logger.Log("Server.Disconnect connectionId:" + connectionId);
                return true;
            }

            return false;
        }

        private class ClientToken
        {
            public readonly TcpClient client;
            public readonly ManualResetEvent sendPending = new ManualResetEvent(false);
            public readonly SafeQueue<byte[]> sendQueue = new SafeQueue<byte[]>();

            public ClientToken(TcpClient client)
            {
                this.client = client;
            }
        }
    }
}