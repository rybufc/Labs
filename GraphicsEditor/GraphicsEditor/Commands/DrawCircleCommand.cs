using System;
using System.Collections.Generic;
using System.Drawing;
using ConsoleUI;

namespace GraphicsEditor
{
    class DrawCircleCommand : ICommand
    {
        readonly Picture picture;
        public string Name => "circle";
        public string Help => "Нарисовать окружность с заданными параметрами";
        public string Description => "Рисует окружность с заданными центром и радиусом";
        public string[] Synonyms => new[] { "ring", "round", "Circle" };

        public DrawCircleCommand(Picture picture)
        {
            this.picture = picture;
        }

        public void Execute(params string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Введено некорректное количество аргументов");
                return;
            }

            if (CheckArgs(args, out var parameters)) return;
            ;

            PointF centre = new PointF(parameters[0], parameters[1]);
            Circle circle = new Circle(centre, parameters[2]);
            picture.Add(circle);
        }

        private static bool CheckArgs(string[] args, out float[] parameters)
        {
            parameters = new float[3];
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
                if (i == 2)
                {
                    if (tmp > 1000000000 - parameters[0] || tmp > 1000000000 - parameters[1])
                    {
                        exceptions.Add($"Радиус '{parameter}' - слишком большой");
                        parseSuccess = false;
                        continue;
                    }
                    if (tmp < 0)
                    {
                        exceptions.Add("Радиус не может быть меньше нуля!");
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
