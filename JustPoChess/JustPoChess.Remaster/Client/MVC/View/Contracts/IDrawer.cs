using JustPoChess.Remaster.Client.MVC.Model.Contracts;

namespace JustPoChess.Remaster.Client.MVC.View.Contracts
{
    public interface IDrawer
    {
        void Draw(IBoard board);
    }
}