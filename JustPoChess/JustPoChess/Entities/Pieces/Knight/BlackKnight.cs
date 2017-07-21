using System;
using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Knight
{
    public class BlackKnight : Knight
    {
        public BlackKnight(Position.Position position)
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
