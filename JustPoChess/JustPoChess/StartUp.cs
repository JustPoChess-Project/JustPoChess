using System;
using System.Linq;
using System.Collections.Generic;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.Abstract;
using JustPoChess.Client.MVC.View.Input;

namespace JustPoChess.Client.MVC
{
    public class StartUp
    {
        public static void Main()
		{
		    Console.OutputEncoding = System.Text.Encoding.UTF8;
            Board.InitBoard();
			View.View.PrintBoard();
            Console.WriteLine(new string('*', 50));
            IEnumerable<Move> allPossibleMoves = new List<Move>();
            foreach (Piece boardPiece in Model.Model.GetBoardState()) {
                allPossibleMoves = allPossibleMoves.Concat(Controller.Controller.GeneratePossibleMovesForPiece(boardPiece));
            }
            foreach (Move m in allPossibleMoves) 
            {
                Console.WriteLine(m);
            }
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
