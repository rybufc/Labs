using System;
using System.Collections.Generic;
using ConsoleUI;

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

        public void Execute(params string[] args)
        {
            if (args.Length !=2)
            {
                Console.WriteLine("Введено некорректное количество аргументов");
                return;
            }

            if (CheckArgs(args, out var parameters)) return;

            Point point = new Point(parameters[0], parameters[1]);
            picture.Add(point);
        }

        private static bool CheckArgs(string[] args, out float[] parameters)
        {
            parameters = new float[2];
            bool parseSuccess = true;
            List<string> exceptions = new List<string>();
            for (int i = 0; i < args.Length; i++)
            {
                var parameter = args[i];
                float tmp;
                bool parseResult = Single.TryParse(args[i], out tmp);
                if (!parseResult)
                {
                    exceptions.Add($"Параметр '{parameter}' - не является числом типа float");
                    parseSuccess = false;
                    continue;
                }
                if (tmp > 1000000000)
                {
                    exceptions.Add($"Параметр '{parameter}' - слишком большой.");
                    parseSuccess = false;
                    continue;
                }
                if (tmp < -1000000000)
                {
                    exceptions.Add($"Параметр '{parameter}' - слишком маленький.");
                    parseSuccess = false;
                    continue;
                }
                parameters[i] = tmp;
            }
            if (!parseSuccess)
            {
                foreach (var exceptionMessage in exceptions)
                {
                    Console.WriteLine(exceptionMessage);
                }
                return true;
            }
            return false;
        }
    }
}
