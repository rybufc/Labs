using System;
using ConsoleUI;
using DrawablesUI;

namespace GraphicsEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var picture = new Picture();
            var ui = new DrawableGUI(picture);
            var app = new Application();
            
            app.AddCommand(new ExitCommand(app));
            app.AddCommand(new ExplainCommand(app));
            app.AddCommand(new HelpCommand(app));
            app.AddCommand(new DrawPointCommand(app, picture));
            app.AddCommand(new DrawLineCommand(app, picture));
            app.AddCommand(new DrawEllipseCommand(app, picture));
            app.AddCommand(new DrawCircleCommand(app, picture));
            app.AddCommand(new RemoveCommand(app, picture));
            app.AddCommand(new ListCommand(app, picture));
            app.AddCommand(new ChangeColorCommand(app, picture));
            app.AddCommand(new ChangeWidthCommand(app, picture));

            picture.Changed += ui.Refresh;
            ui.Start();
            app.Run(Console.In);
            ui.Stop();
        }
    }
}
