using JustPoChess.Remaster.Client.MVC.Model.Contracts;

namespace JustPoChess.Remaster.Client.MVC.Controller.Contracts
{
    public interface IBoardLogic
    {
        IBoard Board { get; }
        
        void InitBoard();
    }
}