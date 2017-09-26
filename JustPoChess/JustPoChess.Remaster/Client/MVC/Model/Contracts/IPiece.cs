using JustPoChess.Remaster.Client.MVC.Model.Enums;

namespace JustPoChess.Remaster.Client.MVC.Model.Contracts
{
    public interface IPiece
    {
        PieceColor PieceColor { get; }
        PieceType PieceType { get; }
    }
}