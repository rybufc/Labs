using System;
using System.Diagnostics;

namespace Lab1
{
    class TestingCommand : ICommand
    {
        private Application app;

        public string Name => "test";
        public string Help => "прогоняет методы сортировки по массиву.";
        public string Description => "Замеряет скорость работы методов сортировки. " +
                                     "Для начала замера, введите 'test'";
        public string[] Synonyms => new string[] {};

        public TestingCommand(Application app)
        {
            this.app = app;
        }

        public void Execute(params string[] parameters)
        {
            if (app.sequence == null)
            {
                Console.WriteLine("Не задан исходный массив для измерения скорости работы алгоритмов. " +
                                  "Пожалуйста, задайте его вручную с помощью команды 'sequence' или " +
                                  "сгенерируйте его случайно с помощью команды 'random'. " +
                                  "Если вы хотите подробнее узнать об этих коммандах, введите 'help'");
                return;
            }
            
            Stopwatch timer = new Stopwatch();

            Console.WriteLine("Итераций: {0}, Размер массива: {1}", app.iterations, app.sequence.Length);

            foreach (var sort in app.sortMethods)
            {
                timer.Restart();
                for (int i = 0; i < app.iterations; i++)
                {
                    sort.Item1(app.sequence);
                }
                timer.Stop();
                Console.WriteLine(sort.Item2 + " : " + timer.Elapsed);
            }
            Console.WriteLine();
        }
    }
}
