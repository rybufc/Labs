using ConsoleUI;
using Lab2.Commands;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application();

            app.AddCommand(new AdditionCommand());
            app.AddCommand(new DivideCommand());
            app.AddCommand(new MultiplicatinCommand());
            app.AddCommand(new SubtractionCommand());
            app.AddCommand(new RationalFormatInfoCommand());
            app.AddCommand(new HelpCommand(app));
            app.AddCommand(new ExitCommand(app));

            app.Run(args);
        }
    }
}
