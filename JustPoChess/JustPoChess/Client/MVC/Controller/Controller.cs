using System;
using System.Collections.Generic;
using System.Threading;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.View.Input;
using JustPoChess.Client.MVC.View.Messages;

namespace JustPoChess.Client.MVC.Controller
{
    public static class Controller
    {
        public static void Start()
        {
            Console.WriteLine(Messages.FontWarrning);
            Console.WriteLine(Messages.FontColorWarrning);
            Thread.Sleep(5000);
            InputUtilities.ClearKeyBuffer();
            
            View.View.InitialScreen();
            View.View.InitializeMenu();
        }

        public static void StartHotSeat()
        {
            Model.Model.InitBoard();
            Console.Clear();
            View.View.MirrorPrintBoard();

            while (true)
            {
                
            }
        }

		public static List<Move> GeneratePossibleMoves()
		{
			throw new System.NotImplementedException();
		}

		public static GameState CheckIfGameStillActive()
		{
			throw new System.NotImplementedException();
		}
    }
}