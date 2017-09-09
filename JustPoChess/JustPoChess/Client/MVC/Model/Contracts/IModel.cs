using JustPoChess.Client.MVC.Model.Entities.Board;

namespace JustPoChess.Client.MVC.Model.Contracts
{
    public interface IModel
    {
        GameState GameState { get; set; }
        IMove LastMove { get; set; }
        IBoard Board { get; }
    }
}