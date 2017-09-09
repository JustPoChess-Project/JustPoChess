using System;
using System.Text.RegularExpressions;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Client.MVC.View.Messages;
using System.Linq;
using JustPoChess.Client.MVC.Controller.Contracts;
using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;
using JustPoChess.Client.MVC.View.Contracts;

namespace JustPoChess.Client.MVC.View.Input
{

    public class Input:Iinput
    {
        private const string validMovePattern = @"[a-hA-H][1-8]-[a-hA-H][1-8]";

        private readonly IModel model;
        private readonly IController controller;

        public Input(IModel model, IController controller)
        {
            this.model = model;
            this.controller = controller;
        }

        public IModel Model
        {
            get { return this.model; }
        }
        
        public IController Controller
        {
            get { return this.controller; }
        }

        public string GetUserInput()
        {
            return Console.ReadLine();
        }
        
        

        public bool ValidateUserInputSyntax(string inputString)
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

        public IMove ParseMove(string inputString)
        {
            if (inputString == "o-o" || inputString == "O-O")
            {
                switch (this.Model.Board.CurrentPlayerToMove)
                {
                    case PieceColor.White:
                        return new Move(new Position(7, 4), new Position(7, 6));
                    case PieceColor.Black:
                        return new Move(new Position(0, 4), new Position(0, 6));
                }
            }
            if (inputString == "o-o-o" || inputString == "O-O-O")
            {
                switch (this.Model.Board.CurrentPlayerToMove)
                {
                    case PieceColor.White:
                        return new Move(new Position(7, 4), new Position(7, 2));
                    case PieceColor.Black:
                        return new Move(new Position(0, 4), new Position(0, 2));
                }
            }
            string[] positionsStringArray = inputString.ToLower().Split('-');
            //TODO
            Position currentPosition = new Position(7 - (positionsStringArray[0].ElementAt(1) - 49), positionsStringArray[0].ElementAt(0) - 'a');
            if (model.Board.BoardState[currentPosition.Row, currentPosition.Col] == null)
            {
                throw new ArgumentException(ErrorMessage.NoPieceAtTheCurrentPosition);
            }
            Position nextPosititon = new Position(7 - (positionsStringArray[1].ElementAt(1) - 49), positionsStringArray[1].ElementAt(0) - 'a');
            
            return new Move(currentPosition, nextPosititon);
        }

        public bool ValidateUserInput(string inputString)
        {
            return
                ValidateUserInputSyntax(inputString)
                && controller.IsMovePossible(ParseMove(inputString))
                 && model.Board.CurrentPlayerToMove == model.Board.BoardState[ParseMove(inputString).CurrentPosition.Row, ParseMove(inputString).CurrentPosition.Col].PieceColor;
        }
    }
}
