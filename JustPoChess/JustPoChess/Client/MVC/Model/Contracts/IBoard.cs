using System.Collections;
using System.Collections.Generic;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Client.MVC.Model.Contracts
{
    public interface IBoard
    {
        PieceColor CurrentPlayerToMove { get; set; }
        IDictionary<IBoard, int> PositionOccurences { get; }
        IPiece[,] BoardState { get; set; }
        IPiece[,] TestBoardState { get; set; }
        
        bool WhiteLeftCastlePossible { get; set; }
        bool WhiteRightCastlePossible { get; set; }
        bool BlackLeftCastlePossible { get; set; }
        bool BlackRightCastlePossible { get; set; }
        
        void InitBoard();
        void SetBoardState(IPiece[,] state, PieceColor color);
        void PerformMove(IModel model, IMove move);
        void PerformMoveOnTestBoard(IMove move);
        IPiece[,] BoardDeepCopy();
        void RevertTestBoardState();
    }
}