using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustPoChess.Entities.Pieces.Bishop
{
    public abstract class Bishop : Piece
    {
        private readonly PieceType type = PieceType.Bishop;

        public PieceType Type
        {
            get
            {
                return this.type;
            }
        }
    }
}
