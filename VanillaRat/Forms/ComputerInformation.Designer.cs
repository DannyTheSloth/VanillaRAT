namespace VanillaRat.Forms
{
    partial class ComputerInformation
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
            this.lbInformation = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbInformation
            // 
            this.lbInformation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInformation.FormattingEnabled = true;
            this.lbInformation.ItemHeight = 16;
            this.lbInformation.Location = new System.Drawing.Point(0, 0);
            this.lbInformation.Name = "lbInformation";
            this.lbInformation.Size = new System.Drawing.Size(481, 264);
            this.lbInformation.TabIndex = 0;
            // 
            // ComputerInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(481, 264);
            this.Controls.Add(this.lbInformation);
            this.Name = "ComputerInformation";
            this.ShowIcon = false;
            this.Text = "ComputerInformation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComputerInformation_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox lbInformation;
    }
}