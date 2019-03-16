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
    public partial class ClipboardTextViewer : Form
    {
        public ClipboardTextViewer()
        {
            InitializeComponent();
        }
        public int ConnectionID { get; set; }
    }
}
