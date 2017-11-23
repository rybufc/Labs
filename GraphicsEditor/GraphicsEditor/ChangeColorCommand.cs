using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI;
using System.Drawing;

namespace GraphicsEditor
{
    class ChangeColorCommand : ICommand
    {
        Picture picture;
        Application app;
        public string Name => "color";
        public string Help => "Изменить цвет фигур";
        public string Description => "Изменяет цвет фигур с заданными индексами";
        public string[] Synonyms => new string[] { "colour", "Color" };

        public ChangeColorCommand(Application app, Picture picture)
        {
            this.app = app;
            this.picture = picture;
        }

        public void Execute(params string[] parameters)
        {
            if (parameters.Length < 2)
            {
                Console.WriteLine("Не был введён цвет, или индексы фигур");
                return;
            }
            var color = ColorTranslator.FromHtml(parameters[0]);
            for (int i = 1; i < parameters.Length; i++)
            {
                int index = Int32.Parse(parameters[i]);
                var shape = picture.GetShape(index);
                shape.Format.Color = color;
                picture.RemoveAt(index);
                picture.Add(index, shape);
            }
        }
    }
}
