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
            this.pbDesktop = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbDesktop)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDesktop
            // 
            this.pbDesktop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDesktop.Location = new System.Drawing.Point(0, 0);
            this.pbDesktop.Name = "pbDesktop";
            this.pbDesktop.Size = new System.Drawing.Size(644, 368);
            this.pbDesktop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDesktop.TabIndex = 0;
            this.pbDesktop.TabStop = false;
            // 
            // RDC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 368);
            this.Controls.Add(this.pbDesktop);
            this.Name = "RDC";
            this.ShowIcon = false;
            this.Text = "RDC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RDC_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbDesktop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pbDesktop;
    }
}