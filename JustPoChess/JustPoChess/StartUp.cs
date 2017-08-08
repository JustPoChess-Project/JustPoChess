using System;
using System.Linq;
using System.Collections.Generic;
using JustPoChess.Client.MVC.Controller;
using JustPoChess.Client.MVC.Model;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.Abstract;
using JustPoChess.Client.MVC.OSChecker;
using JustPoChess.Client.MVC.View;
using JustPoChess.Client.MVC.View.Input;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Client.MVC.View.Sounds;

namespace JustPoChess
{
    public class StartUp
    {
        public static void Main()
        {
            Board.Instance.InitBoard();
            while (true)
            {
                View.PrintBoard();
                string userInput = Input.GetUserInput();
                Move move = null;
                if (Input.ValidateUserInput(userInput)) {
                    move = Input.ParseMove(userInput);
                }
                Model.Instance.Board.PerformMove(move);
                Console.WriteLine(Controller.IsPlayerInCheck(Board.Instance.CurrentPlayerToMove));
                Console.WriteLine(Controller.Instance.CheckForCheckmate());
            }
            // Board.Instance.InitBoard();
            // View.PrintBoard();
            // Console.WriteLine(new string('*', 50));
            // IEnumerable<Move> allPossibleMovesForCurrentPlayer = new List<Move>();
            // foreach (Piece boardPiece in Model.Instance.Board.BoardState)
            // {
            //     if (boardPiece != null && boardPiece.PieceColor == Model.Instance.CurrentPlayerToMove)
            //     {
            //         allPossibleMovesForCurrentPlayer = allPossibleMovesForCurrentPlayer.Concat(Controller.Instance.GeneratePossibleMovesForPieceConsideringDiscoveringCheck(boardPiece));
            //     }
            // }
            // foreach (Move m in allPossibleMovesForCurrentPlayer)
            // {
            //     Console.WriteLine(m);
            // }

            //General Program settings
            if (!CheckOS.IsLinux)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
            }
            Console.CursorVisible = false;
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            try
            {
                Controller.Start();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e);
            }
        }
    }
}
