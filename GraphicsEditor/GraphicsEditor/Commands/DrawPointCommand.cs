using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI;
using DrawablesUI;

namespace GraphicsEditor
{
    public class DrawPointCommand : ICommand
    {
        readonly Picture picture;
        public string Name => "point";
        public string Help => "Нарисовать точку с заданными координатами";
        public string Description => "Рисует точку с заданными координатами X и Y";
        public string[] Synonyms => new[] { "dot", "Point" };

        public DrawPointCommand(Picture picture)
        {
            this.picture = picture;
        }

        public void Execute(params string[] parameters)
        {
            if (parameters.Length !=2)
            {
                Console.WriteLine("Введено некорректное количество аргументов");
                return;
            }
            Point point = new Point(Single.Parse(parameters[0]), Single.Parse(parameters[1]));
            picture.Add(point);
        }
    }
}
