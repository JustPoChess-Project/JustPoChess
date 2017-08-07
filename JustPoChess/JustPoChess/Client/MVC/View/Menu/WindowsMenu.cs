using System;
using System.Threading;
using JustPoChess.Client.MVC.View.Art;
using JustPoChess.Client.MVC.View.Input;
//using JustPoChess.Client.MVC.View.Sounds;

namespace JustPoChess.Client.MVC.View.Menu
{
    public class WindowsMenu
    {
        private static volatile WindowsMenu instance = null;

        private WindowsMenu() { }

        public static WindowsMenu Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WindowsMenu();
                }

                return instance;
            }
        }

        public void InitialScreen()
        {
            Console.Clear();
            //OST.PlayInitialScreenOST();
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

            //SoundEffects.PlaySelectionSound();
            //OST.Stop();

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
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        public void InitializeMenu()
        {
            Console.Clear();
            //OST.PlayMenuOST();
            InputUtilities.ClearKeyBuffer();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MenuArt.JustPoChessMenu);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.JustPoChessLogoDown);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MenuArt.StartServerText);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.PlayText);
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
                            //SoundEffects.PlayTraverseSound();
                            if (menuOptions == 1)
                            {
                                menuOptions = 4;
                            }
                            else
                            {
                                menuOptions--;
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            //SoundEffects.PlayTraverseSound();
                            if (menuOptions == 4)
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
                                    InitializeStartServerSubMenu();
                                    break;

                                case 2:
                                    InitializePlaySubMenu();
                                    break;

                                case 3:
                                    InitializeSpectateSubMenu();
                                    break;


                                case 4:
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
                            Console.WriteLine(MenuArt.StartServerText);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.PlayText);
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

                            Console.WriteLine(MenuArt.StartServerText);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.PlayText);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
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

                            Console.WriteLine(MenuArt.StartServerText);
                            Console.WriteLine(MenuArt.PlayText);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.SpectateText);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
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

                            Console.WriteLine(MenuArt.StartServerText);
                            Console.WriteLine(MenuArt.PlayText);
                            Console.WriteLine(MenuArt.SpectateText);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.ExitText);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            break;
                    }

                    Thread.Sleep(50);
                    InputUtilities.ClearKeyBuffer();
                }
            }
        }

        private void InitializePlaySubMenu()
        {
            Console.Clear();
            //OST.PlayMenuOST();
            InputUtilities.ClearKeyBuffer();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MenuArt.JustPoChessPlay);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.JustPoChessLogoDown);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MenuArt.LocalText);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.RemoteText);
            Console.WriteLine(MenuArt.BackText);

            var menuOptions = 1;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var userInput = Console.ReadKey();
                    switch (userInput.Key)
                    {
                        case ConsoleKey.UpArrow:
                            //SoundEffects.PlayTraverseSound();
                            if (menuOptions == 1)
                            {
                                menuOptions = 3;
                            }
                            else
                            {
                                menuOptions--;
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            //SoundEffects.PlayTraverseSound();
                            if (menuOptions == 3)
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
                                    InitializeMenu();
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
                            Console.WriteLine(MenuArt.JustPoChessPlay);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.LocalText);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.RemoteText);
                            Console.WriteLine(MenuArt.BackText);
                            break;

                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.JustPoChessPlay);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.WriteLine(MenuArt.LocalText);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.RemoteText);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.BackText);
                            break;

                        case 3:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.JustPoChessPlay);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.WriteLine(MenuArt.LocalText);
                            Console.WriteLine(MenuArt.RemoteText);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.BackText);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            break;
                    }

                    Thread.Sleep(50);
                    InputUtilities.ClearKeyBuffer();
                }
            }
        }

        private void InitializeStartServerSubMenu()
        {
            Console.Clear();
            //OST.PlayMenuOST();
            InputUtilities.ClearKeyBuffer();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MenuArt.JustPoChessStartServer);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.JustPoChessLogoDown);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MenuArt.LocalText);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.RemoteText);
            Console.WriteLine(MenuArt.BackText);

            var menuOptions = 1;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var userInput = Console.ReadKey();
                    switch (userInput.Key)
                    {
                        case ConsoleKey.UpArrow:
                            //SoundEffects.PlayTraverseSound();
                            if (menuOptions == 1)
                            {
                                menuOptions = 3;
                            }
                            else
                            {
                                menuOptions--;
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            //SoundEffects.PlayTraverseSound();
                            if (menuOptions == 3)
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
                                    InitializeMenu();
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
                            Console.WriteLine(MenuArt.JustPoChessStartServer);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.LocalText);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.RemoteText);
                            Console.WriteLine(MenuArt.BackText);
                            break;

                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.JustPoChessStartServer);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.WriteLine(MenuArt.LocalText);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.RemoteText);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.BackText);
                            break;

                        case 3:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.JustPoChessStartServer);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.WriteLine(MenuArt.LocalText);
                            Console.WriteLine(MenuArt.RemoteText);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.BackText);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            break;
                    }

                    Thread.Sleep(50);
                    InputUtilities.ClearKeyBuffer();
                }
            }
        }

        private void InitializeSpectateSubMenu()
        {
            Console.Clear();
            //OST.PlayMenuOST();
            InputUtilities.ClearKeyBuffer();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MenuArt.JustPoChessSpectate);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.JustPoChessLogoDown);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MenuArt.LocalText);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.RemoteText);
            Console.WriteLine(MenuArt.BackText);

            var menuOptions = 1;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var userInput = Console.ReadKey();
                    switch (userInput.Key)
                    {
                        case ConsoleKey.UpArrow:
                            //SoundEffects.PlayTraverseSound();
                            if (menuOptions == 1)
                            {
                                menuOptions = 3;
                            }
                            else
                            {
                                menuOptions--;
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            //SoundEffects.PlayTraverseSound();
                            if (menuOptions == 3)
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
                                    InitializeMenu();
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
                            Console.WriteLine(MenuArt.JustPoChessSpectate);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.LocalText);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.RemoteText);
                            Console.WriteLine(MenuArt.BackText);
                            break;

                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.JustPoChessSpectate);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.WriteLine(MenuArt.LocalText);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.RemoteText);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.BackText);
                            break;

                        case 3:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.JustPoChessSpectate);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.WriteLine(MenuArt.LocalText);
                            Console.WriteLine(MenuArt.RemoteText);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.BackText);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            break;
                    }

                    Thread.Sleep(50);
                    InputUtilities.ClearKeyBuffer();
                }
            }
        }

    }
}

