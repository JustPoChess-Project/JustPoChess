using System;
using JustPoChess.Client.View.Menu;
using JustPoChess.Client.MVC;

namespace JustPoChess
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            if (input == "server") {
                Server server = new Server();
            }
            if (input == "client")
            {
                Menu.PrintLogo();
                Model model = new Model();
                View view = new View(model);
                User client = new User(view);
                Controller controller = new Controller(model, view);
            }
        }       
    }
}
