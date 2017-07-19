using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustPoChess.Entities.Pieces.Pawn
{
    public abstract class Pawn : Piece
    {
        private readonly PieceType type = PieceType.Pawn;

        public PieceType Type
        {
            get
            {
                return this.type;
            }
        }
    }
}
