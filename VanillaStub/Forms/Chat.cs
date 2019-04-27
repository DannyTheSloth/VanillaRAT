using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VanillaStub.Helpers.Networking;

namespace VanillaStub.Forms
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
        }

        //Data type enum
        public enum DataType
        {
            ImageType = 0,
            NotificationType = 1,
            ClientTag = 2,
            ProcessType = 3,
            InformationType = 4,
            FilesListType = 5,
            CurrentDirectoryType = 6,
            DirectoryUpType = 7,
            FileType = 8,
            ClipboardType = 9,
            HardwareUsageType = 10,
            KeystrokeType = 11,
            CurrentWindowType = 12,
            MicrophoneRecordingType = 13,
            AntiVirusTag = 14,
            WindowsVersionTag = 15,
            MessageType = 16
        }

        //Prevent form closing
        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
        }

        //Send message by button
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtChat.Text))
            {
                txtChat.Text = "You: " + txtSend.Text;
            }
            else
            {
                txtChat.AppendText(Environment.NewLine + "You: " + txtSend.Text);
            }
            List<byte> ToSend = new List<byte>();
            ToSend.Add((int)DataType.MessageType);
            ToSend.AddRange(Encoding.ASCII.GetBytes(txtSend.Text));
            Networking.MainClient.Send(ToSend.ToArray());
            txtSend.Text = "";
        }

        //If enter key is pressed, send message
        private void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txtChat.Text))
                {
                    txtChat.Text = "You: " + txtSend.Text;
                }
                else
                {
                    txtChat.AppendText(Environment.NewLine + "You: " + txtSend.Text);
                }
                List<byte> ToSend = new List<byte>();
                ToSend.Add((int)DataType.MessageType);
                ToSend.AddRange(Encoding.ASCII.GetBytes(txtSend.Text));
                Networking.MainClient.Send(ToSend.ToArray());
                txtSend.Text = "";
            }
        }

        //Tell server client is connected if visible
        private void OnVisibleChange(object sender, EventArgs e)
        {
            if (Visible)
            {
                List<byte> ToSend = new List<byte>();
                ToSend.Add((int)DataType.MessageType);
                ToSend.AddRange(Encoding.ASCII.GetBytes("Connected to chat"));
                Networking.MainClient.Send(ToSend.ToArray());
            }
        }
    }
}
