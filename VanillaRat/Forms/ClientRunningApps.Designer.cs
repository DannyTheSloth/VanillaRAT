namespace VanillaRat.Forms
{
    partial class ClientRunningApps
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
            this.components = new System.ComponentModel.Container();
            this.ProcessesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnRefreshProcesses = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEndProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbRunningProcesses = new System.Windows.Forms.ListView();
            this.chProcessName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWindowName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessesMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProcessesMenu
            // 
            this.ProcessesMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshProcesses,
            this.btnEndProcess});
            this.ProcessesMenu.Name = "ProcessesMenu";
            this.ProcessesMenu.Size = new System.Drawing.Size(168, 48);
            // 
            // btnRefreshProcesses
            // 
            this.btnRefreshProcesses.Image = global::VanillaRat.Properties.Resources.Restart_48px;
            this.btnRefreshProcesses.Name = "btnRefreshProcesses";
            this.btnRefreshProcesses.Size = new System.Drawing.Size(167, 22);
            this.btnRefreshProcesses.Text = "Refresh Processes";
            this.btnRefreshProcesses.Click += new System.EventHandler(this.btnRefreshProcesses_Click);
            // 
            // btnEndProcess
            // 
            this.btnEndProcess.Image = global::VanillaRat.Properties.Resources.Close_Window_48px;
            this.btnEndProcess.Name = "btnEndProcess";
            this.btnEndProcess.Size = new System.Drawing.Size(167, 22);
            this.btnEndProcess.Text = "End Process";
            this.btnEndProcess.Click += new System.EventHandler(this.btnEndProcess_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbRunningProcesses);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 344);
            this.panel1.TabIndex = 1;
            // 
            // lbRunningProcesses
            // 
            this.lbRunningProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProcessName,
            this.chID,
            this.chWindowName});
            this.lbRunningProcesses.ContextMenuStrip = this.ProcessesMenu;
            this.lbRunningProcesses.FullRowSelect = true;
            this.lbRunningProcesses.GridLines = true;
            this.lbRunningProcesses.Location = new System.Drawing.Point(-1, -1);
            this.lbRunningProcesses.MultiSelect = false;
            this.lbRunningProcesses.Name = "lbRunningProcesses";
            this.lbRunningProcesses.Size = new System.Drawing.Size(620, 344);
            this.lbRunningProcesses.TabIndex = 3;
            this.lbRunningProcesses.UseCompatibleStateImageBehavior = false;
            this.lbRunningProcesses.View = System.Windows.Forms.View.Details;
            // 
            // chProcessName
            // 
            this.chProcessName.Text = "Process Name";
            this.chProcessName.Width = 199;
            // 
            // chID
            // 
            this.chID.Text = "PID";
            this.chID.Width = 199;
            // 
            // chWindowName
            // 
            this.chWindowName.Text = "Window Name";
            this.chWindowName.Width = 199;
            // 
            // ClientRunningApps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(644, 368);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ClientRunningApps";
            this.ShowIcon = false;
            this.Text = "Running Applications";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientRunningApps_FormClosing);
            this.ProcessesMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip ProcessesMenu;
        public System.Windows.Forms.ToolStripMenuItem btnRefreshProcesses;
        public System.Windows.Forms.ToolStripMenuItem btnEndProcess;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ListView lbRunningProcesses;
        public System.Windows.Forms.ColumnHeader chProcessName;
        public System.Windows.Forms.ColumnHeader chID;
        private System.Windows.Forms.ColumnHeader chWindowName;
    }
}