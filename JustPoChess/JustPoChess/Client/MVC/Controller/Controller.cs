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

		public static bool PieceGivesCheck(Piece piece)
		{
			throw new System.NotImplementedException();
		}

		public static List<Move> GeneratePossibleMovesForPiece(Piece piece)
		{
			throw new System.NotImplementedException();
		}

		public static bool IsCurrentPlayerInCheck()
		{
            PieceColor currentPlayerPieceColor = Model.Model.currentPlayerToMove.color;
            foreach (Piece piece in Board.boardState) {
                if (piece.PieceColor != currentPlayerPieceColor && PieceGivesCheck(piece)) {
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
                    possibleMoves.Concat(GeneratePossibleMovesForPiece(piece));
                }
            }
            return possibleMoves;
		}

        public static bool CheckForStalemate()
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