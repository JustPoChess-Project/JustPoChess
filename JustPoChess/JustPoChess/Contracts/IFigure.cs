using JustPoChess.Entities.PiecePosition;
using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Contracts
{
    public interface IFigure
    {
        Position PiecePosition { get; set; }
        PieceColor PieceColor { get; }
        PieceType PieceType { get; }
    }
}
