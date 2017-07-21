using System;
using JustPoChess.Entities.PiecePosition;
using JustPoChess.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Entities.Pieces.Pawn
{
    public class Pawn
    {
        private readonly PieceType pieceType = PieceType.Pawn;
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

        public Pawn(PieceColor pieceColor, Position position)
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
