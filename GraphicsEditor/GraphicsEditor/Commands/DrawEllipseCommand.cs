using System;
using System.Collections.Generic;
using System.Drawing;
using ConsoleUI;

namespace GraphicsEditor
{
    class DrawEllipseCommand : ICommand
    {
        readonly Picture picture;
        public string Name => "ellipse";
        public string Help => "Нарисовать эллипс с заданными параметрами";
        public string Description => "Рисует эллипс с заданными центром, осями и углом поворота";
        public string[] Synonyms => new[] { "oval", "Ellipse" };

        public DrawEllipseCommand(Picture picture)
        {
            this.picture = picture;
        }

        public void Execute(params string[] args)
        {
            if (args.Length != 5)
            {
                Console.WriteLine("Введено некорректное количество аргументов");
                return;
            }

            if (CheckArgs(args, out var parameters)) return;

            PointF centre = new PointF(parameters[0], parameters[1]);
            SizeF axises = new SizeF(parameters[2], parameters[3]);
            Ellipse ellipse = new Ellipse(centre, axises, parameters[4]);
            picture.Add(ellipse);
        }

        private static bool CheckArgs(string[] args, out float[] parameters)
        {
            parameters = new float[5];
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
                if (i == 2 || i == 3)
                {
                    if (tmp > 1000000000 - parameters[0] || tmp > 1000000000 - parameters[1])
                    {
                        exceptions.Add($"Ось '{parameter}' - слишком большая");
                        parseSuccess = false;
                        continue;
                    }
                    if (tmp <= 0)
                    {
                        exceptions.Add($"{parameter} - Ось не может быть меньше/равна нулю!");
                        parseSuccess = false;
                        continue;
                    }
                }
                if (i == 4)
                {
                    if (tmp > 1000000000 - parameters[0] || tmp > 1000000000 - parameters[1])
                    {
                        exceptions.Add($"Радиус '{parameter}' - слишком большой");
                        parseSuccess = false;
                        continue;
                    }
                    if (tmp <= 0)
                    {
                        exceptions.Add($"{parameter} - Радиус не может быть меньше/равен нулю!");
                        parseSuccess = false;
                        continue;
                    }
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
