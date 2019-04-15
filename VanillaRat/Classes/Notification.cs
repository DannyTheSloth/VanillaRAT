using System;
using System.Threading;
using System.Windows.Forms;

namespace VanillaRat.Classes
{
    public class Notification : Form
    {
        //Override form load to place lower right
        protected override void OnLoad(EventArgs e)
        {
            PlaceLowerRight();
            base.OnLoad(e);
        }

        //Override form close to fade out
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!e.Cancel)
                for (int op = 99; op >= 0; op -= 3)
                {
                    Opacity = op / 100f;
                    Thread.Sleep(15);
                }
        }

        //Place form lower right of screen
        private void PlaceLowerRight()
        {
            Screen rightmost = Screen.AllScreens[0];
            foreach (Screen screen in Screen.AllScreens)
                if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                    rightmost = screen;
            Left = rightmost.WorkingArea.Right - Width;
            Top = rightmost.WorkingArea.Bottom - Height;
        }
    }
}