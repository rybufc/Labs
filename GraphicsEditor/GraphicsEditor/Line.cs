using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawablesUI;
using System.Drawing;

namespace GraphicsEditor
{
    class Line : IDrawable
    {
        public PointF Begin
        {
            get;
            private set;
        }

        public PointF End
        {
            get;
            private set;
        }

        public Line(PointF begin, PointF end)
        {
            Begin = begin;
            End = end;
        }

        public void Draw(IDrawer Drawer)
        {
            Drawer.DrawLine(Begin, End);
        }
    }
}
