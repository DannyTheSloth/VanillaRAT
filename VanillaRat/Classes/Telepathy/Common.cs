using System;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Threading;

namespace Telepathy
{
    public abstract class Common
    {
        public static int messageQueueSizeWarning = 100000;

        public int MaxMessageSize = 2147483647;

        public bool NoDelay = true;
        protected ConcurrentQueue<Message> receiveQueue = new ConcurrentQueue<Message>();

        public int SendTimeout = 5000;

        public int ReceiveQueueCount => receiveQueue.Count;

        public bool GetNextMessage(out Message message)
        {
            return receiveQueue.TryDequeue(out message);
        }

        protected static bool SendMessagesBlocking(NetworkStream stream, byte[][] messages)
        {
            try
            {
                int packetSize = 0;
                for (int i = 0; i < messages.Length; ++i)
                    packetSize += sizeof(int) + messages[i].Length;

                byte[] payload = new byte[packetSize];
                int position = 0;
                for (int i = 0; i < messages.Length; ++i)
                {
                    byte[] header = Utils.IntToBytesBigEndian(messages[i].Length);

                    Array.Copy(header, 0, payload, position, header.Length);
                    Array.Copy(messages[i], 0, payload, position + header.Length, messages[i].Length);
                    position += header.Length + messages[i].Length;
                }

                stream.Write(payload, 0, payload.Length);

                return true;
            }
            catch (Exception exception)
            {
                Logger.Log("Send: stream.Write exception: " + exception);
                return false;
            }
        }

        protected static bool ReadMessageBlocking(NetworkStream stream, int MaxMessageSize, out byte[] content)
        {
            content = null;

            byte[] header = new byte[4];
            if (!stream.ReadExactly(header, 4))
                return false;

            int size = Utils.BytesToIntBigEndian(header);

            if (size <= MaxMessageSize)
            {
                content = new byte[size];
                return stream.ReadExactly(content, size);
            }

            Logger.LogWarning("ReadMessageBlocking: possible allocation attack with a header of: " + size + " bytes.");
            return false;
        }

        protected static void ReceiveLoop(int connectionId, TcpClient client, ConcurrentQueue<Message> receiveQueue,
            int MaxMessageSize)
        {
            NetworkStream stream = client.GetStream();

            DateTime messageQueueLastWarning = DateTime.Now;

            try
            {
                receiveQueue.Enqueue(new Message(connectionId, EventType.Connected, null));

                while (true)
                {
                    byte[] content;
                    if (!ReadMessageBlocking(stream, MaxMessageSize, out content))
                        break;

                    receiveQueue.Enqueue(new Message(connectionId, EventType.Data, content));

                    if (receiveQueue.Count > messageQueueSizeWarning)
                    {
                        TimeSpan elapsed = DateTime.Now - messageQueueLastWarning;
                        if (elapsed.TotalSeconds > 10)
                        {
                            Logger.LogWarning("ReceiveLoop: messageQueue is getting big(" + receiveQueue.Count +
                                              "), try calling GetNextMessage more often. You can call it more than once per frame!");
                            messageQueueLastWarning = DateTime.Now;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.Log("ReceiveLoop: finished receive function for connectionId=" + connectionId + " reason: " +
                           exception);
            }

            stream.Close();
            client.Close();

            receiveQueue.Enqueue(new Message(connectionId, EventType.Disconnected, null));
        }

        protected static void SendLoop(int connectionId, TcpClient client, SafeQueue<byte[]> sendQueue,
            ManualResetEvent sendPending)
        {
            NetworkStream stream = client.GetStream();

            try
            {
                while (client.Connected)
                {
                    sendPending.Reset();

                    byte[][] messages;
                    if (sendQueue.TryDequeueAll(out messages))
                        if (!SendMessagesBlocking(stream, messages))
                            return;

                    sendPending.WaitOne();
                }
            }
            catch (ThreadAbortException) { }
            catch (ThreadInterruptedException) { }
            catch (Exception exception)
            {
                Logger.Log("SendLoop Exception: connectionId=" + connectionId + " reason: " + exception);
            }
        }
    }
}