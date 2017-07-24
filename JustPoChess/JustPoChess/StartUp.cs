using System;
using JustPoChess.Client.View.Menu;

namespace JustPoChess.Client.MVC
{
    public class StartUp
    {
        public static void Main()
        {
            if (IsLinux)
            {
                Console.CursorVisible = false;

                string input = Console.ReadLine();
                if (input == "server")
                {
                    Server server = new Server();
                }
                if (input == "client")
                {
                    MenuUnix.InitialScreen();
                    MenuUnix.InitializeMenu();
                }
            }
            else
            {
                Console.WindowHeight = 60;
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
                    Menu.InitializeMenu();
                }
            }

           // Model model = new Model();
           // View view = new View(model);
           // User client = new User(view);
           // Controller controller = new Controller(model, view);
        }

        public static bool IsLinux
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return (p == 4) || (p == 6) || (p == 128);
            }
        }
    }
}
