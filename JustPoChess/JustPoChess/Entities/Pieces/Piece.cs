using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustPoChess.Interfaces;

namespace JustPoChess.Entities
{
    public abstract class Piece : IMovable, IDrawable
    {
        public enum PieceType
        {
            King = 1,
            Queen = 2,
            Rook = 3,
            Knight = 4,
            Bishop = 5,
            Pawn = 6              
        }

        public enum PieceColor
        {
            White = 0,
            Black = 1
        }

        public struct Position
        {
            private int x;
            private int y;

            public int X
            {
                get { return this.x; }
            }

            public int Y
            {
                get { return this.y; }
            }

            public Position(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public abstract void Draw();
        public abstract void Move();
    }
}
