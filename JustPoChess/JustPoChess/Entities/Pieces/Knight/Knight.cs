using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Knight
{
    public abstract class Knight : Piece
    {
        private readonly PieceType type = PieceType.Knight;

        public PieceType Type
        {
            get
            {
                return this.type;
            }
        }
    }
}
