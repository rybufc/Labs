using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DrawablesUI;

namespace GraphicsEditor
{
    class Circle : IShape
    {
        public PointF Centre
        {
            get;
            private set;
        }

        public FormatInfo Format { get; set; } = new FormatInfo();

        public float Radius
        {
            get;
            private set;
        }

        public Circle(PointF centre, float radius)
        {
            Centre = centre;
            Radius = radius;
            Format.Color = Color.Black;
            Format.Width = 1;
        }

        public void Draw(IDrawer drawer)
        {
            drawer.SelectPen(Format.Color, (int)Format.Width);
            SizeF size = new SizeF(2 * Radius, 2 * Radius);
            drawer.DrawEllipseArc(Centre, size);
        }

        public override string ToString()
        {
            string result = string.Format("Круг(Центр({0}, {1}), Радиус = {2})",
                Centre.X, Centre.Y, Radius);
            return result;
        }
    }
}
