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
        void InitBoard();
        void SetBoardState(IPiece[,] board, PieceColor color);
        void PerformMove(IMove move);
        void PerformMoveOnTestBoard(IMove move);
        IPiece[,] BoardDeepCopy();
        
        bool WhiteLeftCastlePossible { get; set; }
        bool WhiteRightCastlePossible { get; set; }
        bool BlackLeftCastlePossible { get; set; }
        bool BlackRightCastlePossible { get; set; }
        
        //why?
        void RevertTestBoardState();
    }
}