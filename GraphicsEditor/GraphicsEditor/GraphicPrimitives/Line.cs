using DrawablesUI;
using System.Drawing;

namespace GraphicsEditor
{
    class Line : IShape
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

        public FormatInfo Format { get; set; } = new FormatInfo();

        public Line(PointF begin, PointF end)
        {
            Begin = begin;
            End = end;
            Format.Color = Color.Black;
            Format.Width = 1;
        }

        public void Draw(IDrawer drawer)
        {
            drawer.SelectPen(Format.Color, (int)Format.Width);
            drawer.DrawLine(Begin, End);
        }

        public override string ToString()
        {
            string result = string.Format("Линия(Начало({0}, {1}), Конец({2}, {3}))",
                Begin.X, Begin.Y, End.X, End.Y);
            return result;
        }
    }
}
