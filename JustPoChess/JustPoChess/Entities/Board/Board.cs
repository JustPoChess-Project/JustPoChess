using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        public Board()
        {
            boardState = new Piece[8, 8];

            //initializes Pawns
            for (int y = 0; y < 8; y++)
            {
                boardState[1, y] = new BlackPawn(1, y);
                boardState[6, y] = new WhitePawn(6, y);
            }

            //initialize Rooks
            boardState[0, 0] = new BlackRook(0, 0);
            boardState[0, 7] = new BlackRook(0, 7);
            boardState[7, 0] = new WhiteRook(7, 0);
            boardState[7, 7] = new WhiteRook(7, 7);

            //initialize Knights
            boardState[0, 1] = new BlackKnight(0, 1);
            boardState[0, 6] = new BlackKnight(0, 6);
            boardState[7, 1] = new WhiteKnight(7, 1);
            boardState[7, 6] = new WhiteKnight(7, 6);

            //initialize Bishops
            boardState[0, 2] = new BlackBishop(0, 2);
            boardState[0, 5] = new BlackBishop(0, 5);
            boardState[7, 2] = new WhiteBishop(7, 2);
            boardState[7, 5] = new WhiteBishop(7, 5);

            //initialize Queens
            boardState[0, 3] = new BlackQueen(0, 3);
            boardState[7, 3] = new WhiteQueen(7, 3);

            //initialize Kings
            boardState[0, 4] = new BlackKing(0, 4);
            boardState[7, 4] = new BlackKing(7, 4);
        }
    }
}
