using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;
using JustPoChess.Client.MVC.Model.Entities.Player;

namespace JustPoChess.Client.MVC.Model
{
    public class Model
    {
        private static Model instance;
        
        private Board board = Board.Instance;
        
        //to-do: fix all namespaces once and for all
        private readonly Player player1;
        private readonly Player player2;

        private GameState gameState;

        //will need that for en passant pawn move
        private Move lastMove;

        private Model()
        {
        }

        public static Model Instance
        {
            get
            {
                return instance ?? (instance = new Model());
            }
        }

        public Player Player1 => this.player1;

        public Player Player2 => this.player2;

        public GameState GameState
        {
            get { return this.gameState; }
            set { this.gameState = value; }
        }

        public Move LastMove
        {
            get { return this.lastMove; }
            set { this.lastMove = value; }
        }

        public Board Board
        {
            get { return this.board; }
            set { this.board = value; }
        }
    }
}
