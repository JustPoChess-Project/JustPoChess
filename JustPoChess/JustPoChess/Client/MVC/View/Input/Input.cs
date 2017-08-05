using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;
using System.Linq;

namespace JustPoChess.Client.MVC.View.Input
{
    
    public static class Input
    {
        private const string validMovePattern = @"[a-hA-H][1-8]-[a-hA-H][1-8]";
        private const string invalidInput = "Invalid input. Input is in format <first position>-<second position>, draw or resign";

        public static string GetUserInput() {
            return Console.ReadLine();
        }

        public static bool ValidateUserInput(string inputString)
        {
            switch (inputString.ToLower())
            {
                case "draw":
                case "resign":
                    return true;
                default:
                    Regex validateInput = new Regex(validMovePattern, RegexOptions.IgnoreCase);
                    Match match = validateInput.Match(inputString);
                    if (match.Success)
                    {
                        return true;
                    }
                    throw new ArgumentException(invalidInput);
            }
        }

        public static Move ParseMove(string inputString) {
			string[] positionsStringArray = inputString.ToLower().Split('-');
            Position currentPosition = new Position(7 - (positionsStringArray[0].ElementAt(1) - 49), positionsStringArray[0].ElementAt(0) - 'a');
            Position nextPosititon = new Position(7 - (positionsStringArray[1].ElementAt(1) - 49), positionsStringArray[1].ElementAt(0) - 'a');
            return new Move(currentPosition, nextPosititon);
        }
    }
}
