﻿using System;
using System.Linq;
using System.Collections.Generic;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.Abstract;
using JustPoChess.Client.MVC.OSChecker;
using JustPoChess.Client.MVC.View;


namespace JustPoChess.Client.MVC
{
    public class StartUp
    {
        public static void Main()
        {
            if (!CheckOS.IsLinux)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
            }
            Board.Instance.InitBoard();
            View.View.PrintBoard();
            Console.WriteLine(new string('*', 50));
            IEnumerable<Move> allPossibleMovesForCurrentPlayer = new List<Move>();
            foreach (Piece boardPiece in Model.Model.GetBoardState())
            {
                if (boardPiece != null && boardPiece.PieceColor == Model.Model.currentPlayerToMove)
                {
                    allPossibleMovesForCurrentPlayer = allPossibleMovesForCurrentPlayer.Concat(Controller.Controller.GeneratePossibleMovesForPieceConsideringDiscoveringCheck(boardPiece));
                }
            }
            foreach (Move m in allPossibleMovesForCurrentPlayer)
            {
                Console.WriteLine(m);
            }
            return;
            //General Program settings
            //Mandatory fuck Unix users
            Console.CursorVisible = false;
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

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
