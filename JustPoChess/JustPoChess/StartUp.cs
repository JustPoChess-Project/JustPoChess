using System;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.View.Menu;

namespace JustPoChess.Client.MVC
{
    public class StartUp
    {
        public static void Main()
        {
            
            try
            {
                if (IsLinux)
                {
                    Console.CursorVisible = false;

                    string input = Console.ReadLine();
                    if (input == "server")
                    {
                        Server.Server server = new Server.Server();
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
                        Server.Server server = new Server.Server();
                    }
                    if (input == "client")
                    {
                        Board.InitBoard();
                        var view = new View.View();
                        Console.WriteLine("Xd");
                        view.PrintBoard();
                        
                       //Menu.InitialScreen();
                       //Menu.InitializeMenu();
                    }
                }
            }
            catch
            {
                throw new ArgumentOutOfRangeException("FOR WINDOWS: Change Font To Raster 8 x 9");
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
