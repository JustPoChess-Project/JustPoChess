using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.King
{
    public abstract class King : Piece
    {
        private readonly PieceType type = PieceType.King;

        public PieceType Type
        {
            get { return this.type; }
        }
    }
}
