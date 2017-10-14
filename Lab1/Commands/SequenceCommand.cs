using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1
{
    class SequenceCommand : ICommand
    {
        private Application app;

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
                Console.Write('[');
                for (int i = 0; i < app.sequence.Length; i++)
                {
                    Console.Write(app.sequence[i] + " ");
                }
                Console.Write("]\n");
                return;
            }

            try
            {
                int[] newSequence = new int[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    newSequence[i] = int.Parse(parameters[i]);
                }

                app.sequence = newSequence;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            
        }
    }
}
