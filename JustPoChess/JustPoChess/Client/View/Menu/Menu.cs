using System;
using System.Threading;

namespace JustPoChess.Client.View.Menu
{
    public static class Menu
    {
        public static void InitialScreen()
        {
            Sounds.PlayInitialScreenOST();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($@"                                                        
 {new string(' ', Console.WindowWidth / 2 - 79 / 2)}                         o   |\ ,'`. /||\ ,OO. /|    o     
 {new string(' ', Console.WindowWidth / 2 - 79 / 2)} _   _   _   |\__      /\^/\ | `'`'`' || `'`'`' |  /\^/\   |\__     _   _   _ 
 {new string(' ', Console.WindowWidth / 2 - 79 / 2)}| |_| |_| | /   o\__  |  /  ) \      /  \      /  |  /  ) /   o\__ | |_| |_| |
 {new string(' ', Console.WindowWidth / 2 - 79 / 2)} \       / |    ___=' | /  /   |    |    |    |   | /  / |    ___=' \       / 
 {new string(' ', Console.WindowWidth / 2 - 79 / 2)}  |     |  |    \      Y  /    |    |    |    |    Y  /  |    \      |     |
 {new string(' ', Console.WindowWidth / 2 - 79 / 2)}  |     |   \    \     |  |    |    |    |    |    |  |   \    \     |     |  
 {new string(' ', Console.WindowWidth / 2 - 79 / 2)}  |     |    >    \    |  |    |    |    |    |    |  |    >    \    |     |  
 {new string(' ', Console.WindowWidth / 2 - 79 / 2)} /       \  /      \  /    \  /      \  /      \  /    \  /      \  /       \ 
 {new string(' ', Console.WindowWidth / 2 - 79 / 2)}|_________||________||______||________||________||______||________||_________|
 {new string(' ', Console.WindowWidth / 2 - 79 / 2)}   __         __       __       __        __       __       __         __   
 {new string(' ', Console.WindowWidth / 2 - 79 / 2)}  (  )       (  )     (  )     (  )      (  )     (  )     (  )       (  )  
 {new string(' ', Console.WindowWidth / 2 - 79 / 2)}   ><         ><       ><       ><        ><       ><       ><         ><   
 {new string(' ', Console.WindowWidth / 2 - 79 / 2)}  |  |       |  |     |  |     |  |      |  |     |  |     |  |       |  |  
 {new string(' ', Console.WindowWidth / 2 - 79 / 2)} /    \     /    \   /    \   /    \    /    \   /    \   /    \     /    \ 
 {new string(' ', Console.WindowWidth / 2 - 79 / 2)}|______|   |______| |______| |______|  |______| |______| |______|   |______|");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($@"            
 {new string(' ', Console.WindowWidth / 2 - 114 / 2)}     /$$$$$                       /$$           /$$$$$$$            /$$$$$$  /$$                                   
 {new string(' ', Console.WindowWidth / 2 - 114 / 2)}    |__  $$                      | $$          | $$__  $$          /$$__  $$| $$                                   
 {new string(' ', Console.WindowWidth / 2 - 114 / 2)}       | $$ /$$   /$$  /$$$$$$$ /$$$$$$        | $$  \ $$ /$$$$$$ | $$  \__/| $$$$$$$   /$$$$$$   /$$$$$$$ /$$$$$$$
 {new string(' ', Console.WindowWidth / 2 - 114 / 2)}       | $$| $$  | $$ /$$_____/|_  $$_/        | $$$$$$$//$$__  $$| $$      | $$__  $$ /$$__  $$ /$$_____//$$_____/
 {new string(' ', Console.WindowWidth / 2 - 114 / 2)}  /$$  | $$| $$  | $$|  $$$$$$   | $$          | $$____/| $$  \ $$| $$      | $$  \ $$| $$$$$$$$|  $$$$$$|  $$$$$$ 
 {new string(' ', Console.WindowWidth / 2 - 114 / 2)} | $$  | $$| $$  | $$ \____  $$  | $$ /$$      | $$     | $$  | $$| $$    $$| $$  | $$| $$_____/ \____  $$\____  $$
 {new string(' ', Console.WindowWidth / 2 - 114 / 2)} |  $$$$$$/|  $$$$$$/ /$$$$$$$/  |  $$$$/      | $$     |  $$$$$$/|  $$$$$$/| $$  | $$|  $$$$$$$ /$$$$$$$//$$$$$$$/
 {new string(' ', Console.WindowWidth / 2 - 114 / 2)}  \______/  \______/ |_______/    \___/        |__/      \______/  \______/ |__/  |__/ \_______/|_______/|_______/");

            bool visible = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                string alert = visible ? "PRESS ANY KEY TO CONTINUE..." : "";
                Console.SetCursorPosition(Console.WindowWidth / 2 - alert.Length / 2, 30);
                visible = !visible;
                Console.WriteLine(alert);
                Thread.Sleep(1000);
                Console.SetCursorPosition(40, 30);
                Console.Write(new string(' ', Console.WindowWidth));
            } while (!Console.KeyAvailable);

            Sounds.PlaySelectionSound();

            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string alert = visible ? "PRESS ANY KEY TO CONTINUE..." : "";
                Console.SetCursorPosition(Console.WindowWidth / 2 - alert.Length / 2, 30);
                visible = !visible;
                Console.WriteLine(alert);
                Thread.Sleep(100);
                Console.SetCursorPosition(40, 30);
                Console.Write(new string(' ', Console.WindowWidth));
            }

            Console.Clear();
            Console.ResetColor();
        }
    }
}
