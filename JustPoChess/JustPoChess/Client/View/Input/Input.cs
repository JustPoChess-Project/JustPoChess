using System.Collections.Generic;
using JustPoChess.Client.Model.Entities.Board;
using System;
using System.Text.RegularExpressions;
using JustPoChess.Client.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Client.Model.Entities.Board;

namespace JustPoChess.View.Input
{
    public class Input
    {
        public Input()
        {
            
        }

        protected void ValidatexUserInput(string inputString)
        {

            string inputPattern = @"[A-H|a-h][1-8][^A-H|a-h|1-8][A-H|a-h][1-8]";
            //For manual testing
            //string matchedPattern = Regex.Match(inputString, inputPattern).ToString();
            //Console.WriteLine(matchedPattern);
            if (!Regex.IsMatch(inputString, inputPattern))
            {
                Console.WriteLine("Invalid input. Input is in format <first position> - <second position>, draw or resign");
            }
            
            switch (inputString.ToLower())
            {
                case "draw": /*TODO: Send Server request*/;  break;
                case "resign": /* TODO: Send Server request */; break;
            }


            
            /*
            Don't forget exceptions
            Possible moves: 
            -A2-A4
            -resign
            -draw (offering - other player has to accept - display drawOffer msg to the other player)
            -new game - human/ai  
            */
        }
        public void ValidateUserInput(string inputString)
        {
            string inputPattern = @"[A-H|a-h][1-8][^A-H|a-h|1-8][A-H|a-h][1-8]";
            if (!Regex.IsMatch(inputString, inputPattern))
            {
                Console.WriteLine("Invalid input. Input is in format <first position> - <second position>");
            }
        }
        public Move MovePiece(string inputString)
        {
            ValidateUserInput(inputString);
            int currentRow = inputString[0] - 'A';
            int currentCol = Board.boardSize - inputString[1] + '0';
            Position currentPosition = new Position(currentRow, currentCol);

            int nextRow = inputString[3] - 'A';
            int nextCol = Board.boardSize - inputString[4] + '0';
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
