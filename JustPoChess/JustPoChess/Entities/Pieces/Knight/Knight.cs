using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustPoChess.Entities.Pieces.Knight
{
    public abstract class Knight : Piece
    {
        private readonly PieceType type = PieceType.Knight;

        public PieceType Type
        {
            get
            {
                return this.type;
            }
        }
    }
}
