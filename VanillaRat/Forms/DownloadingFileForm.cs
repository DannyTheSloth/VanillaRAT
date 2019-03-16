using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanillaRat.Forms
{
    public partial class DownloadingFileForm : Form
    {
        public DownloadingFileForm()
        {
            InitializeComponent();
        }

        private void DownloadingFileForm_Shown(object sender, EventArgs e)
        {

        }

        private void DownloadingFileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Classes.TempDataHelper.CanDownload == false)
            {
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }
    }
}
