using System;
using System.Text;
using System.Threading;

namespace JustPoChess.Client.View.Menu
{
    public class MenuUnix
    {
        public static void InitialScreen()
        {
            Sounds.PlayInitialScreenOST();
            Thread.Sleep(300);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(@"                                                        
                                           o   |\ ,'`. /||\ ,OO. /|    o     
                   _   _   _   |\__      /\^/\ | `'`'`' || `'`'`' |  /\^/\   |\__     _   _   _ 
                  | |_| |_| | /   o\__  |  /  ) \      /  \      /  |  /  ) /   o\__ | |_| |_| |
                   \       / |    ___=' | /  /   |    |    |    |   | /  / |    ___=' \       / 
                    |     |  |    \      Y  /    |    |    |    |    Y  /  |    \      |     |
                    |     |   \    \     |  |    |    |    |    |    |  |   \    \     |     |  
                    |     |    >    \    |  |    |    |    |    |    |  |    >    \    |     |  
                   /       \  /      \  /    \  /      \  /      \  /    \  /      \  /       \ 
                  |_________||________||______||________||________||______||________||_________|
                     __         __       __       __        __       __       __         __   
                    (  )       (  )     (  )     (  )      (  )     (  )     (  )       (  )  
                     ><         ><       ><       ><        ><       ><       ><         ><   
                    |  |       |  |     |  |     |  |      |  |     |  |     |  |       |  |  
                   /    \     /    \   /    \   /    \    /    \   /    \   /    \     /    \ 
                  |______|   |______| |______| |______|  |______| |______| |______|   |______|");
            Thread.Sleep(300);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($@"            
     /$$$$$                       /$$           /$$$$$$$            /$$$$$$  /$$                                   
    |__  $$                      | $$          | $$__  $$          /$$__  $$| $$                                   
       | $$ /$$   /$$  /$$$$$$$ /$$$$$$        | $$  \ $$ /$$$$$$ | $$  \__/| $$$$$$$   /$$$$$$   /$$$$$$$ /$$$$$$$
       | $$| $$  | $$ /$$_____/|_  $$_/        | $$$$$$$//$$__  $$| $$      | $$__  $$ /$$__  $$ /$$_____//$$_____/
  /$$  | $$| $$  | $$|  $$$$$$   | $$          | $$____/| $$  \ $$| $$      | $$  \ $$| $$$$$$$$|  $$$$$$|  $$$$$$ 
 | $$  | $$| $$  | $$ \____  $$  | $$ /$$      | $$     | $$  | $$| $$    $$| $$  | $$| $$_____/ \____  $$\____  $$
 |  $$$$$$/|  $$$$$$/ /$$$$$$$/  |  $$$$/      | $$     |  $$$$$$/|  $$$$$$/| $$  | $$|  $$$$$$$ /$$$$$$$//$$$$$$$/
  \______/  \______/ |_______/    \___/        |__/      \______/  \______/ |__/  |__/ \_______/|_______/|_______/");
            
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(new string(' ', 50));
            Console.WriteLine("(\u00a9) 2017 CodeBenders");

            bool visible = false;

            Console.ForegroundColor = ConsoleColor.Gray;
            do
            {
                string alert = visible ? "PRESS ANY KEY TO CONTINUE..." : "";
                visible = !visible;
                Console.WriteLine(alert);
                Thread.Sleep(1000);
                Console.Write(new string(' ', 10));
              
            } while (!Console.KeyAvailable);

            Sounds.PlaySelectionSound();

            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 10; i++)
            {
                string alert = visible ? "PRESS ANY KEY TO CONTINUE..." : "";
                visible = !visible;
                Console.WriteLine(alert);
                Thread.Sleep(100);
                Console.Write(new string(' ', 10));
            }

            Console.Clear();
            Console.ResetColor();
        }
    }
}