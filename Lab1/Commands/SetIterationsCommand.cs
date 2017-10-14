using System;

namespace Lab1
{
    class SetIterationsCommand : ICommand
    {
        private readonly Application app;

        public string Name => "iterations";
        public string Help => "Работа с количеством итераций";

        public string[] Synonyms => new[] { "iteration" };

        public string Description => "Для того, чтобы узнать количество установленных " +
                                     "на данный момент итерация для тестирования, введите 'iterations'. " +
                                     "Для того, чтобы установить количество итераций для тестирования, введите: " +
                                     "iterations [количество итераций > 0]";

        public SetIterationsCommand(Application app)
        {
            this.app = app;
        }

        public void Execute(params string[] parameters)
        {
            if (parameters.Length == 0)
            {
                Console.WriteLine("Установленное количество итераций для тестирования: " + app.iterations);
                return;
            }
            if (parameters.Length > 1)
            {
                Console.WriteLine("Введено более 1 аргумента");
            }

            try
            {
                int iterations = int.Parse(parameters[0]);
                if (iterations < 1)
                {
                    throw new ArgumentException("Введённое количество итераций меньше 1. Пожалуйста, подумайте хорошенько," +
                                                "зачем написана эта программа");
                }
                app.iterations = iterations;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
