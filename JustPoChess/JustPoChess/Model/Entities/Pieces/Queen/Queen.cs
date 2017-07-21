using System;
using JustPoChess.Model.Contracts;
using JustPoChess.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Model.Entities.Pieces.Queen
{
    public class Queen : IPiece, IMovable, IDrawable
    {
        private readonly PieceType pieceType = PieceType.Queen;
        private PieceColor pieceColor;
        private Position piecePosition;

        public PieceType PieceType
        {
            get
            {
                return this.pieceType;
            }
        }

        public PieceColor PieceColor
        {
            get
            {
                return this.pieceColor;
            }
        }

        public Position PiecePosition
        {
            get
            {
                return this.piecePosition;
            }
            set
            {
                this.piecePosition = value;
            }
        }

        public Queen(PieceColor pieceColor, Position position)
        {
            this.pieceColor = pieceColor;
            this.piecePosition = position;
        }


        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
