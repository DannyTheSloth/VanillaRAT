using System.Windows.Forms;

namespace VanillaRat.Forms
{
    public partial class ComputerInformation : Form
    {
        public ComputerInformation()
        {
            InitializeComponent();
            Update = true;
        }

        public int ConnectionID { get; set; }
        public bool Update { get; set; }

        //On form close
        private void ComputerInformation_FormClosing(object sender, FormClosingEventArgs e)
        {
            Update = false;
        }
    }
}