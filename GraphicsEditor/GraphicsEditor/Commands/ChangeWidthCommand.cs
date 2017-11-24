using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI;

namespace GraphicsEditor
{
    class ChangeWidthCommand : ICommand
    {
        readonly Picture picture;
        public string Name => "width";
        public string Help => "Изменить ширину линий у фигур";
        public string Description => "Изменяет ширину линий фигур с заданными индексами";
        public string[] Synonyms => new[] { "breadth", "Width" };

        public ChangeWidthCommand(Picture picture)
        {
            this.picture = picture;
        }

        public void Execute(params string[] parameters)
        {
            if (parameters.Length < 2)
            {
                Console.WriteLine("Не была введена ширина, или индексы фигур");
                return;
            }
            uint width = (uint)Int32.Parse(parameters[0]);
            for (int i = 1; i < parameters.Length; i++)
            {
                int index = Int32.Parse(parameters[i]);
                var shape = picture.GetShape(index);
                shape.Format.Width = width;
                picture.RemoveAt(index);
                picture.Add(index, shape);
            }
        }
    }
}
