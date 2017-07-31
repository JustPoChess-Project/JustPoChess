using System;
using System.Threading;
using JustPoChess.Client.MVC.View.Input;
using JustPoChess.Client.MVC.View.Messages;

namespace JustPoChess.Client.MVC.Controller
{
    public static class Controller
    {
        public static void Start()
        {
            Console.WriteLine(Messages.FontWarrning);
            Thread.Sleep(5000);
            InputUtilities.ClearKeyBuffer();
            
            View.View.InitialScreen();
            View.View.InitializeMenu();
        }

        public static void StartHotSeat()
        {
            Model.Model.InitBoard();
            
            Console.Clear();
            View.View.StopMusic();
            View.View.PrintBoard();

            while (true)
            {
                
            }
        }
    }
}