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
        Picture picture;
        Application app;
        public string Name => "list";
        public string Help => "Вывести список фигур на картинке";
        public string Description => "Выводит список фигур на картинке";
        public string[] Synonyms => new string[] { "catalog", "List" };

        public ListCommand(Application app, Picture picture)
        {
            this.app = app;
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
