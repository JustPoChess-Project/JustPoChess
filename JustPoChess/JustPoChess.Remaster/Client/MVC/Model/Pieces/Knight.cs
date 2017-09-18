using System;
using JustPoChess.Remaster.Client.MVC.Model.Contracts;
using JustPoChess.Remaster.Client.MVC.Model.Enums;

namespace JustPoChess.Remaster.Client.MVC.Model.Pieces
{
    public class Knight : Piece
    {
        public Knight(PieceColor pieceColor, IPosition position)
            :base(pieceColor, position)
        {
        }
        
        public override PieceType PieceType
        {
            get
            {
                return PieceType.Knight;
            }
        }
    }
}