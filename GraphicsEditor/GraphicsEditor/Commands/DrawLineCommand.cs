using System;
using System.Collections.Generic;
using ConsoleUI;
using System.Drawing;

namespace GraphicsEditor
{
    class DrawLineCommand : ICommand
    {
        readonly Picture picture;
        public string Name => "line";
        public string Help => "Нарисовать линию с заданными координатами концов";
        public string Description => "Рисует линию с заданными координатами начала и конца отрезка";
        public string[] Synonyms => new[] { "straight", "Line" };

        public DrawLineCommand(Picture picture)
        {
            this.picture = picture;
        }

        public void Execute(params string[] args)
        {
            if (args.Length != 4)
            {
                Console.WriteLine("Введено некорректное количество аргументов");
                return;
            }

            if (CheckArgs(args, out var parameters)) return;

            PointF begin = new PointF(parameters[0], parameters[1]);
            PointF end = new PointF(parameters[2], parameters[3]);
            Line line = new Line(begin, end);
            picture.Add(line);
        }

        private static bool CheckArgs(string[] args, out float[] parameters)
        {
            parameters = new float[4];
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
