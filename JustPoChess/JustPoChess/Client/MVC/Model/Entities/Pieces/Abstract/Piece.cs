using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Client.MVC.Model.Entities.Pieces.Abstract
{
    public abstract class Piece : IPiece
    {
        private Position piecePosition;
        private  PieceColor pieceColor;
        private  PieceType pieceType;

        public Position PiecePosition
        {
            get { return this.piecePosition; }
            set { this.piecePosition = value; }
        }

        public PieceColor PieceColor
        {
            get { return this.pieceColor; }
            protected set { this.pieceColor = value; }
        }
         
        public PieceType PieceType
        {
            get { return this.pieceType; }
            protected set { this.pieceType = value; }
        }

        public abstract void Draw();
        public abstract void Move();
    }
}
