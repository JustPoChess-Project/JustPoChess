using System;
using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Client.MVC.Model.Entities.Pieces.Abstract
{
    public abstract class Piece : IPiece
    {
        private Position piecePosition;
        private PieceColor pieceColor;
        private PieceType pieceType;

        public Position PiecePosition
        {
            get
            {
                return this.piecePosition;
            }
            set
            {
                if (this.piecePosition == null)
                {
                    throw new ArgumentException($"Invalid {nameof(Piece)}");
                }
                this.piecePosition = value;
            }
        }

        public PieceColor PieceColor
        {
            get
            {
                return this.pieceColor;
            }
            protected set
            {
                if (this.pieceColor != PieceColor.Black || this.pieceColor != PieceColor.White)
                {
                    throw new ArgumentException("Invalid Color");
                }
                this.pieceColor = value;
            }
        }

        public PieceType PieceType
        {
            get
            {
                return this.pieceType;
            }
            protected set
            {
                if (this.pieceType != PieceType.Rook || this.pieceType != PieceType.Queen || this.pieceType != PieceType.Pawn || this.pieceType != PieceType.Knight || this.pieceType != PieceType.King || this.pieceType != PieceType.Bishop)
                {
                    
                }
                this.pieceType = value;
            }
        }

        public abstract void Draw();
        public abstract void Move();

        public static IPiece NewPiece(IPiece piece)
        {
            if (piece == null) 
            {
                return null;
            }
            switch (piece.PieceType)
            {
                case PieceType.King:
                    return new King(piece.PieceColor, piece.PiecePosition);
                case PieceType.Queen:
                    return new Queen(piece.PieceColor, piece.PiecePosition);
                case PieceType.Rook:
                    return new Rook(piece.PieceColor, piece.PiecePosition);
                case PieceType.Knight:
                    return new Knight(piece.PieceColor, piece.PiecePosition);
                case PieceType.Bishop:
                    return new Bishop(piece.PieceColor, piece.PiecePosition);
                case PieceType.Pawn:
                    return new Pawn(piece.PieceColor, piece.PiecePosition);
                default:
                    throw new ArgumentException("Invalid piece");
            }
        }

    }
}
