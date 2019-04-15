using System;
using System.Windows.Forms;
using VanillaRat.Classes;

namespace VanillaRat.Forms
{
    public partial class DownloadingFileForm : Form
    {
        public DownloadingFileForm()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            Update = true;
        }

        public bool Update { get; set; }

        private void DownloadingFileForm_Shown(object sender, EventArgs e)
        {
        }

        //Prevents closing until download is complete
        private void DownloadingFileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TempDataHelper.CanDownload == false)
                e.Cancel = true;
            else
                e.Cancel = false;
        }
    }
}