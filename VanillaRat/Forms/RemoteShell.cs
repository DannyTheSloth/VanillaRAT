using System;
using System.Text;
using System.Windows.Forms;
using VanillaRat.Classes;

namespace VanillaRat.Forms
{
    public partial class RemoteShell : Form
    {
        private bool Powershell;
        private bool Restart;

        public RemoteShell()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            Update = true;
        }

        public int ConnectionID { get; set; }
        public bool Update { get; set; }

        //On form close
        private void RemoteShell_FormClosing(object sender, FormClosingEventArgs e)
        {
            Update = false;
            Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("StopRS"));
        }

        //Send command by button
        private void btnSendCommand_Click(object sender, EventArgs e)
        {
            Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("[<COMMAND>]" + txtCommand.Text));
        }

        //Send command by enter key
        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("[<COMMAND>]" + txtCommand.Text));
        }

        //Toggle between Powershell and CMD 
        private async void btnToggleMode_Click(object sender, EventArgs e)
        {
            if (!Powershell)
            {
                Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("[<COMMAND>]powershell"));
                Powershell = true;
                btnToggleMode.Text = "Switch to CMD";
            }
            else
            {
                Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("[<COMMAND>]cmd"));
                Powershell = false;
                btnToggleMode.Text = "Switch to Powershell";
            }
        }

        //In case of issues, restart shell
        private void btnRestartShell_Click(object sender, EventArgs e)
        {
            Restart = true;
            Close();
        }

        //On close, check for restart
        private void RemoteShell_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Restart)
            {
                Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("StartRS"));
                Restart = false;
            }
        }
    }
}