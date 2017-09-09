using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Client.MVC.Controller.BoardLogic.Contracts
{
    public interface IBoardLogic
    {
        void InitBoard();
        void SetBoardState(IPiece[,] board, PieceColor color);
        void PerformMove(IMove move);
        void PerformMoveOnTestBoard(IMove move);
        IPiece[,] BoardDeepCopy();
        void RevertTestBoardState();
    }
}