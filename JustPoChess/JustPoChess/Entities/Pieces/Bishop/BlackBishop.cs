using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustPoChess.Entities.Pieces.Bishop
{
    public class BlackBishop : Bishop
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
    }
}
