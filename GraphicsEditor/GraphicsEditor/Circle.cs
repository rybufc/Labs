using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DrawablesUI;

namespace GraphicsEditor
{
    class Circle : IDrawable
    {
        public PointF Centre
        {
            get;
            private set;
        }

        public float Radius
        {
            get;
            private set;
        }

        public Circle(PointF centre, float radius)
        {
            Centre = centre;
            Radius = radius;
        }

        public void Draw(IDrawer drawer)
        {
            SizeF size = new SizeF(2 * Radius, 2 * Radius);
            drawer.DrawEllipseArc(Centre, size);
        }
    }
}
