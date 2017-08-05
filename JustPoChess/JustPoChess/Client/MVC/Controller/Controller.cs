using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.Abstract;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;
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

		public static bool MoveDiscoversCheckToOwnKing(Move move)
		{
            //think of a way of being able to perform certain moves on the board and then undo-ing them - possible solution - board not static?
			throw new System.NotImplementedException();
        }

        public static bool PieceGivesCheckToOpponentsKing(Piece piece)
		{
			throw new System.NotImplementedException();
		}

        public static List<Move> GeneratePossibleMovesForPieceWithoutConsideringDiscoveringCheck(Piece piece)
		{
			//kings can not be taken consideration!
			throw new System.NotImplementedException();
		}

		public static bool IsCurrentPlayerInCheck()
		{
            PieceColor currentPlayerPieceColor = Model.Model.currentPlayerToMove.color;
            foreach (Piece piece in Board.boardState) {
                if (piece.PieceColor != currentPlayerPieceColor && PieceGivesCheckToOpponentsKing(piece)) {
                    return true;
                }
            }
            return false;
        }

		public static List<Move> GeneratePossibleMovesForCurrentPlayer()
		{
			PieceColor currentPlayerPieceColor = Model.Model.currentPlayerToMove.color;
			List<Move> possibleMoves = new List<Move>();
            foreach (Piece piece in Board.boardState)
            {
                if (piece.PieceColor == currentPlayerPieceColor)
                {
                    possibleMoves.Concat(GeneratePossibleMovesForPieceWithoutConsideringDiscoveringCheck(piece));
                    //consider discovering check
                }
            }
            return possibleMoves;
		}

        public static bool CheckForDraw()
		{
            if ((GeneratePossibleMovesForCurrentPlayer().Count == 0 && !IsCurrentPlayerInCheck()) || CheckIfKingVsKing()) {
                return true;
            }
            return false;
		}

		public static bool CheckForCheckmate()
		{
			if (GeneratePossibleMovesForCurrentPlayer().Count == 0 && IsCurrentPlayerInCheck())
			{
				return true;
			}
			return false;
		}

        public static bool CheckIfKingVsKing() {
            foreach (Piece piece in Board.boardState) {
                if (piece.PieceType != PieceType.King) {
                    return false;
                }
            }
            return true;
        }
    }
}