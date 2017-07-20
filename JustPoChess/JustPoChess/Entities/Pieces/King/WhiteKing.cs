using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustPoChess.Entities.Pieces.King
{
    public class WhiteKing : King
    {
        private readonly PieceColor color = PieceColor.White;

        public PieceColor Color
        {
            get
            {
                return this.color;
            }
        }
        
        public override void Move()
        {
            throw new NotImplementedException();
        }
        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
