using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Client.MVC.Model.Contracts
{
    public interface IPiece
    {
        Position PiecePosition { get; set; }
        PieceColor PieceColor { get; }
        PieceType PieceType { get;  }

        void Draw();
        void Move();
    }
}
