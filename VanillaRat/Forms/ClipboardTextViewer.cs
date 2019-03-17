using System.Windows.Forms;

namespace VanillaRat.Forms
{
    public partial class ClipboardTextViewer : Form
    {
        public ClipboardTextViewer()
        {
            InitializeComponent();
        }

        public int ConnectionID { get; set; }
    }
}