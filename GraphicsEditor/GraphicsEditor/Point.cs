using System;
using System.Collections.Generic;
using System.Drawing;
using DrawablesUI;

namespace GraphicsEditor
{
    class Point : IDrawable
    {
        public PointF Coordinates
        {
            get;
            private set;
        }

        public Point(float x, float y)
        {
            Coordinates = new PointF(x, y);
        }

        public void Draw(IDrawer Drawer)
        {
            Drawer.DrawPoint(Coordinates);
        }
    }
}
