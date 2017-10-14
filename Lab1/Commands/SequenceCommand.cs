using System;

namespace Lab1
{
    class SequenceCommand : ICommand
    {
        private readonly Application app;

        public string Name => "sequence";
        public string Help => "Работа с массивом для сортировки.";

        public string Description => "При передаче без параметров, выведет текущий массив"+
                                     " для портировки. Также, можно непосредственно задать новый массив, передав его элементы" +
                                     " в качестве аргументов через пробел";

        public string[] Synonyms => new string[] {};

        public SequenceCommand(Application app)
        {
            this.app = app;
        }

        public void Execute(params string[] parameters)
        {
            if (parameters.Length == 0)
            {
                if (app.sequence == null)
                {
                    Console.WriteLine("Не задан исходный массив для измерения скорости работы алгоритмов. " +
                                      "Пожалуйста, задайте его вручную с помощью команды 'sequence' или " +
                                      "сгенерируйте его случайно с помощью команды 'random'. " +
                                      "Если вы хотите подробнее узнать об этих коммандах, введите 'help'");
                    return;
                }

                Console.Write('[');
                for (int i = 0; i < app.sequence.Length; i++)
                {
                    Console.Write(app.sequence[i] + " ");
                }
                Console.Write("]\n");
                return;
            }

            int[] newSequence = new int[parameters.Length];
            bool errorFound = false;
            for (int i = 0; i < parameters.Length; i++)
            {
                try
                {
                    newSequence[i] = int.Parse(parameters[i]);
                }
                catch (Exception err)
                {
                    Console.WriteLine("В элементе массива №" + i + " (" + parameters[i]
                        + ") допущена следующая ошибка: " + err.Message);
                    errorFound = true;
                }
            }
            if (errorFound)
            {
                return;
            }

            app.sequence = newSequence;
            
        }
    }
}
