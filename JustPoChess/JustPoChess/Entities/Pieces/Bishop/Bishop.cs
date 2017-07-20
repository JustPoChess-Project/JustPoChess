using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Bishop
{
    public abstract class Bishop : Piece
    {
        private readonly PieceType type = PieceType.Bishop;

        public PieceType Type
        {
            get
            {
                return this.type;
            }
        }
    }
}
