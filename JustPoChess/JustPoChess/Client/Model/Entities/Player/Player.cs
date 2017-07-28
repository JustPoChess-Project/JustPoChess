using System.Collections.Generic;
using JustPoChess.Client.Model.Contracts;
using JustPoChess.Client.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Client.Model.Entities.Player
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
