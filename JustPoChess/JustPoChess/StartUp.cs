using System;
using JustPoChess.Client.View.Menu;

namespace JustPoChess.Client.MVC
{
    public class StartUp
    {
        public static void Main()
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 150;
            Console.CursorVisible = false;

            string input = Console.ReadLine();
            if (input == "server")
            {
                Server server = new Server();
            }
            if (input == "client")
            {
                Menu.InitialScreen();
                Model model = new Model();
                View view = new View(model);
                User client = new User(view);
                Controller controller = new Controller(model, view);
            }
        }
    }
}
