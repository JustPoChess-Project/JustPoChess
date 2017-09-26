using JustPoChess.Remaster.Client.MVC.Controller.Contracts;
using JustPoChess.Remaster.Client.MVC.Model.Contracts;
using JustPoChess.Remaster.Client.MVC.Model.Entities;
using JustPoChess.Remaster.Client.MVC.Model.Enums;
using JustPoChess.Remaster.Client.MVC.Model.Pieces;
using JustPoChess.Remaster.Client.MVC.Model.Utils;

namespace JustPoChess.Remaster.Client.MVC.Controller.Logic
{
    public class BoardLogic:IBoardLogic
    {
        private readonly IBoard board;

        public BoardLogic(IBoard board)
        {
            this.board = board;
        }


        public IBoard Board
        {
            get { return this.board; }
        }

        public void InitBoard()
        {
            this.SetPieceAtPosition(new Rook(PieceColor.Black), new Position(0, 0));
            this.SetPieceAtPosition(new Knight(PieceColor.Black), new Position(0, 1));
            this.SetPieceAtPosition(new Bishop(PieceColor.Black), new Position(0, 2));
            this.SetPieceAtPosition(new Queen(PieceColor.Black), new Position(0, 3));
            this.SetPieceAtPosition(new King(PieceColor.Black), new Position(0, 4));
            this.SetPieceAtPosition(new Bishop(PieceColor.Black), new Position(0, 5));
            this.SetPieceAtPosition(new Knight(PieceColor.Black), new Position(0, 6));
            this.SetPieceAtPosition(new Rook(PieceColor.Black), new Position(0, 7));

            for (int i = 0; i < Dimentions.BoardWidth; i++)
            {
                this.SetPieceAtPosition(new Pawn(PieceColor.Black), new Position(1, i));
            }
            
            for (int i = 0; i < Dimentions.BoardWidth; i++)
            {
                this.SetPieceAtPosition(new Pawn(PieceColor.White), new Position(6, i));
            }
            
            this.SetPieceAtPosition(new Rook(PieceColor.White), new Position(7, 0));
            this.SetPieceAtPosition(new Knight(PieceColor.White), new Position(7, 1));
            this.SetPieceAtPosition(new Bishop(PieceColor.White), new Position(7, 2));
            this.SetPieceAtPosition(new Queen(PieceColor.White), new Position(7, 3));
            this.SetPieceAtPosition(new King(PieceColor.White), new Position(7, 4));
            this.SetPieceAtPosition(new Bishop(PieceColor.White), new Position(7, 5));
            this.SetPieceAtPosition(new Knight(PieceColor.White), new Position(7, 6));
            this.SetPieceAtPosition(new Rook(PieceColor.White), new Position(7, 7));
            
            this.Board.CurrentPlayerToMove = PieceColor.White;

            //this.Board.TestState = this.BoardDeepCopy();
            //this.PositionOccurences.Add(this, 1);
        }

        private void SetPieceAtPosition(IPiece piece, IPosition position)
        {
            this.Board.State[position.Row, position.Col] = piece;
        }
    }
}