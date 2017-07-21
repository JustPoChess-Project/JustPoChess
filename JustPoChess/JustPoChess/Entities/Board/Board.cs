using System;
using JustPoChess.Entities.Pieces.Bishop;
using JustPoChess.Entities.Pieces.King;
using JustPoChess.Entities.Pieces.Knight;
using JustPoChess.Entities.Pieces.Pawn;
using JustPoChess.Entities.Pieces.Queen;
using JustPoChess.Entities.Pieces.Rook;

namespace JustPoChess.Entities.Board
{
    public class Board
    {
        private Piece[,] boardState;

        public Piece[,] BoardState
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
            BoardState = new Piece[,]
            {
                { new BlackRook(), new BlackKnight(), new BlackBishop(), new BlackQueen(), new BlackKing(), new BlackBishop(), new BlackKnight(), new BlackRook() }, //Row 8
                { new BlackPawn(), new BlackPawn(), new BlackPawn(), new BlackPawn(), new BlackPawn(), new BlackPawn(), new BlackPawn(), new BlackPawn() },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { new WhitePawn(), new WhitePawn(), new WhitePawn(), new WhitePawn(), new WhitePawn(), new WhitePawn(), new WhitePawn(), new WhitePawn() },
                { new WhiteRook(), new WhiteKnight(), new WhiteBishop(), new WhiteQueen(), new WhiteKing(), new WhiteBishop(), new WhiteKnight(), new WhiteRook() } //Row 1
            };
        }
    }
}
