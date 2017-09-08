using System;
using System.Text.RegularExpressions;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Client.MVC.View.Messages;
using System.Linq;

namespace JustPoChess.Client.MVC.View.Input
{

    public static class Input
    {
        private const string validMovePattern = @"[a-hA-H][1-8]-[a-hA-H][1-8]";


        public static string GetUserInput()
        {
            return Console.ReadLine();
        }

        public static bool ValidateUserInputSyntax(string inputString)
        {
            switch (inputString.ToLower())
            {
                case "draw":
                case "resign":
                case "O-O":
                case "o-o":
                case "O-O-O":
                case "o-o-o":
                    return true;
                default:
                    Regex validateInput = new Regex(validMovePattern, RegexOptions.IgnoreCase);
                    Match match = validateInput.Match(inputString);
                    if (match.Success)
                    {
                        return true;
                    }
                    throw new ArgumentException(ErrorMessage.InvalidUserInputMessage);
            }

        }

        public static Move ParseMove(string inputString)
        {
            if (inputString == "o-o" || inputString == "O-O")
            {
                switch (View.Model.Board.CurrentPlayerToMove)
                {
                    case Model.Entities.Pieces.PiecesEnums.PieceColor.White:
                        return new Move(new Position(7, 4), new Position(7, 6));
                    case Model.Entities.Pieces.PiecesEnums.PieceColor.Black:
                        return new Move(new Position(0, 4), new Position(0, 6));
                }
            }
            if (inputString == "o-o-o" || inputString == "O-O-O")
            {
                switch (View.Model.Board.CurrentPlayerToMove)
                {
                    case Model.Entities.Pieces.PiecesEnums.PieceColor.White:
                        return new Move(new Position(7, 4), new Position(7, 2));
                    case Model.Entities.Pieces.PiecesEnums.PieceColor.Black:
                        return new Move(new Position(0, 4), new Position(0, 2));
                }
            }
            string[] positionsStringArray = inputString.ToLower().Split('-');
            Position currentPosition = new Position(7 - (positionsStringArray[0].ElementAt(1) - 49), positionsStringArray[0].ElementAt(0) - 'a');
            Position nextPosititon = new Position(7 - (positionsStringArray[1].ElementAt(1) - 49), positionsStringArray[1].ElementAt(0) - 'a');
            return new Move(currentPosition, nextPosititon);
        }

        public static bool ValidateUserInput(string inputString)
        {
            return
                ValidateUserInputSyntax(inputString)
                && Controller.Controller.Instance.IsMovePossible(ParseMove(inputString))
                 && Model.Model.Instance.Board.CurrentPlayerToMove == Board.Instance.BoardState[ParseMove(inputString).CurrentPosition.Row, ParseMove(inputString).CurrentPosition.Col].PieceColor;
        }
    }
}
