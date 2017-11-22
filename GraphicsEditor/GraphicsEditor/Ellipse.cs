using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DrawablesUI;

namespace GraphicsEditor
{
    class Ellipse : IShape
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

        public FormatInfo Format { get; set; } = new FormatInfo();

        public Ellipse(PointF centre, SizeF axises, float rotate)
        {
            Centre = centre;
            Axises = axises;
            Rotate = rotate;
            Format.Color = Color.Black;
            Format.Width = 1;
        }

        public void Draw(IDrawer drawer)
        {
            drawer.SelectPen(Format.Color, (int)Format.Width);
            drawer.DrawEllipseArc(Centre, Axises, 0, 360, Rotate);
        }

        public override string ToString()
        {
            string result = string.Format("Эллипс(Центр({0}, {1}), Оси({2}, {3}), Угол = {4})",
                Centre.X, Centre.Y, Axises.Height, Axises.Width, Rotate);
            return result;
        }
    }
}
