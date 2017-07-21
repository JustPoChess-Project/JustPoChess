﻿using JustPoChess.Entities.Pieces.PiecesEnums;
using JustPoChess.Interfaces;

namespace JustPoChess.Entities
{
    public abstract class Piece : IMovable, IDrawable
    {
        private PieceType type;
        private PieceColor color;
        private Position.Position position;


        public PieceType Type
        {
            get
            {
                return this.type;
            }

            protected set
            {
                this.type = value;              
            }
        }

        public PieceColor Color
        {
            get
            {
                return this.color;               
            }

            protected set
            {
                this.color = value;              
            }
        }

        public Position.Position Position
        {
            get
            {
                return this.position;                
            }

            protected set
            {
                this.position = value;              
            }
        }

        public abstract void Draw();
        public abstract void Move();
    }
}
