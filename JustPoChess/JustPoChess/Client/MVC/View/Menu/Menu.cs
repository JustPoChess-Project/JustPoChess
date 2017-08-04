using System;
using System.Threading;
using JustPoChess.Client.MVC.View.Art;
using JustPoChess.Client.MVC.View.Input;
using JustPoChess.Client.MVC.View.Sounds;

namespace JustPoChess.Client.MVC.View.Menu
{
    public static class Menu
    {
        public static void InitialScreen()
        {
            Console.Clear();
            OST.PlayInitialScreenOST();
            Thread.Sleep(300);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MenuArt.JustPoChessText);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.JustPoChessLogoDown);

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(0, 11);
            Console.WriteLine(MenuArt.CopyrightLogo);

            Console.ForegroundColor = ConsoleColor.White;
            bool visible = true;
            do
            {
                string alert = visible ? $"{MenuArt.Continue}" : "";
                Console.SetCursorPosition(0, 8);
                visible = !visible;
                Console.WriteLine(alert);
                Thread.Sleep(1000);
                Console.SetCursorPosition(0, 8);
                Console.Write(new string(' ', Console.WindowWidth));

            } while (!Console.KeyAvailable);

            SoundEffects.PlaySelectionSound();
            OST.Stop();

            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 18; i++)
            {
                string alert = visible ? $"{MenuArt.Continue}" : "";
                Console.SetCursorPosition(0, 8);
                visible = !visible;
                Console.WriteLine(alert);
                Thread.Sleep(100);
                Console.SetCursorPosition(0, 8);
                Console.Write(new string(' ', Console.WindowWidth));
            }

            Console.Clear();
            Console.ResetColor();
        }

        public static void InitializeMenu()
        {
            OST.PlayMenuOST();
            Console.Clear();
            InputUtilities.ClearKeyBuffer();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MenuArt.JustPoChessMenu);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.JustPoChessLogoDown);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MenuArt.HotSeatText);
            Console.ResetColor();
            Console.WriteLine(MenuArt.OnlineText);
            Console.WriteLine(MenuArt.VersusAiText);
            Console.WriteLine(MenuArt.AiVersusAiText);
            Console.WriteLine(MenuArt.SpectateText);
            Console.WriteLine(MenuArt.ExitText);

            var menuOptions = 1;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var userInput = Console.ReadKey();
                    switch (userInput.Key)
                    {
                        case ConsoleKey.UpArrow:
                            SoundEffects.PlayTraverseSound();
                            if (menuOptions == 1)
                            {
                                menuOptions = 6;
                            }
                            else
                            {
                                menuOptions--;
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            SoundEffects.PlayTraverseSound();
                            if (menuOptions == 6)
                            {
                                menuOptions = 1;
                            }
                            else
                            {
                                menuOptions++;
                            }
                            break;

                        case ConsoleKey.Enter:
                            SoundEffects.PlaySelectionSound();
                            OST.Stop();
                            switch (menuOptions)
                            {
                                case 1:
                                    Controller.Controller.StartHotSeat();
                                    break;

                                case 2:
                                    break;

                                case 3:
                                    break;

                                case 4:
                                    break;

                                case 5:
                                    break;

                                case 6:
                                    Environment.Exit(0);
                                    break;
                            }
                            break;
                    }

                    Console.Clear();
                    switch (menuOptions)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.JustPoChessMenu);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.HotSeatText);
                            Console.ResetColor();
                            Console.WriteLine(MenuArt.OnlineText);
                            Console.WriteLine(MenuArt.VersusAiText);
                            Console.WriteLine(MenuArt.AiVersusAiText);
                            Console.WriteLine(MenuArt.SpectateText);
                            Console.WriteLine(MenuArt.ExitText);
                            break;

                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.JustPoChessMenu);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.WriteLine(MenuArt.HotSeatText);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.OnlineText);
                            Console.ResetColor();
                            Console.WriteLine(MenuArt.VersusAiText);
                            Console.WriteLine(MenuArt.AiVersusAiText);
                            Console.WriteLine(MenuArt.SpectateText);
                            Console.WriteLine(MenuArt.ExitText);
                            break;

                        case 3:

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.JustPoChessMenu);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.WriteLine(MenuArt.HotSeatText);
                            Console.WriteLine(MenuArt.OnlineText);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.VersusAiText);
                            Console.ResetColor();
                            Console.WriteLine(MenuArt.AiVersusAiText);
                            Console.WriteLine(MenuArt.SpectateText);
                            Console.WriteLine(MenuArt.ExitText);
                            break;
                        case 4:

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.JustPoChessMenu);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.WriteLine(MenuArt.HotSeatText);
                            Console.WriteLine(MenuArt.OnlineText);
                            Console.WriteLine(MenuArt.VersusAiText);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.AiVersusAiText);
                            Console.ResetColor();
                            Console.WriteLine(MenuArt.SpectateText);
                            Console.WriteLine(MenuArt.ExitText);
                            break;

                        case 5:

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.JustPoChessMenu);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.WriteLine(MenuArt.HotSeatText);
                            Console.WriteLine(MenuArt.OnlineText);
                            Console.WriteLine(MenuArt.VersusAiText);
                            Console.WriteLine(MenuArt.AiVersusAiText);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.SpectateText);
                            Console.ResetColor();
                            Console.WriteLine(MenuArt.ExitText);
                            break;

                        case 6:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.JustPoChessMenu);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.WriteLine(MenuArt.HotSeatText);
                            Console.WriteLine(MenuArt.OnlineText);
                            Console.WriteLine(MenuArt.VersusAiText);
                            Console.WriteLine(MenuArt.AiVersusAiText);
                            Console.WriteLine(MenuArt.SpectateText);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.ExitText);
                            Console.ResetColor();
                            break;
                    }

                    Thread.Sleep(50);
                    InputUtilities.ClearKeyBuffer();
                }
            }
        }
    }
}
