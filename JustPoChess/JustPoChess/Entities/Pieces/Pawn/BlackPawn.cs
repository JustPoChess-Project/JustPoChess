using System;
using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Pawn
{
    public class BlackPawn : Pawn
    {
        public BlackPawn(Position.Position position)
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
