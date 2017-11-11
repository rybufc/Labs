using System;
using ConsoleUI;

namespace Lab2
{
    class MultiplicatinCommand : ICommand
    {
        public string Name => "mul";
        public string Help => "Вычисляет произведение рациональных чисел";

        public string[] Synonyms => new string[] { };

        public string Description => "Выводит произведение рациональных чисел. " +
                                     "Формат: \"mul r1 r2\", где r1 и r2 - рациональные или целые числа";

        public void Execute(params string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Введено некорректное количество аргументов");
                return;
            }

            Rational r1 = default(Rational);
            Rational r2 = default(Rational);
            bool r1Success = ParseInput(args[0], out r1);
            bool r2Success = ParseInput(args[1], out r2);
            bool success = r1Success && r2Success;
            if (!success)
            {
                return;
            }

            Console.WriteLine((r1 * r2).ToString());
        }

        private bool ParseInput(string input, out Rational r)
        {
            bool success = Rational.TryParse(input, out r); ;
            if (!success)
            {
                Console.WriteLine("'" + input + "' - не является рациональным числом.\n" +
                                  "Подробнее о формате ввода рациональных чисел вы можете\n " +
                                  "прочитать в команде 'rational'\n");
            }
            return success;
        }
    }
}
