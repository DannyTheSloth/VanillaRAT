using System.Windows.Forms;

namespace VanillaRat.Forms
{
    public partial class ComputerInformation : Form
    {
        public ComputerInformation()
        {
            InitializeComponent();
        }

        public int ConnectionID { get; set; }
    }
}