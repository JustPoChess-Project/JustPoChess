using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Player;

namespace JustPoChess.Client.MVC.Model
{
    public static  class Model
    {
        public static void InitBoard()
        {
            Board.InitBoard();
        }

        public static IPiece[,] GetBoardState()
        {
            return Board.BoardState;
        }
    }
}
