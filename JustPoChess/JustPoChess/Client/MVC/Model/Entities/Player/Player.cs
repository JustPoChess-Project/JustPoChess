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
    }
}
