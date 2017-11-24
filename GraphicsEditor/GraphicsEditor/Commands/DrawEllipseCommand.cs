using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ConsoleUI;

namespace GraphicsEditor
{
    class DrawEllipseCommand : ICommand
    {
        readonly Picture picture;
        public string Name => "ellipse";
        public string Help => "Нарисовать эллипс с заданными параметрами";
        public string Description => "Рисует эллипс с заданными центром, осями и углом поворота";
        public string[] Synonyms => new[] { "oval", "Ellipse" };

        public DrawEllipseCommand(Picture picture)
        {
            this.picture = picture;
        }

        public void Execute(params string[] parameters)
        {
            if (parameters.Length != 5)
            {
                Console.WriteLine("Введено некорректное количество аргументов");
                return;
            }
            PointF centre = new PointF(Single.Parse(parameters[0]), Single.Parse(parameters[1]));
            SizeF axises = new SizeF(Single.Parse(parameters[2]), Single.Parse(parameters[3]));
            Ellipse ellipse = new Ellipse(centre, axises, Single.Parse(parameters[4]));
            picture.Add(ellipse);
        }
    }
}
