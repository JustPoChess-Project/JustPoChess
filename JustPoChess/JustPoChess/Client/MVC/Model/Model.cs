using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Player;

namespace JustPoChess.Client.MVC.Model
{
    public static class Model
    {
		//to-do: fix all namespaces once and for all
        public readonly static Player player1;
        public readonly static Player player2;
        public static GameState gameState;
        public static Player currentPlayerToMove;
        public static Move lastMove;

		public static void InitBoard()
        {
            Board.InitBoard();
        }

        public static IPiece[,] GetBoardState()
        {
            return Board.boardState;
        }

		//testing purposes
		public static IPiece[,] GetTestBoardState()
		{
			return Board.testBoardState;
		}
    }
}
