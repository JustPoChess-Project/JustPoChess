using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Knight
{
    public abstract class Knight : Piece
    {
        protected Knight()
        {
            base.Type = PieceType.Knight;
        }
    }
}
