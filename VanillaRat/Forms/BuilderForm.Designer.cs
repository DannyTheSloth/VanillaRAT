namespace VanillaRat.Forms
{
    partial class BuilderForm
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
            this.lblDNS = new System.Windows.Forms.Label();
            this.txtDNS = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnBuild = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblClientTag = new System.Windows.Forms.Label();
            this.txtClientTag = new System.Windows.Forms.TextBox();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.lblUpdateInterval = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbRegularOptions = new System.Windows.Forms.TabPage();
            this.tbAdditionalOptions = new System.Windows.Forms.TabPage();
            this.cbEnableStartup = new System.Windows.Forms.CheckBox();
            this.cbEnableInstallation = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tbRegularOptions.SuspendLayout();
            this.tbAdditionalOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDNS
            // 
            this.lblDNS.AutoSize = true;
            this.lblDNS.Location = new System.Drawing.Point(6, 9);
            this.lblDNS.Name = "lblDNS";
            this.lblDNS.Size = new System.Drawing.Size(33, 13);
            this.lblDNS.TabIndex = 0;
            this.lblDNS.Text = "DNS:";
            // 
            // txtDNS
            // 
            this.txtDNS.Location = new System.Drawing.Point(45, 6);
            this.txtDNS.Name = "txtDNS";
            this.txtDNS.Size = new System.Drawing.Size(370, 20);
            this.txtDNS.TabIndex = 1;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(6, 34);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(45, 31);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(370, 20);
            this.txtPort.TabIndex = 3;
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(12, 165);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(408, 23);
            this.btnBuild.TabIndex = 4;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 86);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(45, 83);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(370, 20);
            this.txtName.TabIndex = 6;
            // 
            // lblClientTag
            // 
            this.lblClientTag.AutoSize = true;
            this.lblClientTag.Location = new System.Drawing.Point(6, 60);
            this.lblClientTag.Name = "lblClientTag";
            this.lblClientTag.Size = new System.Drawing.Size(29, 13);
            this.lblClientTag.TabIndex = 7;
            this.lblClientTag.Text = "Tag:";
            // 
            // txtClientTag
            // 
            this.txtClientTag.Location = new System.Drawing.Point(45, 57);
            this.txtClientTag.Name = "txtClientTag";
            this.txtClientTag.Size = new System.Drawing.Size(370, 20);
            this.txtClientTag.TabIndex = 8;
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(120, 109);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(295, 20);
            this.txtInterval.TabIndex = 9;
            this.txtInterval.Text = "1";
            // 
            // lblUpdateInterval
            // 
            this.lblUpdateInterval.AutoSize = true;
            this.lblUpdateInterval.Location = new System.Drawing.Point(6, 112);
            this.lblUpdateInterval.Name = "lblUpdateInterval";
            this.lblUpdateInterval.Size = new System.Drawing.Size(108, 13);
            this.lblUpdateInterval.TabIndex = 10;
            this.lblUpdateInterval.Text = "Update Interval (MS):";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbRegularOptions);
            this.tabControl1.Controls.Add(this.tbAdditionalOptions);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(432, 163);
            this.tabControl1.TabIndex = 11;
            // 
            // tbRegularOptions
            // 
            this.tbRegularOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRegularOptions.Controls.Add(this.lblDNS);
            this.tbRegularOptions.Controls.Add(this.lblUpdateInterval);
            this.tbRegularOptions.Controls.Add(this.txtDNS);
            this.tbRegularOptions.Controls.Add(this.txtInterval);
            this.tbRegularOptions.Controls.Add(this.txtPort);
            this.tbRegularOptions.Controls.Add(this.lblName);
            this.tbRegularOptions.Controls.Add(this.txtName);
            this.tbRegularOptions.Controls.Add(this.txtClientTag);
            this.tbRegularOptions.Controls.Add(this.lblPort);
            this.tbRegularOptions.Controls.Add(this.lblClientTag);
            this.tbRegularOptions.Location = new System.Drawing.Point(4, 22);
            this.tbRegularOptions.Name = "tbRegularOptions";
            this.tbRegularOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tbRegularOptions.Size = new System.Drawing.Size(424, 137);
            this.tbRegularOptions.TabIndex = 0;
            this.tbRegularOptions.Text = "Regular Options";
            this.tbRegularOptions.UseVisualStyleBackColor = true;
            // 
            // tbAdditionalOptions
            // 
            this.tbAdditionalOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAdditionalOptions.Controls.Add(this.cbEnableStartup);
            this.tbAdditionalOptions.Controls.Add(this.cbEnableInstallation);
            this.tbAdditionalOptions.Location = new System.Drawing.Point(4, 22);
            this.tbAdditionalOptions.Name = "tbAdditionalOptions";
            this.tbAdditionalOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tbAdditionalOptions.Size = new System.Drawing.Size(424, 137);
            this.tbAdditionalOptions.TabIndex = 1;
            this.tbAdditionalOptions.Text = "Additional Options";
            this.tbAdditionalOptions.UseVisualStyleBackColor = true;
            // 
            // cbEnableStartup
            // 
            this.cbEnableStartup.AutoSize = true;
            this.cbEnableStartup.Enabled = false;
            this.cbEnableStartup.Location = new System.Drawing.Point(9, 29);
            this.cbEnableStartup.Name = "cbEnableStartup";
            this.cbEnableStartup.Size = new System.Drawing.Size(96, 17);
            this.cbEnableStartup.TabIndex = 14;
            this.cbEnableStartup.Text = "Enable Startup";
            this.cbEnableStartup.UseVisualStyleBackColor = true;
            // 
            // cbEnableInstallation
            // 
            this.cbEnableInstallation.AutoSize = true;
            this.cbEnableInstallation.Location = new System.Drawing.Point(9, 6);
            this.cbEnableInstallation.Name = "cbEnableInstallation";
            this.cbEnableInstallation.Size = new System.Drawing.Size(112, 17);
            this.cbEnableInstallation.TabIndex = 0;
            this.cbEnableInstallation.Text = "Enable Installation";
            this.cbEnableInstallation.UseVisualStyleBackColor = true;
            this.cbEnableInstallation.CheckedChanged += new System.EventHandler(this.cbEnableInstallation_CheckedChanged);
            // 
            // BuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 193);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnBuild);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BuilderForm";
            this.ShowIcon = false;
            this.Text = "Builder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BuilderForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tbRegularOptions.ResumeLayout(false);
            this.tbRegularOptions.PerformLayout();
            this.tbAdditionalOptions.ResumeLayout(false);
            this.tbAdditionalOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDNS;
        private System.Windows.Forms.TextBox txtDNS;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblClientTag;
        private System.Windows.Forms.TextBox txtClientTag;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label lblUpdateInterval;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbRegularOptions;
        private System.Windows.Forms.TabPage tbAdditionalOptions;
        private System.Windows.Forms.CheckBox cbEnableInstallation;
        private System.Windows.Forms.CheckBox cbEnableStartup;
    }
}