using System;
using JustPoChess.Entities.Pieces.Bishop;
using JustPoChess.Entities.Pieces.King;
using JustPoChess.Entities.Pieces.Knight;
using JustPoChess.Entities.Pieces.Pawn;
using JustPoChess.Entities.Pieces.Queen;
using JustPoChess.Entities.Pieces.Rook;
using JustPoChess.Entities.Position;

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
                { new BlackRook(new Position.Position(7, 0)), new BlackKnight(new Position.Position(7, 1)), new BlackBishop(new Position.Position(7, 2)), new BlackQueen(new Position.Position(7, 3)), new BlackKing(new Position.Position(7, 4)), new BlackBishop(new Position.Position(7, 5)), new BlackKnight(new Position.Position(7, 6)), new BlackRook(new Position.Position(7, 7)) }, //Row 8
                { new BlackPawn(new Position.Position(6, 0)), new BlackPawn(new Position.Position(6, 1)), new BlackPawn(new Position.Position(6, 2)), new BlackPawn(new Position.Position(6, 3)), new BlackPawn(new Position.Position(6, 4)), new BlackPawn(new Position.Position(6, 5)), new BlackPawn(new Position.Position(6, 6)), new BlackPawn(new Position.Position(6, 7)) },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { new WhitePawn(new Position.Position(1, 0)), new WhitePawn(new Position.Position(1, 1)), new WhitePawn(new Position.Position(1, 2)), new WhitePawn(new Position.Position(1, 3)), new WhitePawn(new Position.Position(1, 4)), new WhitePawn(new Position.Position(1, 5)), new WhitePawn(new Position.Position(1, 6)), new WhitePawn(new Position.Position(1, 7)) },
                { new WhiteRook(new Position.Position(0, 0)), new WhiteKnight(new Position.Position(0, 1)), new WhiteBishop(new Position.Position(0, 2)), new WhiteQueen(new Position.Position(0, 3)), new WhiteKing(new Position.Position(0, 4)), new WhiteBishop(new Position.Position(0, 5)), new WhiteKnight(new Position.Position(0, 6)), new WhiteRook(new Position.Position(0, 7)) } //Row 1
            };
        }
    }
}
