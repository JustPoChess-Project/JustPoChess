using System;
using JustPoChess.Remaster.Client.MVC.Model.Contracts;
using JustPoChess.Remaster.Client.MVC.Model.Enums;

namespace JustPoChess.Remaster.Client.MVC.Model.Pieces
{
    public class Rook : Piece
    {
        public Rook(PieceColor pieceColor, IPosition position)
            : base(pieceColor, position)
        {
        }

        public IPosition PiecePosition { get; set; }
        public PieceColor PieceColor { get; }
    }
}

