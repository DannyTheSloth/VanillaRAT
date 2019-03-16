using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VanillaRat.Classes;

namespace VanillaRat.Forms
{
    public partial class BuilderForm : Form
    {
        public BuilderForm()
        {
            InitializeComponent();
        }
        private void btnBuild_Click(object sender, EventArgs e)
        {
            if (txtDNS.Text == null || txtPort.Text == null || txtName.Text == null || txtClientTag.Text == null || txtInterval.Text == null) 
            {
                MessageBox.Show("Error: One or more text fields is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Builder ClientBuilder = new Builder();
            try
            {
                Convert.ToInt16(txtPort.Text);
                Convert.ToInt16(txtInterval.Text);
            } catch (Exception EX)
            {
                MessageBox.Show("Error: " + EX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;                   
            }
            ClientBuilder.BuildClient(txtPort.Text, txtDNS.Text, txtName.Text, txtClientTag.Text, txtInterval.Text);
            Process.Start("explorer.exe", Environment.CurrentDirectory + @"\Clients\");
            Hide();
        }
    }
}
