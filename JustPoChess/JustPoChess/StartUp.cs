using System;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.View.Input;

namespace JustPoChess.Client.MVC
{
    public class StartUp
    {
        public static void Main()
		{
            Board.InitBoard();
            string input = Input.GetUserInput();
            Input.ValidateUserInput(input);
            Move move = Input.ParseMove(input);
			View.View.PrintBoard();
			Board.PerformMove(move);
			View.View.PrintBoard();
			View.View.PrintTestBoard();
            Console.WriteLine(new string('*', 50));

            string input2 = Input.GetUserInput();
			Input.ValidateUserInput(input2);
			Move move2 = Input.ParseMove(input2);
            View.View.PrintTestBoard();
			Board.PerformMoveOnTestBoard(move2);
			View.View.PrintBoard();
			View.View.PrintTestBoard();
            return;
            //General Program settings
            //Mandatory fuck Unix users
            Console.CursorVisible = false;
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            try
            {
                Controller.Controller.Start();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e);
            }
        }
    }
}
