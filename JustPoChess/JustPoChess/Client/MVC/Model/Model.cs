using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;
using JustPoChess.Client.MVC.Model.Entities.Player;
using Ninject;

namespace JustPoChess.Client.MVC.Model
{
    public class Model : IModel
    {
        //to-do: fix all namespaces once and for all
        private readonly Player player1;
        private readonly Player player2;

        private GameState gameState;

        private IBoard board;

        //will need that for en passant pawn move

        public Model()
        {
        }

        public Player Player1 => this.player1;

        public Player Player2 => this.player2;

        public GameState GameState
        {
            get { return this.gameState; }
            set { this.gameState = value; }
        }

        public IMove LastMove { get; set; }

        public IBoard Board
        {
            get { return this.board; }
            set { this.board = value; }
        }
    }
}
