using System;
using System.Windows.Forms;
using VanillaRat.Properties;

namespace VanillaRat.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        //Save settings
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt16(txtPort.Text);
                Convert.ToInt16(txtPort.Text);
            }
            catch
            {
                MessageBox.Show("Error: One or more text field is not a valid number.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            Settings.Default.Port = Convert.ToInt16(txtPort.Text);
            Settings.Default.UpdateInterval = Convert.ToInt16(txtUpdateInterval.Text);
            Settings.Default.Notfiy = cbNotify.Checked;
            Settings.Default.Save();
            Close();
        }

        //Load in settings
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Classes.Settings.Values Settings;
            txtPort.Text = Settings.GetPort().ToString();
            txtUpdateInterval.Text = Settings.GetUpdateInterval().ToString();
            cbNotify.Checked = Settings.GetNotifyValue();
        }
    }
}