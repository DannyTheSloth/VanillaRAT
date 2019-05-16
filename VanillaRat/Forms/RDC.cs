using System;
using System.Text;

using System.Windows.Forms;
using VanillaRat.Classes;

namespace VanillaRat.Forms
{
    public partial class RDC : Form
    {
        public RDC()
        {
            InitializeComponent();
            Update = true;
        }

        public int ConnectionID { get; set; }
        public bool Update { get; set; }

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
    }
}