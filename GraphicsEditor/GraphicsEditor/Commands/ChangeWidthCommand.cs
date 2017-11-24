using System;
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

        public void Execute(params string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Не была введена ширина, или индексы фигур");
                return;
            }

            uint width;
            try
            {
                width = (uint)Int32.Parse(args[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка при попытке распарсить ширину `{0}` : {1}", 
                    args[0], e.Message);
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
                shape.Format.Width = width;
                picture.RemoveAt(index);
                picture.Add(index, shape);
            }
        }
    }
}
