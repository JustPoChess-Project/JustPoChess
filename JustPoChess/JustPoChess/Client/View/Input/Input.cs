using JustPoChess.Client.Model.Entities.Board;
using JustPoChess.Client.Model.Entities.Pieces.PiecePosition;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace JustPoChess.View.Input
{
    
    public class Input
    {
        private const string validMovePattern = @"[A-H|a-h][1-8][^A-H|a-h|1-8][A-H|a-h][1-8]";
        private const string validDrawPattern = @"^[dD][rR][aA][wW]$";
        private const string validResignPattern = @"^[rR][eE][sS][iI][gG][nN]$";
        private const string invalidInput = "Invalid input. Input must be in format <first position>-<second position>, draw or resign";


        public Input()
        {
            
        }

        protected void ValidatexUserInput(string inputString)
        {

            if (Regex.IsMatch(inputString, validDrawPattern))
            {
                // Send other player resign screen
            }
            else if (Regex.IsMatch(inputString, validResignPattern))
            {
                // Send other player yes/no requst
            }
            else if (Regex.IsMatch(inputString, validMovePattern))
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
            int currentRow = inputString[0] - 'A';
            int currentCol = Board.BoardSize - inputString[1] + '0';
            Position currentPosition = new Position(currentRow, currentCol);

            int nextRow = inputString[3] - 'A';
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
