using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ConsoleUI;

namespace GraphicsEditor
{
    class DrawCircleCommand : ICommand
    {
        Picture picture;
        Application app;
        public string Name => "circle";
        public string Help => "Нарисовать окружность с заданными параметрами";
        public string Description => "Рисует окружность с заданными центром и радиусом";
        public string[] Synonyms => new string[] { "ring", "round", "Circle" };

        public DrawCircleCommand(Application app, Picture picture)
        {
            this.app = app;
            this.picture = picture;
        }

        public void Execute(params string[] parameters)
        {
            if (parameters.Length != 3)
            {
                Console.WriteLine("Введено некорректное количество аргументов");
                return;
            }
            PointF centre = new PointF(Single.Parse(parameters[0]), Single.Parse(parameters[1]));
            Circle circle = new Circle(centre, Single.Parse(parameters[2]));
            picture.Add(circle);
        }
    }
}
