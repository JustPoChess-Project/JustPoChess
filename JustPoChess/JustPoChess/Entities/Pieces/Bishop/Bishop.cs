using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Bishop
{
    public abstract class Bishop : Piece
    {
        protected Bishop()
        {
            base.Type = PieceType.Bishop;
        }
    }
}
