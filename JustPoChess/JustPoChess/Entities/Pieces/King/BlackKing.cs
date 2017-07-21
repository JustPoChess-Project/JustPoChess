using System;
using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.King
{
    public class BlackKing : King
    {
        public BlackKing(Position.Position position)
        {
            base.Color = PieceColor.Black;
            base.Position = position;
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
