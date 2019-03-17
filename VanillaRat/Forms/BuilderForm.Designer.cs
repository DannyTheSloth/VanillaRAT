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
            this.SuspendLayout();
            // 
            // lblDNS
            // 
            this.lblDNS.AutoSize = true;
            this.lblDNS.Location = new System.Drawing.Point(12, 15);
            this.lblDNS.Name = "lblDNS";
            this.lblDNS.Size = new System.Drawing.Size(33, 13);
            this.lblDNS.TabIndex = 0;
            this.lblDNS.Text = "DNS:";
            // 
            // txtDNS
            // 
            this.txtDNS.Location = new System.Drawing.Point(56, 12);
            this.txtDNS.Name = "txtDNS";
            this.txtDNS.Size = new System.Drawing.Size(149, 20);
            this.txtDNS.TabIndex = 1;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(12, 41);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(56, 38);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(149, 20);
            this.txtPort.TabIndex = 3;
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(15, 145);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(190, 23);
            this.btnBuild.TabIndex = 4;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 93);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(56, 90);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(149, 20);
            this.txtName.TabIndex = 6;
            // 
            // lblClientTag
            // 
            this.lblClientTag.AutoSize = true;
            this.lblClientTag.Location = new System.Drawing.Point(12, 67);
            this.lblClientTag.Name = "lblClientTag";
            this.lblClientTag.Size = new System.Drawing.Size(29, 13);
            this.lblClientTag.TabIndex = 7;
            this.lblClientTag.Text = "Tag:";
            // 
            // txtClientTag
            // 
            this.txtClientTag.Location = new System.Drawing.Point(56, 64);
            this.txtClientTag.Name = "txtClientTag";
            this.txtClientTag.Size = new System.Drawing.Size(149, 20);
            this.txtClientTag.TabIndex = 8;
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(126, 119);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(79, 20);
            this.txtInterval.TabIndex = 9;
            this.txtInterval.Text = "1";
            // 
            // lblUpdateInterval
            // 
            this.lblUpdateInterval.AutoSize = true;
            this.lblUpdateInterval.Location = new System.Drawing.Point(12, 122);
            this.lblUpdateInterval.Name = "lblUpdateInterval";
            this.lblUpdateInterval.Size = new System.Drawing.Size(108, 13);
            this.lblUpdateInterval.TabIndex = 10;
            this.lblUpdateInterval.Text = "Update Interval (MS):";
            // 
            // BuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 175);
            this.Controls.Add(this.lblUpdateInterval);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.txtClientTag);
            this.Controls.Add(this.lblClientTag);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtDNS);
            this.Controls.Add(this.lblDNS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BuilderForm";
            this.Text = "Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}