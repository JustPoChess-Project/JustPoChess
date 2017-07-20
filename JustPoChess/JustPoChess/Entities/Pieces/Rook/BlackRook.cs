using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Rook
{
    public class BlackRook : Rook
    {
        private readonly PieceColor color = PieceColor.Black;

        public PieceColor Color
        {
            get
            {
                return this.color;
            }
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public BlackRook(int x, int y)
        {
            this.Position = new Position.Position(x, y);
        }
    }
}
