using JustPoChess.Client.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Client.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Client.Model.Interfaces
{
    public interface IPiece
    {
        Position PiecePosition { get; set; }
        PieceColor PieceColor { get; }
        PieceType PieceType { get; }
    }
}
