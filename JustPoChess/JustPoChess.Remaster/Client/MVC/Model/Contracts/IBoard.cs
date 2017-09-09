using System.Collections;
using System.Collections.Generic;
using JustPoChess.Remaster.Client.MVC.Model.Enums;

namespace JustPoChess.Remaster.Client.MVC.Model.Contracts
{
    public interface IBoard
    {
        IPiece[,] BoardState { get; set; }
        IPiece[,] TestBoardState { get; set; }
        IDictionary<IBoard, int> PositionOccurences { get; }
        PieceColor CurrentPlayerToMove { get; set; }

        bool WhiteLeftCastlePossible { get; set; }
        bool WhiteRightCastlePossible { get; set; }
        bool BlackLeftCastlePossible { get; set; }
        bool BlackRightCastlePossible { get; set; }
    }
}