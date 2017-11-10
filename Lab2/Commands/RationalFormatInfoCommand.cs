using System;
using ConsoleUI;

namespace Lab2.Commands
{
    class RationalFormatInfoCommand : ICommand
    {
        public string Name => "rational";
        public string Help => "Выводит информацию о формате ввода рациональных чисел";
        public string[] Synonyms => new string[] { };

        public string Description => "Выводит информацию о формате ввода рациональных чисел";

        public void Execute(params string[] args)
        {
            string info = "Команды распознают строки форматов:\n" +
                          "{int} - приводит к дроби с основанием 1\n" +
                          "{int1}:{int2} - приводит дроби int1 / int2\n" +
                          "{int1}.{int2}:{int3} - приводит к дроби (int1 * int3 + int2) / int 3;\n";
            Console.WriteLine(info);
        }
    }
}
