using JustPoChess.Remaster.Client.MVC.Controller;
using JustPoChess.Remaster.Client.MVC.Controller.Contracts;
using JustPoChess.Remaster.Client.MVC.Controller.Logic;
using JustPoChess.Remaster.Client.MVC.Model;
using JustPoChess.Remaster.Client.MVC.Model.Contracts;
using JustPoChess.Remaster.Client.MVC.Model.Entities;
using JustPoChess.Remaster.Client.MVC.Model.Pieces;
using JustPoChess.Remaster.Client.MVC.View;
using JustPoChess.Remaster.Client.MVC.View.ConsoleClient;
using JustPoChess.Remaster.Client.MVC.View.Contracts;
using Ninject.Modules;

namespace JustPoChess.Remaster.Client.Ninject
{
    public class Module:NinjectModule
    {
        public override void Load()
        {
            this.Bind<IPosition>().To<Position>();
            this.Bind<IMove>().To<Move>();
            this.Bind<IBoard>().To<Board>().InSingletonScope();
            this.Bind<IPiece>().To<Piece>();
            this.Bind<IPlayer>().To<Player>();
            this.Bind<IModel>().To<Model>().InSingletonScope();

            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IDrawer>().To<ConsoleDrawer>();
            this.Bind<IView>().To<View>();

            this.Bind<IBoardLogic>().To<BoardLogic>().InSingletonScope();
            this.Bind<IController>().To<Controller>();
        }
    }
}