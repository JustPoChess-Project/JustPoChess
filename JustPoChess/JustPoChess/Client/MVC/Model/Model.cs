using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;
using JustPoChess.Client.MVC.Model.Entities.Player;

namespace JustPoChess.Client.MVC.Model
{
    public static class Model
    {
        //to-do: fix all namespaces once and for all
        public readonly static Player player1;
        public readonly static Player player2;
        public static GameState gameState;

        public static PieceColor currentPlayerToMove;
        public static PieceColor currentPlayerToMoveTestBoard;

        //will need that for en passant pawn move
        public static Move lastMove;
        public static Move lastMoveTestBoard;

        public static void InitBoard()
        {
            Board.Instance.InitBoard();
        }

        public static IPiece[,] GetBoardState()
        {
            return Board.Instance.boardState;
        }

        //testing purposes
        public static IPiece[,] GetTestBoardState()
        {
            return Board.Instance.testBoardState;
        }
    }
}
