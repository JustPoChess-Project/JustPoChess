using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JustPoChess.Client.MVC.View.Art;
using JustPoChess.Client.MVC.View.Input;
using JustPoChess.Client.MVC.View.Sounds;

namespace JustPoChess.Client.MVC.View.Menu
{
    public class LinuxMenu
    {
        private static volatile LinuxMenu instance = null;

        private LinuxMenu() { }

        public static LinuxMenu Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LinuxMenu();
                }

                return instance;
            }
        }

        public void InitialScreen()
        {
            Console.Clear();
            Sound.PlayInitialScreenOST();
            Thread.Sleep(300);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MenuArt.JustPoChessText);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.JustPoChessLogoDown);

            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(MenuArt.Continue);

            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(MenuArt.CopyrightLogo);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            while (!Console.KeyAvailable) { }
            Sound.PlaySelectionSound();
            Thread.Sleep(1800);
        }

        public void InitializeMenu()
        {
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
                            Sound.PlayTraverseSound();
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
                            Sound.PlayTraverseSound();
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
                                    Sound.PlaySelectionSound();
                                    InitializeStartServerSubMenu();
                                    break;

                                case 2:
                                    Sound.PlaySelectionSound();
                                    InitializePlaySubMenu();
                                    break;

                                case 3:
                                    Sound.PlaySelectionSound();
                                    InitializeSpectateSubMenu();
                                    break;


                                case 4:
                                    Sound.PlaySelectionSound();
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
                            Sound.PlayTraverseSound();
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
                            Sound.PlayTraverseSound();
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
                                    Sound.PlaySelectionSound();
                                    InitializePlaySubMenuLocalSubMenu();
                                    break;

                                case 2:
                                    Sound.PlaySelectionSound();
                                    InitializePlaySubMenuRemoteSubMenu();
                                    break;

                                case 3:
                                    Sound.PlaySelectionSound();
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

        private void InitializePlaySubMenuLocalSubMenu()
        {
            Console.Clear();
            InputUtilities.ClearKeyBuffer();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MenuArt.JustPoChessPlayLocal);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.JustPoChessLogoDown);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MenuArt.AsHuman);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.AsAi);
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
                            Sound.PlayTraverseSound();
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
                            Sound.PlayTraverseSound();
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
                                    Sound.PlaySelectionSound();
                                    break;

                                case 2:
                                    Sound.PlaySelectionSound();
                                    break;

                                case 3:
                                    Sound.PlaySelectionSound();
                                    InitializePlaySubMenu();
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
                            Console.WriteLine(MenuArt.JustPoChessPlayLocal);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.AsHuman);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.AsAi);
                            Console.WriteLine(MenuArt.BackText);
                            break;

                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.JustPoChessPlayLocal);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.WriteLine(MenuArt.AsHuman);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.AsAi);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.BackText);
                            break;

                        case 3:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.JustPoChessPlayLocal);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.WriteLine(MenuArt.AsHuman);
                            Console.WriteLine(MenuArt.AsAi);
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

        private void InitializePlaySubMenuRemoteSubMenu()
        {
            Console.Clear();
            //OST.PlayMenuOST();
            InputUtilities.ClearKeyBuffer();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MenuArt.JustPoChessPlayRemote);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.JustPoChessLogoDown);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MenuArt.AsHuman);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MenuArt.AsAi);
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
                            Sound.PlayTraverseSound();
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
                            Sound.PlayTraverseSound();
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
                                    Sound.PlaySelectionSound();
                                    break;

                                case 2:
                                    Sound.PlaySelectionSound();
                                    break;

                                case 3:
                                    Sound.PlaySelectionSound();
                                    InitializePlaySubMenu();
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
                            Console.WriteLine(MenuArt.JustPoChessPlayRemote);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.AsHuman);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.AsAi);
                            Console.WriteLine(MenuArt.BackText);
                            break;

                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.JustPoChessPlayRemote);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.WriteLine(MenuArt.AsHuman);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.AsAi);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.BackText);
                            break;

                        case 3:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoUpper);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(MenuArt.JustPoChessPlayRemote);

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(MenuArt.JustPoChessLogoDown);

                            Console.WriteLine();

                            Console.WriteLine(MenuArt.AsHuman);
                            Console.WriteLine(MenuArt.AsAi);
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
                            Sound.PlayTraverseSound();
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
                            Sound.PlayTraverseSound();
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
                                    Sound.PlaySelectionSound();
                                    break;

                                case 2:
                                    Sound.PlaySelectionSound();
                                    break;

                                case 3:
                                    Sound.PlaySelectionSound();
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
                            Sound.PlayTraverseSound();
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
                            Sound.PlayTraverseSound();
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
                                    Sound.PlaySelectionSound();
                                    break;

                                case 2:
                                    Sound.PlaySelectionSound();
                                    break;

                                case 3:
                                    Sound.PlaySelectionSound();
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
