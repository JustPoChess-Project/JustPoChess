using System;
using System.Collections.Generic;
using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Client.MVC.Model.Entities.Player
{
    public class Player
    {
        private string name;
        private PieceColor color;
        private List<IPiece> takenPieces;

        public Player()
        {
        }

        public Player(string name, PieceColor color)
        {
            this.Name = name;
            this.Color = color;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(this.name))
                {
                    throw new ArgumentException("Invalid name");
                }
                this.name = value;
            }
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

        public List<IPiece> TakenPieces
        {
            get
            {
                return this.takenPieces;
            }
            set
            {
                this.takenPieces = value;
            }
        }
    }
}
