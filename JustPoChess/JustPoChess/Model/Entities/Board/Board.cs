using System;
using System.Collections;
using JustPoChess.Model.Contracts;
using JustPoChess.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Model.Entities.Pieces.Bishop;
using JustPoChess.Model.Entities.Pieces.King;
using JustPoChess.Model.Entities.Pieces.Knight;
using JustPoChess.Model.Entities.Pieces.Pawn;
using JustPoChess.Model.Entities.Pieces.PiecesEnums;
using JustPoChess.Model.Entities.Pieces.Queen;
using JustPoChess.Model.Entities.Pieces.Rook;

namespace JustPoChess.Model.Entities.Board
{
    public class Board
    {
        private IPiece[,] boardState;

        public IPiece[,] BoardState
        {
            get
            {
                return this.boardState;
            }
            set
            {
                this.boardState = value;
            }
        }

        public void InitBoard()
        {
            BoardState = new IPiece[,]
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
        }
    }
}
