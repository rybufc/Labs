using System;

namespace ConsoleUI
{
    public class HelpCommand : ICommand
    {
        readonly Application app;
        public string Name => "help";
        public string Help => "Краткая помощь по всем командам";

        public string[] Synonyms => new[] { "?" };

        public string Description => "Выводит список с их кратким описанием. " +
                                     "Для того, чтобы узнать более подробное описание команды, введите 'help [command]', " +
                                     "где [command] - нужная вам команда";

        public HelpCommand(Application app)
        {
            this.app = app;
        }

        public void Execute(params string[] args)
        {
            if (args.Length == 1)
            {
                string command = args[0];
                foreach (ICommand cmd in app.Commands)
                {
                    if (cmd.Name == command)
                    {
                        Console.WriteLine("\n" + line);
                        PrintDescription(cmd);
                        Console.WriteLine(line + "\n");
                        return;
                    }
                }
            }

            Console.WriteLine(line);
            foreach (ICommand cmd in app.Commands)
            {
                Console.WriteLine("{0}: {1}", cmd.Name, cmd.Help);
            }
            Console.WriteLine(line);
        }

        private static void PrintDescription(ICommand cmd)
        {
            string toShow = cmd.Description;
            string temp;
            while (toShow.Length > 0)
            {
                if (toShow.Length >= line.Length)
                {
                    temp = toShow.Substring(0, line.Length);
                    toShow = toShow.Substring(line.Length);
                }
                else
                {
                    temp = toShow;
                    toShow = "";
                }

                Console.WriteLine(temp);

            }
        }

        private const string line = "===============================================================";

    }
}
