using System;
using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Knight
{
    public class WhiteKnight : Knight
    {
        public WhiteKnight(Position.Position position)
        {
            base.Color = PieceColor.White;
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
