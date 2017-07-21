using JustPoChess.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Model.Contracts
{
    public interface IPiece
    {
        Position PiecePosition { get; set; }
        PieceColor PieceColor { get; }
        PieceType PieceType { get; }
    }
}
