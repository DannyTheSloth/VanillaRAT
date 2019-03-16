using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanillaRat.Forms
{
    public partial class ClientRunningApps : Form
    {
        public ClientRunningApps()
        {
            InitializeComponent();
        }
        public int ConnectionID { get; set; }

        private void btnRefreshProcesses_Click(object sender, EventArgs e)
        {
            Classes.Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("GetProcesses"));
        }

        private void btnEndProcess_Click(object sender, EventArgs e)
        {
            if (lbRunningProcesses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a process!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ListViewItem Item = lbRunningProcesses.SelectedItems[0];
            Classes.Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("EndProcess(" + Item.SubItems[1].Text + ")"));
            Item.Remove();
            Classes.Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("GetProcesses"));
        }
    }
}
