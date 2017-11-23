using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawablesUI
{
    public interface IShape : IDrawable
    {
        FormatInfo Format { get; set; }
    }

    public class FormatInfo
    {
        public System.Drawing.Color Color { get; set; }
        public uint Width { get; set; }
    }
}
