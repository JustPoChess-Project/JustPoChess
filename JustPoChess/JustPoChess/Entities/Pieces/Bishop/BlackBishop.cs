using System;
using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Bishop
{
    public class BlackBishop : Bishop
    {
        public BlackBishop(Position.Position position)
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
