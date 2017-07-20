using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustPoChess.Entities.Pieces.Bishop;
using JustPoChess.Entities.Pieces.King;
using JustPoChess.Entities.Pieces.Knight;
using JustPoChess.Entities.Pieces.Pawn;
using JustPoChess.Entities.Pieces.PiecesEnums;
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
                boardState[1, y] = new BlackPawn();
                boardState[6, y] = new WhitePawn();
            }

            //initialize Rooks
            boardState[0, 0] = new BlackRook();
            boardState[0, 7] = new BlackRook();
            boardState[7, 0] = new WhiteRook();
            boardState[7, 7] = new WhiteRook();

            //initialize Knights
            boardState[0, 1] = new BlackKnight();
            boardState[0, 6] = new BlackKnight();
            boardState[7, 1] = new WhiteKnight();
            boardState[7, 6] = new WhiteKnight();

            //initialize Bishops
            boardState[0, 2] = new BlackBishop();
            boardState[0, 5] = new BlackBishop();
            boardState[7, 2] = new WhiteBishop();
            boardState[7, 5] = new WhiteBishop();

            //initialize Queens
            boardState[0, 3] = new BlackQueen();
            boardState[7, 3] = new WhiteQueen();

            //initialize Kings
            boardState[0, 4] = new BlackKing();
            boardState[7, 4] = new WhiteKing();
        }

        public void Test()
        {
            foreach (var figure in boardState)
            {
                if (figure != null && figure.Color != PieceColor.White)
                {
                    Console.WriteLine(figure.Color.ToString());
                    Console.WriteLine(figure.Type.ToString());
                }
            }
        }
    }
}
