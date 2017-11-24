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
            app.AddCommand(new HelpCommand(app));
            app.AddCommand(new DrawPointCommand(picture));
            app.AddCommand(new DrawLineCommand(picture));
            app.AddCommand(new DrawEllipseCommand(picture));
            app.AddCommand(new DrawCircleCommand(picture));
            app.AddCommand(new RemoveCommand(picture));
            app.AddCommand(new ListCommand(picture));
            app.AddCommand(new ChangeColorCommand(picture));
            app.AddCommand(new ChangeWidthCommand(picture));

            picture.Changed += ui.Refresh;
            ui.Start();
            app.Run(args);
            ui.Stop();
        }
    }
}
