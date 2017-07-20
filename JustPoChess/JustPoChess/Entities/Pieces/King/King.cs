using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.King
{
    public abstract class King : Piece
    {
        protected King()
        {
            base.Type = PieceType.King;
        }
    }
}
