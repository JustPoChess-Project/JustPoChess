using JustPoChess.Remaster.Client.MVC.Controller.Contracts;
using JustPoChess.Remaster.Client.MVC.Model.Contracts;
using JustPoChess.Remaster.Client.MVC.View.Contracts;
using JustPoChess.Remaster.Client.Ninject;
using Ninject;

namespace JustPoChess.Remaster
{
    public class StartUp
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new Module());
            IModel model = kernel.Get<IModel>();
            IBoard board = kernel.Get<IBoard>();

            IBoardLogic bl = kernel.Get<IBoardLogic>();
            bl.InitBoard();

            IDrawer drawer = kernel.Get<IDrawer>();
            drawer.Draw(board);

        }
    }
}
