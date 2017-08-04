using System.Collections.Generic;
using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Client.MVC.Model.Entities.Player
{
    public class Player
    {
        public string name;
        public PieceColor color;
        public List<IPiece> takenPieces;

        public Player()
        {
        }
    }
}
