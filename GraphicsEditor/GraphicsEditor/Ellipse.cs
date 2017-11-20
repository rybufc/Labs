using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DrawablesUI;

namespace GraphicsEditor
{
    class Ellipse : IDrawable
    {
        public PointF Centre
        {
            get;
            private set;
        }

        public SizeF Axises
        {
            get;
            private set;
        }

        public float Rotate
        {
            get;
            private set;
        }

        public Ellipse(PointF centre, SizeF axises, float rotate)
        {
            Centre = centre;
            Axises = axises;
            Rotate = rotate;
        }

        public void Draw(IDrawer Drawer)
        {
            Drawer.DrawEllipseArc(Centre, Axises, 0, 360, Rotate);
        }
    }
}
