using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI;
using System.Drawing;

namespace GraphicsEditor
{
    class DrawLineCommand : ICommand
    {
        Picture picture;
        Application app;
        public string Name => "line";
        public string Help => "Нарисовать линию с заданными координатами концов";
        public string Description => "Рисует линию с заданными координатами начала и конца отрезка";
        public string[] Synonyms => new string[] { "straight", "Line" };

        public DrawLineCommand(Application app, Picture picture)
        {
            this.app = app;
            this.picture = picture;
        }

        public void Execute(params string[] parameters)
        {
            if (parameters.Length != 4)
            {
                Console.WriteLine("Введено некорректное количество аргументов");
                return;
            }
            PointF begin = new PointF(Single.Parse(parameters[0]), Single.Parse(parameters[1]));
            PointF end = new PointF(Single.Parse(parameters[2]), Single.Parse(parameters[3]));
            Line line = new Line(begin, end);
            picture.Add(line);
        }
    }
}
