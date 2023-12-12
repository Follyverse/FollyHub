using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Follyverse
{
    public class TransBox : TextBox
    {
        public TransBox()
        {

            SetStyle(ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.ResizeRedraw 
                     | ControlStyles.UserPaint
                     , true);
            }

        public sealed override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }
    }
}
