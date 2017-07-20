using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Queen
{
    public abstract class Queen : Piece
    {
        private readonly PieceType type = PieceType.Queen;

        public PieceType Type
        {
            get
            {
                return this.type;
            }
        }
    }
}
