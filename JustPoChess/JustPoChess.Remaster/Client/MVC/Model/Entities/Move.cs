using JustPoChess.Remaster.Client.MVC.Model.Contracts;

namespace JustPoChess.Remaster.Client.MVC.Model.Entities
{
    public class Move:IMove
    {
        public IPosition CurrentPosition { get; set; }
        public IPosition NextPosition { get; set; }
    }
}