using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanillaStub
{
    public class IScreenLocker : Form
    {
        //Override form load to place center
        protected override void OnLoad(EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            base.OnLoad(e);
        }
    }
}
