using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace VanillaRat.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (File.Exists("Settings.txt"))
            {
                File.Delete("Settings.txt");
            }
            try
            {
                Convert.ToInt16(txtPort.Text);
                Convert.ToInt16(txtUpdateInterval.Text);
            } catch (Exception EX)
            {
                MessageBox.Show("Error: " + EX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Hide();
                return;
            }
            using (StreamWriter SR = new StreamWriter("Settings.txt"))
            {
                SR.WriteLine("(" + txtPort.Text + ")<" + txtUpdateInterval.Text + ">");
                SR.Flush();
                SR.Close();
            }
            Hide();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Classes.Settings.Values Settings;
            txtPort.Text = Settings.GetPort().ToString();
            txtUpdateInterval.Text = Settings.GetUpdateInterval().ToString();
        }
    }
}
