using JustPoChess.Remaster.Client.MVC.Model.Contracts;
using JustPoChess.Remaster.Client.MVC.Model.Enums;

namespace JustPoChess.Remaster.Client.MVC.Model.Pieces
{
    public abstract class Piece : IPiece
    {
        protected Piece(PieceColor pieceColor, IPosition position)
        {
            this.PieceColor = pieceColor;
            this.PiecePosition = position;
        }
        
        public IPosition PiecePosition { get; set; }
        public PieceColor PieceColor { get; set; }
        public abstract PieceType PieceType { get; }
    }
}