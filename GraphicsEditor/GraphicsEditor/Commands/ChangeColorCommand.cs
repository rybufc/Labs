using System;
using ConsoleUI;
using System.Drawing;

namespace GraphicsEditor
{
    class ChangeColorCommand : ICommand
    {
        readonly Picture picture;
        public string Name => "color";
        public string Help => "Изменить цвет фигур";
        public string Description => "Изменяет цвет фигур с заданными индексами";
        public string[] Synonyms => new[] { "colour", "Color" };

        public ChangeColorCommand(Picture picture)
        {
            this.picture = picture;
        }

        public void Execute(params string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Не был введён цвет, или индексы фигур");
                return;
            }

            Color color = Color.Black;
            try
            {
                color = ColorTranslator.FromHtml(args[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка при попытке распарсить цвет: {e.Message}");
                return;
            }

            for (int i = 1; i < args.Length; i++)
            {
                int index = 0;
                try
                {
                    index = Int32.Parse(args[i]);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Произошла ошибка при попытке распарсить индекс '{args[i]}': {e.Message}");
                    return;
                }
                var shape = picture.GetShape(index);
                shape.Format.Color = color;
                picture.RemoveAt(index);
                picture.Add(index, shape);
            }
        }
    }
}
