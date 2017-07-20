using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Pawn
{
    public abstract class Pawn : Piece
    {
        protected Pawn()
        {
            base.Type = PieceType.Pawn;
        }
    }
}
