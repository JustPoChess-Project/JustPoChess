using System.Collections.Generic;
using JustPoChess.Remaster.Client.MVC.Model.Contracts;
using JustPoChess.Remaster.Client.MVC.Model.Enums;

namespace JustPoChess.Remaster.Client.MVC.Model.Entities
{
    public class Player:IPlayer
    {
        public PieceColor Color { get; }
        public IEnumerable<IMove> History { get; }
    }
}