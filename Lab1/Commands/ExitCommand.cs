namespace Lab1
{
    public class ExitCommand : ICommand
    {
        readonly Application app;
        public ExitCommand(Application app)
        {
            this.app = app;
        }
        public string Name => "exit";
        public string Help => "Выход из программы";

        public string[] Synonyms => new[] { "quit", "bye" };
        public string Description => "При использовании команды 'exit', программа закроется. " +
                                     "Внезапно? ОоОоОо";

        public void Execute(params string[] parameters)
        {
            app.Exit();
        }
    }
}
