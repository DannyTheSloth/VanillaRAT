using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanillaStub.Forms
{
    public partial class ScreenLock : IScreenLocker
    {
        public ScreenLock()
        {
            InitializeComponent();
        }

        //Prevent user from closing with alt f4 or other closing methods
        private void OnClose(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
        }
        
    }
}
