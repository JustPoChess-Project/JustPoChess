using System;
using JustPoChess.Client.MVC.Model.Entities.Pieces.Abstract;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Client.MVC.Model.Entities.Pieces
{
    public class Knight : Piece
    {
        public Knight(PieceColor pieceColor, Position position)
        {
            base.PieceType = PieceType.Knight;
            base.PieceColor = pieceColor;
            base.PiecePosition = position;
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}