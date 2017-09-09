using System;
using JustPoChess.Client.MVC.Controller;
using JustPoChess.Client.MVC.Model;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.View;
using JustPoChess.Client.MVC.View.Input;
using System.Configuration;
using System.Reflection;
using JustPoChess.Client.MVC.Controller.Contracts;
using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.View.Contracts;
using Ninject;
using Module = JustPoChess.Client.Ninject.Module;

namespace JustPoChess
{
    public class StartUp
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new Module());
            IModel model = kernel.Get<IModel>();
            IBoard board = kernel.Get<IBoard>();
            IView view = kernel.Get<IView>();
            Iinput input = kernel.Get<Iinput>();
            IController controller = kernel.Get<IController>();
            model.Board.InitBoard();
            while (true)
            {
                if (!bool.Parse(ConfigurationManager.AppSettings["IsUnix"]))
                {
                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                }
                view.PrintBoard();
                string userInput = input.GetUserInput();
                IMove move = null;
                try
                {
                    if (input.ValidateUserInput(userInput))
                    {
                        move = input.ParseMove(userInput);
                    }
                    model.Board.PerformMove(move);
                    Console.WriteLine(controller.IsPlayerInCheck(model.Board.CurrentPlayerToMove));
                    Console.WriteLine(controller.CheckForCheckmate());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
            // Board.Instance.InitBoard();
            // View.PrintBoard();
            // Console.WriteLine(new string('*', 50));
            // IEnumerable<Move> allPossibleMovesForCurrentPlayer = new List<Move>();
            // foreach (Piece boardPiece in Model.Instance.Board.BoardState)
            // {
            //     if (boardPiece != null && boardPiece.PieceColor == Model.Instance.CurrentPlayerToMove)
            //     {
            //         allPossibleMovesForCurrentPlayer = allPossibleMovesForCurrentPlayer.Concat(Controller.Instance.GeneratePossibleMovesForPieceConsideringDiscoveringCheck(boardPiece));
            //     }
            // }
            // foreach (Move m in allPossibleMovesForCurrentPlayer)
            // {
            //     Console.WriteLine(m);
            // }

            //General Program settings
            
            Console.CursorVisible = false;
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            try
            {
                //Controller.Start();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e);
            }
        }
    }
}
