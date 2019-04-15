namespace VanillaRat.Forms
{
    partial class AudioRecorder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartStopRecord = new System.Windows.Forms.Button();
            this.btnPlayback = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartStopRecord
            // 
            this.btnStartStopRecord.Location = new System.Drawing.Point(12, 12);
            this.btnStartStopRecord.Name = "btnStartStopRecord";
            this.btnStartStopRecord.Size = new System.Drawing.Size(193, 23);
            this.btnStartStopRecord.TabIndex = 0;
            this.btnStartStopRecord.Text = "Start Recording";
            this.btnStartStopRecord.UseVisualStyleBackColor = true;
            this.btnStartStopRecord.Click += new System.EventHandler(this.btnStartStopRecord_Click);
            // 
            // btnPlayback
            // 
            this.btnPlayback.Location = new System.Drawing.Point(12, 41);
            this.btnPlayback.Name = "btnPlayback";
            this.btnPlayback.Size = new System.Drawing.Size(193, 23);
            this.btnPlayback.TabIndex = 1;
            this.btnPlayback.Text = "Start Playing";
            this.btnPlayback.UseVisualStyleBackColor = true;
            this.btnPlayback.Click += new System.EventHandler(this.btnPlayback_Click);
            // 
            // AudioRecorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 76);
            this.Controls.Add(this.btnPlayback);
            this.Controls.Add(this.btnStartStopRecord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AudioRecorder";
            this.ShowIcon = false;
            this.Text = "Audio Recorder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AudioRecorder_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartStopRecord;
        private System.Windows.Forms.Button btnPlayback;
    }
}