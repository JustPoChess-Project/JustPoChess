using System;
using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Pawn
{
    public class WhitePawn : Pawn
    {
        public WhitePawn(Position.Position position)
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
