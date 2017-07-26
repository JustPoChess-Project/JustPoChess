using JustPoChess.Client.Model.Entities.Board;
using JustPoChess.Client.Model.Entities.Pieces.PiecePosition;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace JustPoChess.View.Input
{
    
    public class Input
    {
        private const string validMovePattern = @"[a-h][1-8]-[a-h][1-8]";
        private const string invalidInput = "Invalid input. Input is in format <first position>-<second position>, draw or resign";
        public Input()
        {
            
        }

        protected void ValidatexUserInput(string inputString)
        {            
            
            switch (inputString.ToLower())
            {
                case "draw": /*TODO: Send other player yes/no request */;  break;
                case "resign": /* TODO: Send other player resign screen */; break;
                default: ValidateMove(inputString); break;
            }            
            
        }
        public void ValidateMove(string inputString)
        {
            Regex validateInput = new Regex(validMovePattern, RegexOptions.IgnoreCase);
            Match match = validateInput.Match(inputString);
            if (match.Success)
            {
                MovePiece(inputString);
            }
            else
            {
                Console.WriteLine(invalidInput);
            }
        }
        public Move MovePiece(string inputString)
        {
            int currentRow = inputString[0] - 'a';
            int currentCol = Board.BoardSize - inputString[1] + '0';
            Position currentPosition = new Position(currentRow, currentCol);

            int nextRow = inputString[3] - 'a';
            int nextCol = Board.BoardSize - inputString[4] + '0';
            Position nextPosition = new Position(nextRow, nextCol);

            Move move = new Move(currentPosition, nextPosition);
            return move;
        }

        public List<Move> GeneratePossibleMoves()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateBoard(Move move)
        {
            throw new System.NotImplementedException();
        }

        public GameState CheckIfGameStillActive()
        {
            throw new System.NotImplementedException();
        }
    }
}
