using JustPoChess.Remaster.Client.MVC.Model.Contracts;
using JustPoChess.Remaster.Client.MVC.Model.Enums;

namespace JustPoChess.Remaster.Client.MVC.Model.Pieces
{
    public abstract class Piece : IPiece
    {
        protected Piece(PieceColor pieceColor)
        {
            this.PieceColor = pieceColor;
        }
        
        public PieceColor PieceColor { get; set; }
        public abstract PieceType PieceType { get; }
    }
}