using System;
using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.King
{
    public class WhiteKing : King
    {
        public WhiteKing()
        {
            base.Color = PieceColor.White;
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
