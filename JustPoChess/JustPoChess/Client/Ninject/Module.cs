using System.Collections;
using System.Collections.Generic;
using JustPoChess.Client.MVC.Controller;
using JustPoChess.Client.MVC.Controller.Contracts;
using JustPoChess.Client.MVC.Model;
using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Client.MVC.View;
using JustPoChess.Client.MVC.View.Contracts;
using JustPoChess.Client.MVC.View.Input;
using Ninject.Modules;

namespace JustPoChess.Client.Ninject
{
    public class Module:NinjectModule
    {
        public override void Load()
        {
            this.Bind<IBoard>().To<Board>().InSingletonScope();
            this.Bind<IModel>().To<Model>().InSingletonScope();
            this.Bind<IController>().To<Controller>().InSingletonScope();
            this.Bind<IView>().To<View>().InSingletonScope();
            
            this.Bind<IMove>().To<Move>();
            this.Bind<IPosition>().To<Position>();
            
            
            this.Bind<Iinput>().To<Input>().InSingletonScope();
        }
    }
}