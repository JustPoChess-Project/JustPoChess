using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Rook
{
    public abstract class Rook : Piece
    {
        private readonly PieceType type = PieceType.Rook;

        public PieceType Type
        {
            get
            {
                return this.type;
            }
        }
    }
}
