using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Pieces;
using JustPoChess.Client.MVC.Model.Entities.Pieces.Abstract;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;
using System.Linq;

namespace JustPoChess.Client.MVC.Model.Entities.Board
{  
    public static class Board
    {
        private const int dimensions = 8;

        private const int BoardSize = dimensions;
        public static IPiece[,] boardState;

		//testing purposes
		public static IPiece[,] testBoardState;

        public static void InitBoard()
        {
            boardState = new IPiece[,]
            {
                { new Rook(PieceColor.Black, new Position(0, 0)), new Knight(PieceColor.Black, new Position(0, 1)), new Bishop(PieceColor.Black, new Position(0, 2)), new Queen(PieceColor.Black, new Position(0, 3)), new King(PieceColor.Black, new Position(0, 4)), new Bishop(PieceColor.Black, new Position(0, 5)), new Knight(PieceColor.Black, new Position(0, 6)), new Rook(PieceColor.Black, new Position(0, 7)) }, //row 8
                { new Pawn(PieceColor.Black, new Position(1, 0)), new Pawn(PieceColor.Black, new Position(1, 1)), new Pawn(PieceColor.Black, new Position(1, 2)), new Pawn(PieceColor.Black, new Position(1, 3)), new Pawn(PieceColor.Black, new Position(1, 4)), new Pawn(PieceColor.Black, new Position(1, 5)), new Pawn(PieceColor.Black, new Position(1, 6)), new Pawn(PieceColor.Black, new Position(1, 7)) },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { new Pawn(PieceColor.White, new Position(6, 0)), new Pawn(PieceColor.White, new Position(6, 1)), new Pawn(PieceColor.White, new Position(6, 2)), new Pawn(PieceColor.White, new Position(6, 3)), new Pawn(PieceColor.White, new Position(6, 4)), new Pawn(PieceColor.White, new Position(6, 5)), new Pawn(PieceColor.White, new Position(6, 6)), new Pawn(PieceColor.White, new Position(6, 7)) },
                { new Rook(PieceColor.White, new Position(7, 0)), new Knight(PieceColor.White, new Position(7, 1)), new Bishop(PieceColor.White, new Position(7, 2)), new Queen(PieceColor.White, new Position(7, 3)), new King(PieceColor.White, new Position(7, 4)), new Bishop(PieceColor.White, new Position(7, 5)), new Knight(PieceColor.White, new Position(7, 6)), new Rook(PieceColor.White, new Position(7, 7)) }, //row 8
            };

			//testing purposes
			testBoardState = BoardDeepCopy();
        }

        public static void PerformMove(Move move) {
            IPiece piece = boardState[move.CurrentPosition.Row, move.CurrentPosition.Col];
            boardState[move.CurrentPosition.Row, move.CurrentPosition.Col] = null;
            boardState[move.NextPosititon.Row, move.NextPosititon.Col] = piece;
            piece.PiecePosition = new Position(move.NextPosititon.Row, move.NextPosititon.Col);

			//testing purposes
			testBoardState = BoardDeepCopy();
		}

		//testing purposes
		public static void PerformMoveOnTestBoard(Move move)
		{
			IPiece piece = testBoardState[move.CurrentPosition.Row, move.CurrentPosition.Col];
            IPiece newPiece = Piece.NewPiece(piece);
			testBoardState[move.CurrentPosition.Row, move.CurrentPosition.Col] = null;
			testBoardState[move.NextPosititon.Row, move.NextPosititon.Col] = newPiece;
			piece.PiecePosition = new Position(move.NextPosititon.Row, move.NextPosititon.Col);
            newPiece.PiecePosition = new Position(move.NextPosititon.Row, move.NextPosititon.Col);
		}

		//testing purposes
		public static IPiece[,] BoardDeepCopy()
        {
            IPiece[,] boardCopy = new IPiece[8, 8];
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (boardState[row, col] == null)
                    {
                        boardCopy[row, col] = null;
                    } else {
                        IPiece piece = boardState[row, col];
                        boardCopy[row, col] = Piece.NewPiece(piece);
                    }
                }
            }
            return boardCopy;
        }
	}
}
