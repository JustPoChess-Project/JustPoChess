using System;
using System.Threading;
using JustPoChess.Client.MVC.View.Art;

namespace JustPoChess.Client.MVC.View.Menu
{
    public class MenuUnix
    {
        public static void InitialScreen()
        {
            Thread.Sleep(300);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{MenuArt.JustPoChessLogo}");
            Thread.Sleep(300);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{MenuArt.JustPoChessText}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine($"{MenuArt.Continue}");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"{MenuArt.CopyrightLogo}");

            while(!Console.KeyAvailable) { }

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
                            switch (menuOptions)
                            {
                                case 1:
                                    break;

                                case 2:
                                    break;

                                case 3:
                                    break;

                                case 4:
                                    break;

                                case 5:
                                    Environment.Exit(0);
                                    break;
                            }
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

