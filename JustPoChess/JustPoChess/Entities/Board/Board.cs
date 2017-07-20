using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            boardState = new Piece[8,8];

            //initializes pawns
            for (int y = 0; y < 8; y++)
            {
                boardState[1, y]; //to do: = new blackpawn
                boardState[6, y]; //to do: = new whitepawn` `
            }
        }
    }
}
