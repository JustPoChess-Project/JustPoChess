using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.Abstract;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;
using JustPoChess.Client.MVC.View.Input;
using JustPoChess.Client.MVC.View.Messages;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;

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
            PieceColor pieceColor = Board.boardState[move.CurrentPosition.Row, move.CurrentPosition.Col].PieceColor;
            Board.PerformMoveOnTestBoard(move);
            foreach (Piece boardPiece in Board.testBoardState) {
                if (boardPiece.PieceColor != pieceColor && PieceGivesCheckToOpponentsKing(boardPiece)) {
                    return true;
                }
            }
            return false;
        }

        public static bool PieceGivesCheckToOpponentsKing(Piece piece)
		{
            List<Move> possibleMoves = new List<Move>();
            possibleMoves = GeneratePossibleMovesForPiece(piece);
            foreach (Piece boardPiece in Board.boardState) {
                if (boardPiece.PieceType == PieceType.King && boardPiece.PieceColor != piece.PieceColor) {
                    foreach (Move move in possibleMoves) {
                        if (move.NextPosititon == boardPiece.PiecePosition) {
                            return true;
                        }
                    }
                }
            }
            return false;
		}

        public static List<Move> GeneratePossibleMovesForPiece(Piece piece)
		{
			List<Move> possibleMoves = new List<Move>();
            //kings can not be taken consideration!
            throw new NotImplementedException();
			//use move method in piece?
            //castle
            //an-pasan
			foreach (Move move in possibleMoves)
			{
				if (MoveDiscoversCheckToOwnKing(move))
				{
					possibleMoves.Remove(move);
				}
			}
            return possibleMoves;
		}

		public static bool IsPlayerInCheck(PieceColor pieceColor)
		{
            foreach (Piece boardPiece in Board.boardState) {
                if (boardPiece.PieceColor != pieceColor && PieceGivesCheckToOpponentsKing(boardPiece)) {
                    return true;
                }
            }
            return false;
        }

		public static List<Move> GeneratePossibleMovesForPlayer(PieceColor pieceColor)
		{
			List<Move> possibleMoves = new List<Move>();
			foreach (Piece boardPiece in Board.boardState)
            {
                if (boardPiece.PieceColor == pieceColor)
                {
                    possibleMoves.Concat(GeneratePossibleMovesForPiece(boardPiece));
                }
            }
            return possibleMoves;
		}

        public static bool CheckForDraw()
		{
            if ((GeneratePossibleMovesForPlayer(Model.Model.currentPlayerToMove.color).Count == 0 && !IsPlayerInCheck(Model.Model.currentPlayerToMove.color)) || CheckIfKingVsKing()) {
                return true;
            }
            return false;
		}

		public static bool CheckForCheckmate()
		{
			if (GeneratePossibleMovesForPlayer(Model.Model.currentPlayerToMove.color).Count == 0 && IsPlayerInCheck(Model.Model.currentPlayerToMove.color))
			{
				return true;
			}
			return false;
		}

        public static bool CheckIfKingVsKing() {
            foreach (Piece boardPiece in Board.boardState) {
                if (boardPiece.PieceType != PieceType.King) {
                    return false;
                }
            }
            return true;
        }
    }
}