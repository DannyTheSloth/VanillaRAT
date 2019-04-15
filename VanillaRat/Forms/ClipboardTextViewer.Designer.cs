namespace VanillaRat.Forms
{
    partial class ClipboardTextViewer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtClipboardText = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtClipboardText);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 344);
            this.panel1.TabIndex = 0;
            // 
            // txtClipboardText
            // 
            this.txtClipboardText.BackColor = System.Drawing.SystemColors.Window;
            this.txtClipboardText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClipboardText.Location = new System.Drawing.Point(-1, -1);
            this.txtClipboardText.Name = "txtClipboardText";
            this.txtClipboardText.ReadOnly = true;
            this.txtClipboardText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtClipboardText.Size = new System.Drawing.Size(620, 344);
            this.txtClipboardText.TabIndex = 1;
            this.txtClipboardText.Text = "";
            // 
            // ClipboardTextViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 368);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ClipboardTextViewer";
            this.ShowIcon = false;
            this.Text = "Clipboard Text Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClipboardTextViewer_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.RichTextBox txtClipboardText;
    }
}