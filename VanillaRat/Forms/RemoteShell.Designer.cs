namespace VanillaRat.Forms
{
    partial class RemoteShell
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
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.RemoteShellMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnToggleMode = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.btnRestartShell = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.RemoteShellMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtConsole);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 319);
            this.panel1.TabIndex = 2;
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsole.ContextMenuStrip = this.RemoteShellMenu;
            this.txtConsole.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtConsole.Location = new System.Drawing.Point(-1, -1);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(620, 319);
            this.txtConsole.TabIndex = 3;
            this.txtConsole.Text = "";
            // 
            // RemoteShellMenu
            // 
            this.RemoteShellMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnToggleMode,
            this.btnRestartShell});
            this.RemoteShellMenu.Name = "RemoteShellMenu";
            this.RemoteShellMenu.Size = new System.Drawing.Size(184, 48);
            // 
            // btnToggleMode
            // 
            this.btnToggleMode.Name = "btnToggleMode";
            this.btnToggleMode.Size = new System.Drawing.Size(183, 22);
            this.btnToggleMode.Text = "Switch to Powershell";
            this.btnToggleMode.Click += new System.EventHandler(this.btnToggleMode_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(12, 339);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(506, 20);
            this.txtCommand.TabIndex = 3;
            this.txtCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommand_KeyDown);
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.Location = new System.Drawing.Point(524, 337);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(108, 23);
            this.btnSendCommand.TabIndex = 4;
            this.btnSendCommand.Text = "Send Command";
            this.btnSendCommand.UseVisualStyleBackColor = true;
            this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
            // 
            // btnRestartShell
            // 
            this.btnRestartShell.Name = "btnRestartShell";
            this.btnRestartShell.Size = new System.Drawing.Size(183, 22);
            this.btnRestartShell.Text = "Restart Shell";
            this.btnRestartShell.Click += new System.EventHandler(this.btnRestartShell_Click);
            // 
            // RemoteShell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 368);
            this.Controls.Add(this.btnSendCommand);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RemoteShell";
            this.ShowIcon = false;
            this.Text = "Remote Shell";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RemoteShell_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RemoteShell_FormClosed);
            this.panel1.ResumeLayout(false);
            this.RemoteShellMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Button btnSendCommand;
        public System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.ContextMenuStrip RemoteShellMenu;
        private System.Windows.Forms.ToolStripMenuItem btnToggleMode;
        private System.Windows.Forms.ToolStripMenuItem btnRestartShell;
    }
}