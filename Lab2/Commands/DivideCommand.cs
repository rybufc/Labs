using System;
using ConsoleUI;

namespace Lab2
{
    class DivideCommand : ICommand
    {
        public string Name => "div";
        public string Help => "Делит рациональные числа";

        public string[] Synonyms => new string[] { };

        public string Description => "Выводит результат деления рациональных чисел. " +
                                     "Формат: \"div r1 r2\", где r1 и r2 - рациональные или целые числа";

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

            if (r2.ToString() == "0")
            {
                Console.WriteLine("Делитель не может быть равен нулю!");
                return;
            }

            Console.WriteLine((r1 / r2).ToString());
        }

        private bool ParseInput(string input, out Rational r)
        {
            bool success = false;
            string message = "";
            try
            {
                success = Rational.TryParse(input, out r);
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            if (!success)
            {
                if (message != "")
                    Console.WriteLine(message);
                else
                    Console.WriteLine("'" + input + "' - не является рациональным числом.\n" +
                                      "Подробнее о формате ввода рациональных чисел вы можете\n прочитать в команде 'rational'");
                Console.WriteLine();
            }

            r = default(Rational);
            return success;
        }
    }
}
