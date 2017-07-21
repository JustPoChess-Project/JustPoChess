using System;
using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.King
{
    public class WhiteKing : King
    {
        public WhiteKing(Position.Position position)
        {
            base.Color = PieceColor.White;
            base.Position = position;
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
