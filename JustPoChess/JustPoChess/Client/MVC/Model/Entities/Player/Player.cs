using System;
using System.Collections.Generic;
using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Client.MVC.Model.Entities.Player
{
    public class Player
    {
        private PieceColor color;

        public Player()
        {
        }

        public Player(PieceColor color)
        {
            this.Color = color;
        }

        public PieceColor Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }
    }
}
