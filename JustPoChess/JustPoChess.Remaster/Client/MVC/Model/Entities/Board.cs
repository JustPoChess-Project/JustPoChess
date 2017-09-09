using System.Collections.Generic;
using JustPoChess.Remaster.Client.MVC.Model.Contracts;
using JustPoChess.Remaster.Client.MVC.Model.Enums;

namespace JustPoChess.Remaster.Client.MVC.Model.Entities
{
    public class Board : IBoard
    {
        public IPiece[,] BoardState { get; set; }
        public IPiece[,] TestBoardState { get; set; }
        public IDictionary<IBoard, int> PositionOccurences { get; }
        public PieceColor CurrentPlayerToMove { get; set; }

        public bool WhiteLeftCastlePossible { get; set; } = true;
        public bool WhiteRightCastlePossible { get; set; } = true;
        public bool BlackLeftCastlePossible { get; set; } = true;
        public bool BlackRightCastlePossible { get; set; } = true;
    }
}