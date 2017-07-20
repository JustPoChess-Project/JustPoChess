using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Queen
{
    public abstract class Queen : Piece
    {
        protected Queen()
        {
            base.Type = PieceType.Queen;
        }
    }
}
