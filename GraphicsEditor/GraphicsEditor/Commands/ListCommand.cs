using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI;
using DrawablesUI;

namespace GraphicsEditor
{
    class ListCommand : ICommand
    {
        readonly Picture picture;
        public string Name => "list";
        public string Help => "Вывести список фигур на картинке";
        public string Description => "Выводит список фигур на картинке";
        public string[] Synonyms => new[] { "catalog", "List" };

        public ListCommand(Picture picture)
        {
            this.picture = picture;
        }

        public void Execute(params string[] parameters)
        {
            if (parameters.Length != 0)
            {
                Console.WriteLine("Команда 'list' не принимает аргументы");
                return;
            }

            picture.Information();
        }
    }
}
