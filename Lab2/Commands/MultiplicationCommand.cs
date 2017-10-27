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

        public void Execute(params string[] parameters)
        {
            if (parameters.Length != 2)
            {
                Console.WriteLine("Введено некорректное количество аргументов");
                return;
            }
            Rational r1 = default(Rational);
            Rational r2 = default(Rational);
            if (!(Rational.TryParse(parameters[0], out r1) && Rational.TryParse(parameters[1], out r2)))
            {
                Console.WriteLine("Были введены не рациональные/целые числа");
                return;
            }
            Console.WriteLine((r1 * r2).ToString());
        }
    }
}
