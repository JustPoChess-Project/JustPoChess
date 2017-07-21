using System;
using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Queen
{
    public class WhiteQueen : Queen
    {
        public WhiteQueen(Position.Position position)
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
