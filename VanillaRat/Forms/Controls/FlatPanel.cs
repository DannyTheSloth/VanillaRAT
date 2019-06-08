using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanillaRat.Forms.Controls
{
    public partial interface IFlatPanel
    {
        Color BorderColor { get; set; }
    }

    public partial class FlatPanel : Control, IFlatPanel
    {
        public FlatPanel()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            BorderColor = Color.Black;
        }

        public Color BorderColor { get; set; }

        protected override void OnPaint(PaintEventArgs pe)
        {
            using (SolidBrush SB = new SolidBrush(BackColor))
                pe.Graphics.FillRectangle(SB, ClientRectangle);
            pe.Graphics.DrawRectangle(new Pen(BorderColor), 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
        }
    }
}
