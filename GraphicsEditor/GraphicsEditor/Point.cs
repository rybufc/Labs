using System;
using System.Collections.Generic;
using System.Drawing;
using DrawablesUI;

namespace GraphicsEditor
{
    class Point : IShape
    {
        public PointF Coordinates
        {
            get;
            private set;
        }

        public FormatInfo Format { get; set; } = new FormatInfo();

        public Point(float x, float y)
        {
            Coordinates = new PointF(x, y);
            Format.Color = Color.Black;
            Format.Width = 1;
        }

        public void Draw(IDrawer drawer)
        {
            drawer.SelectPen(Format.Color, (int)Format.Width);
            drawer.DrawPoint(Coordinates);
        }

        public override string ToString()
        {

            string result = string.Format("Точка({0}, {1})", Coordinates.X, Coordinates.Y);
            return result;
        }
    }
}
