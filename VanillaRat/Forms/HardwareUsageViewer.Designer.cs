namespace VanillaRat.Forms
{
    partial class HardwareUsageViewer
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
            this.txtCpuUsage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiskUsage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAvailableRam = new System.Windows.Forms.TextBox();
            this.pbDiskUsage = new System.Windows.Forms.ProgressBar();
            this.pbUsage = new System.Windows.Forms.ProgressBar();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCpuUsage
            // 
            this.txtCpuUsage.Location = new System.Drawing.Point(15, 25);
            this.txtCpuUsage.Name = "txtCpuUsage";
            this.txtCpuUsage.ReadOnly = true;
            this.txtCpuUsage.Size = new System.Drawing.Size(119, 20);
            this.txtCpuUsage.TabIndex = 0;
            this.txtCpuUsage.TextChanged += new System.EventHandler(this.txtCpuUsage_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CPU Usage (%):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Disk Usage (%):";
            // 
            // txtDiskUsage
            // 
            this.txtDiskUsage.Location = new System.Drawing.Point(15, 64);
            this.txtDiskUsage.Name = "txtDiskUsage";
            this.txtDiskUsage.ReadOnly = true;
            this.txtDiskUsage.Size = new System.Drawing.Size(119, 20);
            this.txtDiskUsage.TabIndex = 3;
            this.txtDiskUsage.TextChanged += new System.EventHandler(this.txtDiskUsage_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ram Available (MB):";
            // 
            // txtAvailableRam
            // 
            this.txtAvailableRam.Location = new System.Drawing.Point(15, 103);
            this.txtAvailableRam.Name = "txtAvailableRam";
            this.txtAvailableRam.ReadOnly = true;
            this.txtAvailableRam.Size = new System.Drawing.Size(298, 20);
            this.txtAvailableRam.TabIndex = 5;
            this.txtAvailableRam.TextChanged += new System.EventHandler(this.txtAvailableRam_TextChanged);
            // 
            // pbDiskUsage
            // 
            this.pbDiskUsage.Location = new System.Drawing.Point(140, 64);
            this.pbDiskUsage.Name = "pbDiskUsage";
            this.pbDiskUsage.Size = new System.Drawing.Size(173, 20);
            this.pbDiskUsage.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbDiskUsage.TabIndex = 7;
            // 
            // pbUsage
            // 
            this.pbUsage.Location = new System.Drawing.Point(140, 25);
            this.pbUsage.Name = "pbUsage";
            this.pbUsage.Size = new System.Drawing.Size(173, 20);
            this.pbUsage.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbUsage.TabIndex = 8;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(168, 129);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(145, 23);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(15, 129);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(145, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // HardwareUsageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 161);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.pbUsage);
            this.Controls.Add(this.pbDiskUsage);
            this.Controls.Add(this.txtAvailableRam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDiskUsage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCpuUsage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HardwareUsageViewer";
            this.Text = "Hardware Usage Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HardwareUsageViewer_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar pbDiskUsage;
        private System.Windows.Forms.ProgressBar pbUsage;
        public System.Windows.Forms.TextBox txtCpuUsage;
        public System.Windows.Forms.TextBox txtDiskUsage;
        public System.Windows.Forms.TextBox txtAvailableRam;
        public System.Windows.Forms.Button btnStop;
        public System.Windows.Forms.Button btnStart;
    }
}