using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI;

namespace GraphicsEditor
{
    class RemoveCommand : ICommand
    {
        Picture picture;
        Application app;
        public string Name => "remove";
        public string Help => "Удалить фигуры с картинки";
        public string Description => "Удаляет с картинки фигуры с заданными индексами";
        public string[] Synonyms => new string[] { "delete", "Remove" };

        public RemoveCommand(Application app, Picture picture)
        {
            this.app = app;
            this.picture = picture;
        }

        public void Execute(params string[] parameters)
        {
            if (parameters.Length == 0)
            {
                Console.WriteLine("Введите номера фигур, которые нужно удалить");
                return;
            }
            int[] args = Array.ConvertAll(parameters, new Converter<string, Int32>(Int32.Parse));
            Array.Sort(args);
            Array.Reverse(args);
            foreach(var index in args)
            {
                picture.RemoveAt(index);
            }
        }
    }
}
