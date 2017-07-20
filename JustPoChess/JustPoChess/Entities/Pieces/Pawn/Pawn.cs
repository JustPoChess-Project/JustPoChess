using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Pawn
{
    public abstract class Pawn : Piece
    {
        private readonly PieceType type = PieceType.Pawn;

        public PieceType Type
        {
            get
            {
                return this.type;
            }
        }
    }
}
