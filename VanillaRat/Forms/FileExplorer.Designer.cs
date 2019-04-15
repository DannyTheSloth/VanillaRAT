namespace VanillaRat.Forms
{
    partial class FileExplorer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbFiles = new System.Windows.Forms.ListView();
            this.chFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDownloadFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCurrentDirectory = new System.Windows.Forms.TextBox();
            this.btnGetDirectoryInfo = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.FileMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbFiles);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 319);
            this.panel1.TabIndex = 1;
            // 
            // lbFiles
            // 
            this.lbFiles.AllowDrop = true;
            this.lbFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileName,
            this.chType,
            this.chDate});
            this.lbFiles.ContextMenuStrip = this.FileMenu;
            this.lbFiles.FullRowSelect = true;
            this.lbFiles.GridLines = true;
            this.lbFiles.Location = new System.Drawing.Point(-1, -1);
            this.lbFiles.MultiSelect = false;
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(620, 319);
            this.lbFiles.TabIndex = 2;
            this.lbFiles.UseCompatibleStateImageBehavior = false;
            this.lbFiles.View = System.Windows.Forms.View.Details;
            this.lbFiles.SelectedIndexChanged += new System.EventHandler(this.lbFiles_SelectedIndexChanged_1);
            this.lbFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbFiles_DragDrop);
            this.lbFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbFiles_DragEnter);
            this.lbFiles.DoubleClick += new System.EventHandler(this.lbFiles_DoubleClick);
            // 
            // chFileName
            // 
            this.chFileName.Text = "File Name";
            this.chFileName.Width = 199;
            // 
            // chType
            // 
            this.chType.Text = "Extension";
            this.chType.Width = 199;
            // 
            // chDate
            // 
            this.chDate.Text = "Date Created";
            this.chDate.Width = 199;
            // 
            // FileMenu
            // 
            this.FileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnDownloadFile,
            this.btnUpload,
            this.btnDeleteFile});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(150, 92);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::VanillaRat.Properties.Resources.Restart_48px;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(149, 22);
            this.btnRefresh.Text = "Refresh ";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDownloadFile
            // 
            this.btnDownloadFile.Image = global::VanillaRat.Properties.Resources.Download_48px;
            this.btnDownloadFile.Name = "btnDownloadFile";
            this.btnDownloadFile.Size = new System.Drawing.Size(149, 22);
            this.btnDownloadFile.Text = "Download File";
            this.btnDownloadFile.Click += new System.EventHandler(this.btnDownloadFile_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Image = global::VanillaRat.Properties.Resources.Upload_48px;
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(149, 22);
            this.btnUpload.Text = "Upload File";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Image = global::VanillaRat.Properties.Resources.Close_Window_48px;
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(149, 22);
            this.btnDeleteFile.Text = "Delete File";
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // txtCurrentDirectory
            // 
            this.txtCurrentDirectory.Location = new System.Drawing.Point(12, 339);
            this.txtCurrentDirectory.Name = "txtCurrentDirectory";
            this.txtCurrentDirectory.Size = new System.Drawing.Size(457, 20);
            this.txtCurrentDirectory.TabIndex = 2;
            this.txtCurrentDirectory.TextChanged += new System.EventHandler(this.txtCurrentDirectory_TextChanged);
            // 
            // btnGetDirectoryInfo
            // 
            this.btnGetDirectoryInfo.Location = new System.Drawing.Point(524, 337);
            this.btnGetDirectoryInfo.Name = "btnGetDirectoryInfo";
            this.btnGetDirectoryInfo.Size = new System.Drawing.Size(108, 23);
            this.btnGetDirectoryInfo.TabIndex = 3;
            this.btnGetDirectoryInfo.Text = "Go";
            this.btnGetDirectoryInfo.UseVisualStyleBackColor = true;
            this.btnGetDirectoryInfo.Click += new System.EventHandler(this.btnGetDirectoryInfo_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(475, 337);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(43, 23);
            this.btnUp.TabIndex = 4;
            this.btnUp.Text = "^";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // FileExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 368);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnGetDirectoryInfo);
            this.Controls.Add(this.txtCurrentDirectory);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FileExplorer";
            this.ShowIcon = false;
            this.Text = "File Explorer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileExplorer_FormClosing);
            this.panel1.ResumeLayout(false);
            this.FileMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGetDirectoryInfo;
        public System.Windows.Forms.ColumnHeader chFileName;
        public System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chDate;
        public System.Windows.Forms.ListView lbFiles;
        public System.Windows.Forms.TextBox txtCurrentDirectory;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.ContextMenuStrip FileMenu;
        private System.Windows.Forms.ToolStripMenuItem btnRefresh;
        private System.Windows.Forms.ToolStripMenuItem btnDownloadFile;
        private System.Windows.Forms.ToolStripMenuItem btnUpload;
        private System.Windows.Forms.ToolStripMenuItem btnDeleteFile;
    }
}