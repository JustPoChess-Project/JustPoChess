using System;
using System.Threading;
using JustPoChess.Client.View.Art;

namespace JustPoChess.Client.View.Menu
{
    public static class Menu
    {
        public static void InitialScreen()
        {
            Sounds.PlayInitialScreenOST();
            Thread.Sleep(300);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(MenuArt.JustPoChessLogo);
            Console.WriteLine();

            Thread.Sleep(300);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MenuArt.JustPoChessText);

            Console.SetCursorPosition(Console.WindowWidth / 2 - 11, 35);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("(C) 2017 CodeBenders");

            bool visible = false;

            Console.ForegroundColor = ConsoleColor.Gray;
            do
            {
                string alert = visible ? "PRESS ANY KEY TO CONTINUE..." : "";
                Console.SetCursorPosition(Console.WindowWidth / 2 - alert.Length / 2, 30);
                visible = !visible;
                Console.WriteLine(alert);
                Thread.Sleep(1000);
                Console.SetCursorPosition(40, 30);
                Console.Write(new string(' ', Console.WindowWidth));
            } while (!Console.KeyAvailable);

            Sounds.PlaySelectionSound();

            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 10; i++)
            {
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

        public static void InitializeMenu()
        {
            var menuOptions = 1;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var userInput = Console.ReadKey();

                    switch (userInput.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (menuOptions == 1)
                            {
                                menuOptions = 5;
                            }
                            else
                            {
                                menuOptions--;
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            if (menuOptions == 5)
                            {
                                menuOptions = 1;
                            }
                            else
                            {
                                menuOptions++;
                            }
                            break;

                        case ConsoleKey.Enter:
                            //do stuff
                            break;
                    }

                    Console.Clear();
                    switch (menuOptions)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.HotSeatText);
                            Console.ResetColor();
                            Console.WriteLine(MenuArt.OnlineText);
                            Console.WriteLine(MenuArt.VersusAiText);
                            Console.WriteLine(MenuArt.AiVersusAiText);
                            Console.WriteLine(MenuArt.ExitText);
                            break;

                        case 2:
                            Console.WriteLine(MenuArt.HotSeatText);
                            Console.ForegroundColor = ConsoleColor.Yellow; 
                            Console.WriteLine(MenuArt.OnlineText);
                            Console.ResetColor();
                            Console.WriteLine(MenuArt.VersusAiText);
                            Console.WriteLine(MenuArt.AiVersusAiText);
                            Console.WriteLine(MenuArt.ExitText);
                            break;

                        case 3:
                            Console.WriteLine(MenuArt.HotSeatText);
                            Console.WriteLine(MenuArt.OnlineText);
                            Console.ForegroundColor = ConsoleColor.Yellow; 
                            Console.WriteLine(MenuArt.VersusAiText);
                            Console.ResetColor();
                            Console.WriteLine(MenuArt.AiVersusAiText);
                            Console.WriteLine(MenuArt.ExitText);
                            break;
                        case 4:
                            Console.WriteLine(MenuArt.HotSeatText);
                            Console.WriteLine(MenuArt.OnlineText);
                            Console.WriteLine(MenuArt.VersusAiText);
                            Console.ForegroundColor = ConsoleColor.Yellow; 
                            Console.WriteLine(MenuArt.AiVersusAiText);
                            Console.ResetColor();
                            Console.WriteLine(MenuArt.ExitText);
                            break;

                        case 5:
                            Console.WriteLine(MenuArt.HotSeatText);
                            Console.WriteLine(MenuArt.OnlineText);
                            Console.WriteLine(MenuArt.VersusAiText);
                            Console.WriteLine(MenuArt.AiVersusAiText);
                            Console.ForegroundColor = ConsoleColor.Yellow; 
                            Console.WriteLine(MenuArt.ExitText);
                            Console.ResetColor();
                            break;
                    }


                }
            }
        }
    }
}
