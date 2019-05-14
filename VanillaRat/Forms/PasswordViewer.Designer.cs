namespace VanillaRat.Forms
{
    partial class PasswordViewer
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
            this.lbPasswords = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbPasswords
            // 
            this.lbPasswords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbPasswords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPasswords.FormattingEnabled = true;
            this.lbPasswords.Location = new System.Drawing.Point(0, 0);
            this.lbPasswords.Name = "lbPasswords";
            this.lbPasswords.Size = new System.Drawing.Size(481, 264);
            this.lbPasswords.TabIndex = 0;
            // 
            // PasswordViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 264);
            this.Controls.Add(this.lbPasswords);
            this.Name = "PasswordViewer";
            this.Text = "Password Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PasswordViewer_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox lbPasswords;
    }
}