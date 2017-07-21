using System;
using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Rook
{
    public class WhiteRook : Rook
    {
        public WhiteRook(Position.Position position)
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
