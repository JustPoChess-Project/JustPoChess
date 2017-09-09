using System.Collections.Generic;
using JustPoChess.Remaster.Client.MVC.Model.Enums;

namespace JustPoChess.Remaster.Client.MVC.Model.Contracts
{
    public interface IPlayer
    {
        PieceColor Color { get; }

        IEnumerable<IMove> History { get; }
    }
}