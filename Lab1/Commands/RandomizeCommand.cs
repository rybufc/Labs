using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class RandomizeCommand : ICommand
    {
        private Application app;

        public string Name => "random";
        public string Help => "Создаёт новый случайный массив для сортировки.";
        public string Description => "Создаёт новый случайный массив для сортировки. " +
                                     "Использование: 'random' - создание массива из случайных чисел из 5000 элементов," +
                                     "'random [количество элементов, > 1]' - создание массива из случайных чисел заданной длинны";
        public string[] Synonyms => new[] { "randomize" };

        public RandomizeCommand(Application app)
        {
            this.app = app;
        }

        public void Execute(params string[] parameters)
        {
            if (parameters.Length > 1)
            {
                Console.WriteLine(errMessage);
                return;
            }

            int length;
            try
            {
                length = parameters.Length == 1 ? int.Parse(parameters[0]) : 5000;
                if (length < 2)
                {
                    throw  new ArgumentException();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(errMessage);
                return;
            }
            
            Random random = new Random();
            app.sequence = new int[length];

            for (int i = 0; i < app.sequence.Length; i++)
            {
                app.sequence[i] = random.Next();
            }
        }

        private string errMessage => "Пожалуйста, прочтите синтаксис исполmзования команды с помощью 'help random'";
    }
}
