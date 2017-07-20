using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Rook
{
    public abstract class Rook : Piece
    {
        protected Rook()
        {
            base.Type = PieceType.Rook;
        }
    }
}
