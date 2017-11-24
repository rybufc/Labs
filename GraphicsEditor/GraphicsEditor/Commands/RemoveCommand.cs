using System;
using ConsoleUI;

namespace GraphicsEditor
{
    class RemoveCommand : ICommand
    {
        readonly Picture picture;
        public string Name => "remove";
        public string Help => "Удалить фигуры с картинки";
        public string Description => "Удаляет с картинки фигуры с заданными индексами";
        public string[] Synonyms => new[] { "delete", "Remove" };

        public RemoveCommand(Picture picture)
        {
            this.picture = picture;
        }

        public void Execute(params string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Введите номера фигур, которые нужно удалить");
                return;
            }

            int[] parameters = new int[args.Length];
            try
            {
                parameters = Array.ConvertAll(args, Int32.Parse);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка при попытке распарсить аргументы: {e.Message}");
                return;
            }

            Array.Sort(parameters);
            Array.Reverse(parameters);
            foreach(var index in parameters)
            {
                if (index >= picture.ShapesCount || index < 0)
                {
                    Console.WriteLine("На холсте нет фигуры с индексов {0}", index);
                    continue;
                }
                picture.RemoveAt(index);
                Console.WriteLine("Фигура с индексом {0} была успешно удалена.", index);
            }
        }
    }
}
