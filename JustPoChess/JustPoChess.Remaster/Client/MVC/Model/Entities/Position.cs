using JustPoChess.Remaster.Client.MVC.Model.Contracts;

namespace JustPoChess.Remaster.Client.MVC.Model.Entities
{
    public class Position:IPosition
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}