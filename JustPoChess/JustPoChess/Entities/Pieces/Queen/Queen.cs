using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Queen
{
    public abstract class Queen : Piece
    {
        private readonly PieceType type = PieceType.Queen;

        public PieceType Type
        {
            get
            {
                return this.type;
            }
        }
    }
}
