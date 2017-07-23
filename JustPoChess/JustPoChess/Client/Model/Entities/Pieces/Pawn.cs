using System;
using JustPoChess.Client.Model.Interfaces;
using JustPoChess.Client.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Client.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Client.Model.Entities.Pieces
{
    public class Pawn : IPiece, IDrawable
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
