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
        private PieceColor currentPlayerToMove;
        private PieceColor currentPlayerToMoveTestBoard;

        //will need that for en passant pawn move
        private Move lastMove;
        private Move lastMoveTestBoard;

        private Model()
        {
        }

        public static Model Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Model();
                }
                return instance;
            }
        }

        public Player Player1 => this.player1;

        public Player Player2 => this.player2;

        public GameState GameState
        {
            get { return this.gameState; }
            set { this.gameState = value; }
        }

        public PieceColor CurrentPlayerToMove
        {
            get { return this.currentPlayerToMove; }
            set { this.currentPlayerToMove = value; }
        }

        public PieceColor CurrentPlayerToMoveTestBoard
        {
            get { return this.currentPlayerToMoveTestBoard; }
            set { this.currentPlayerToMoveTestBoard = value; }
        }

        public Move LastMove
        {
            get { return this.lastMove; }
            set { this.lastMove = value; }
        }

        public Move LastMoveTestBoard
        {
            get { return this.lastMoveTestBoard; }
            set { this.lastMoveTestBoard = value; }
        }

        public Board Board
        {
            get { return this.board; }
            set { this.board = value; }
        }
    }
}
