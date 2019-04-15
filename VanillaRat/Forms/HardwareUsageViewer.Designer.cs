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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtCpuUsage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiskUsage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAvailableRam = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.UsageTabs = new System.Windows.Forms.TabControl();
            this.tpCPU = new System.Windows.Forms.TabPage();
            this.ucCpu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tpDisk = new System.Windows.Forms.TabPage();
            this.ucDisk = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tpRam = new System.Windows.Forms.TabPage();
            this.bwUpdateCharts = new System.ComponentModel.BackgroundWorker();
            this.UsageTabs.SuspendLayout();
            this.tpCPU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucCpu)).BeginInit();
            this.tpDisk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucDisk)).BeginInit();
            this.tpRam.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCpuUsage
            // 
            this.txtCpuUsage.Location = new System.Drawing.Point(6, 19);
            this.txtCpuUsage.Name = "txtCpuUsage";
            this.txtCpuUsage.ReadOnly = true;
            this.txtCpuUsage.Size = new System.Drawing.Size(459, 20);
            this.txtCpuUsage.TabIndex = 0;
            this.txtCpuUsage.TextChanged += new System.EventHandler(this.txtCpuUsage_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CPU Usage (%):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Disk Usage (%):";
            // 
            // txtDiskUsage
            // 
            this.txtDiskUsage.Location = new System.Drawing.Point(6, 19);
            this.txtDiskUsage.Name = "txtDiskUsage";
            this.txtDiskUsage.ReadOnly = true;
            this.txtDiskUsage.Size = new System.Drawing.Size(459, 20);
            this.txtDiskUsage.TabIndex = 3;
            this.txtDiskUsage.TextChanged += new System.EventHandler(this.txtDiskUsage_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ram Available (MB):";
            // 
            // txtAvailableRam
            // 
            this.txtAvailableRam.Location = new System.Drawing.Point(6, 19);
            this.txtAvailableRam.Name = "txtAvailableRam";
            this.txtAvailableRam.ReadOnly = true;
            this.txtAvailableRam.Size = new System.Drawing.Size(459, 20);
            this.txtAvailableRam.TabIndex = 5;
            this.txtAvailableRam.TextChanged += new System.EventHandler(this.txtAvailableRam_TextChanged);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(12, 229);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(457, 23);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // UsageTabs
            // 
            this.UsageTabs.Controls.Add(this.tpCPU);
            this.UsageTabs.Controls.Add(this.tpDisk);
            this.UsageTabs.Controls.Add(this.tpRam);
            this.UsageTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.UsageTabs.Location = new System.Drawing.Point(0, 0);
            this.UsageTabs.Name = "UsageTabs";
            this.UsageTabs.SelectedIndex = 0;
            this.UsageTabs.Size = new System.Drawing.Size(481, 223);
            this.UsageTabs.TabIndex = 11;
            // 
            // tpCPU
            // 
            this.tpCPU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpCPU.Controls.Add(this.ucCpu);
            this.tpCPU.Controls.Add(this.txtCpuUsage);
            this.tpCPU.Controls.Add(this.label1);
            this.tpCPU.Location = new System.Drawing.Point(4, 22);
            this.tpCPU.Name = "tpCPU";
            this.tpCPU.Padding = new System.Windows.Forms.Padding(3);
            this.tpCPU.Size = new System.Drawing.Size(473, 197);
            this.tpCPU.TabIndex = 0;
            this.tpCPU.Text = "CPU Usage";
            this.tpCPU.UseVisualStyleBackColor = true;
            // 
            // ucCpu
            // 
            chartArea3.Name = "ChartArea1";
            this.ucCpu.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.ucCpu.Legends.Add(legend3);
            this.ucCpu.Location = new System.Drawing.Point(6, 45);
            this.ucCpu.Name = "ucCpu";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.ucCpu.Series.Add(series3);
            this.ucCpu.Size = new System.Drawing.Size(459, 144);
            this.ucCpu.TabIndex = 12;
            this.ucCpu.Text = "chart1";
            // 
            // tpDisk
            // 
            this.tpDisk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpDisk.Controls.Add(this.ucDisk);
            this.tpDisk.Controls.Add(this.label2);
            this.tpDisk.Controls.Add(this.txtDiskUsage);
            this.tpDisk.Location = new System.Drawing.Point(4, 22);
            this.tpDisk.Name = "tpDisk";
            this.tpDisk.Padding = new System.Windows.Forms.Padding(3);
            this.tpDisk.Size = new System.Drawing.Size(473, 197);
            this.tpDisk.TabIndex = 1;
            this.tpDisk.Text = "Disk Usage";
            this.tpDisk.UseVisualStyleBackColor = true;
            // 
            // ucDisk
            // 
            chartArea4.Name = "ChartArea1";
            this.ucDisk.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.ucDisk.Legends.Add(legend4);
            this.ucDisk.Location = new System.Drawing.Point(6, 45);
            this.ucDisk.Name = "ucDisk";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.ucDisk.Series.Add(series4);
            this.ucDisk.Size = new System.Drawing.Size(459, 144);
            this.ucDisk.TabIndex = 13;
            this.ucDisk.Text = "chart1";
            // 
            // tpRam
            // 
            this.tpRam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpRam.Controls.Add(this.label3);
            this.tpRam.Controls.Add(this.txtAvailableRam);
            this.tpRam.Location = new System.Drawing.Point(4, 22);
            this.tpRam.Name = "tpRam";
            this.tpRam.Padding = new System.Windows.Forms.Padding(3);
            this.tpRam.Size = new System.Drawing.Size(473, 197);
            this.tpRam.TabIndex = 2;
            this.tpRam.Text = "Available Ram";
            this.tpRam.UseVisualStyleBackColor = true;
            // 
            // bwUpdateCharts
            // 
            this.bwUpdateCharts.WorkerSupportsCancellation = true;
            this.bwUpdateCharts.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwUpdateCharts_DoWork);
            // 
            // HardwareUsageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 261);
            this.Controls.Add(this.UsageTabs);
            this.Controls.Add(this.btnStop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HardwareUsageViewer";
            this.ShowIcon = false;
            this.Text = "Hardware Usage Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HardwareUsageViewer_FormClosing);
            this.Load += new System.EventHandler(this.HardwareUsageViewer_Load);
            this.UsageTabs.ResumeLayout(false);
            this.tpCPU.ResumeLayout(false);
            this.tpCPU.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucCpu)).EndInit();
            this.tpDisk.ResumeLayout(false);
            this.tpDisk.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucDisk)).EndInit();
            this.tpRam.ResumeLayout(false);
            this.tpRam.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtCpuUsage;
        public System.Windows.Forms.TextBox txtDiskUsage;
        public System.Windows.Forms.TextBox txtAvailableRam;
        public System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TabControl UsageTabs;
        private System.Windows.Forms.TabPage tpCPU;
        private System.Windows.Forms.TabPage tpDisk;
        private System.Windows.Forms.TabPage tpRam;
        private System.Windows.Forms.DataVisualization.Charting.Chart ucCpu;
        private System.Windows.Forms.DataVisualization.Charting.Chart ucDisk;
        private System.ComponentModel.BackgroundWorker bwUpdateCharts;
    }
}