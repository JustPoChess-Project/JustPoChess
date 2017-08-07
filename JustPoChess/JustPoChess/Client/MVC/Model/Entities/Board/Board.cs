using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Pieces;
using JustPoChess.Client.MVC.Model.Entities.Pieces.Abstract;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;
using System.Linq;

namespace JustPoChess.Client.MVC.Model.Entities.Board
{
    public class Board
    {
        private const int dimensions = 8;

        private const int BoardSize = dimensions;
        public IPiece[,] boardState;
        public bool whiteLeftCastlePossible = true;
        public bool whiteRightCastlePossible = true;
        public bool blackLeftCastlePossible = true;
        public bool blackRightCastlePossible = true;

        public bool whiteLeftCastlePossibleTestBoard = true;
        public bool whiteRightCastlePossibleTestBoard = true;
        public bool blackLeftCastlePossibleTestBoard = true;
        public bool blackRightCastlePossibleTestBoard = true;

        private static Board instance;

        private Board()
        {
        }

        public static Board Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new Board();
                }
                return instance;
            }
        }
        //testing purposes
        public IPiece[,] testBoardState;

        public void InitBoard()
        {
            boardState = new IPiece[,]
           {
                { new Rook(PieceColor.Black, new Position(0, 0)), new Knight(PieceColor.Black, new Position(0, 1)), new Bishop(PieceColor.Black, new Position(0, 2)), new Queen(PieceColor.Black, new Position(0, 3)), new King(PieceColor.Black, new Position(0, 4)), new Bishop(PieceColor.Black, new Position(0, 5)), new Knight(PieceColor.Black, new Position(0, 6)), new Rook(PieceColor.Black, new Position(0, 7)) },
                { new Pawn(PieceColor.Black, new Position(1, 0)), new Pawn(PieceColor.Black, new Position(1, 1)), new Pawn(PieceColor.Black, new Position(1, 2)), new Pawn(PieceColor.Black, new Position(1, 3)), new Pawn(PieceColor.Black, new Position(1, 4)), new Pawn(PieceColor.Black, new Position(1, 5)), new Pawn(PieceColor.Black, new Position(1, 6)), new Pawn(PieceColor.Black, new Position(1, 7)) },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { new Pawn(PieceColor.White, new Position(6, 0)), new Pawn(PieceColor.White, new Position(6, 1)), new Pawn(PieceColor.White, new Position(6, 2)), new Pawn(PieceColor.White, new Position(6, 3)), new Pawn(PieceColor.White, new Position(6, 4)), new Pawn(PieceColor.White, new Position(6, 5)), new Pawn(PieceColor.White, new Position(6, 6)), new Pawn(PieceColor.White, new Position(6, 7)) },
                { new Rook(PieceColor.White, new Position(7, 0)), new Knight(PieceColor.White, new Position(7, 1)), new Bishop(PieceColor.White, new Position(7, 2)), new Queen(PieceColor.White, new Position(7, 3)), new King(PieceColor.White, new Position(7, 4)), new Bishop(PieceColor.White, new Position(7, 5)), new Knight(PieceColor.White, new Position(7, 6)), new Rook(PieceColor.White, new Position(7, 7)) }
            };
            Model.currentPlayerToMove = PieceColor.White;
            Model.currentPlayerToMoveTestBoard = PieceColor.White;

            //testing purposes
            testBoardState = BoardDeepCopy();
        }

        public void RevertTestBoardState()
        {
            testBoardState = BoardDeepCopy();
            Model.currentPlayerToMoveTestBoard = Model.currentPlayerToMove;
            Model.lastMoveTestBoard = Model.lastMove;
            whiteLeftCastlePossibleTestBoard = whiteLeftCastlePossible;
            whiteRightCastlePossibleTestBoard = whiteRightCastlePossible;
            blackLeftCastlePossibleTestBoard = blackLeftCastlePossible;
            blackRightCastlePossibleTestBoard = blackRightCastlePossible;
        }

        public void PerformMove(Move move)
        {
            IPiece piece = boardState[move.CurrentPosition.Row, move.CurrentPosition.Col];
            boardState[move.CurrentPosition.Row, move.CurrentPosition.Col] = null;
            boardState[move.NextPosititon.Row, move.NextPosititon.Col] = piece;
            piece.PiecePosition = new Position(move.NextPosititon.Row, move.NextPosititon.Col);


            if (move.CurrentPosition.Row == 7)
            {
                if (move.CurrentPosition.Col == 0)
                {
                    whiteLeftCastlePossible = false;
                    whiteLeftCastlePossibleTestBoard = false;
                }
                if (move.CurrentPosition.Col == 4)
                {
                    whiteLeftCastlePossible = false;
                    whiteLeftCastlePossibleTestBoard = false;
                    whiteRightCastlePossible = false;
                    whiteRightCastlePossibleTestBoard = false;
                }
                if (move.CurrentPosition.Col == 7)
                {
                    whiteRightCastlePossible = false;
                    whiteRightCastlePossibleTestBoard = false;
                }
            }
            if (move.CurrentPosition.Row == 0)
            {
                if (move.CurrentPosition.Col == 0)
                {
                    blackLeftCastlePossible = false;
                    blackLeftCastlePossibleTestBoard = false;
                }
                if (move.CurrentPosition.Col == 4)
                {
                    blackLeftCastlePossible = false;
                    blackLeftCastlePossibleTestBoard = false;
                    blackRightCastlePossible = false;
                    blackRightCastlePossibleTestBoard = false;
                }
                if (move.CurrentPosition.Col == 7)
                {
                    blackRightCastlePossible = false;
                    blackRightCastlePossibleTestBoard = false;
                }
            }
            if (move.NextPosititon.Row == 7)
            {
                if (move.NextPosititon.Col == 0)
                {

                    whiteLeftCastlePossible = false;
                    whiteLeftCastlePossibleTestBoard = false;
                }
                if (move.NextPosititon.Col == 4)
                {
                    whiteLeftCastlePossible = false;
                    whiteLeftCastlePossibleTestBoard = false;
                    whiteRightCastlePossible = false;
                    whiteRightCastlePossibleTestBoard = false;
                }
                if (move.NextPosititon.Col == 7)
                {
                    whiteRightCastlePossible = false;
                    whiteRightCastlePossibleTestBoard = false;
                }
            }
            if (move.NextPosititon.Row == 0)
            {
                if (move.NextPosititon.Col == 0)
                {
                    blackLeftCastlePossible = false;
                    blackLeftCastlePossibleTestBoard = false;
                }
                if (move.NextPosititon.Col == 4)
                {
                    blackLeftCastlePossible = false;
                    blackLeftCastlePossibleTestBoard = false;
                    blackRightCastlePossible = false;
                    blackRightCastlePossibleTestBoard = false;
                }
                if (move.NextPosititon.Col == 7)
                {
                    blackRightCastlePossible = false;
                    blackRightCastlePossibleTestBoard = false;
                }
            }
            //will need that for en passant pawn move
            Model.lastMove = move;
            Model.lastMoveTestBoard = move;

            if (Model.currentPlayerToMove == PieceColor.White)
            {
                Model.currentPlayerToMove = PieceColor.Black;
                Model.currentPlayerToMoveTestBoard = PieceColor.Black;
            }
            if (Model.currentPlayerToMove == PieceColor.Black)
            {
                Model.currentPlayerToMove = PieceColor.White;
                Model.currentPlayerToMoveTestBoard = PieceColor.White;
            }
            //testing purposes
            testBoardState = BoardDeepCopy();
        }

        //testing purposes
        public void PerformMoveOnTestBoard(Move move)
        {
            IPiece piece = testBoardState[move.CurrentPosition.Row, move.CurrentPosition.Col];
            IPiece newPiece = Piece.NewPiece(piece);
            testBoardState[move.CurrentPosition.Row, move.CurrentPosition.Col] = null;
            testBoardState[move.NextPosititon.Row, move.NextPosititon.Col] = newPiece;
            piece.PiecePosition = new Position(move.NextPosititon.Row, move.NextPosititon.Col);
            newPiece.PiecePosition = new Position(move.NextPosititon.Row, move.NextPosititon.Col);

            if (move.CurrentPosition.Row == 7)
            {
                if (move.CurrentPosition.Col == 0)
                {
                    whiteLeftCastlePossibleTestBoard = false;
                }
                if (move.CurrentPosition.Col == 4)
                {
                    whiteLeftCastlePossibleTestBoard = false;
                    whiteRightCastlePossibleTestBoard = false;
                }
                if (move.CurrentPosition.Col == 7)
                {
                    whiteRightCastlePossibleTestBoard = false;
                }
            }
            if (move.CurrentPosition.Row == 0)
            {
                if (move.CurrentPosition.Col == 0)
                {
                    blackLeftCastlePossibleTestBoard = false;
                }
                if (move.CurrentPosition.Col == 4)
                {
                    blackLeftCastlePossibleTestBoard = false;
                    blackRightCastlePossibleTestBoard = false;
                }
                if (move.CurrentPosition.Col == 7)
                {
                    blackRightCastlePossibleTestBoard = false;
                }
            }
            if (move.NextPosititon.Row == 7)
            {
                if (move.NextPosititon.Col == 0)
                {

                    whiteLeftCastlePossibleTestBoard = false;
                }
                if (move.NextPosititon.Col == 4)
                {
                    whiteLeftCastlePossibleTestBoard = false;
                    whiteRightCastlePossibleTestBoard = false;
                }
                if (move.NextPosititon.Col == 7)
                {
                    whiteRightCastlePossibleTestBoard = false;
                }
            }
            if (move.NextPosititon.Row == 0)
            {
                if (move.NextPosititon.Col == 0)
                {
                    blackLeftCastlePossibleTestBoard = false;
                }
                if (move.NextPosititon.Col == 4)
                {
                    blackLeftCastlePossibleTestBoard = false;
                    blackRightCastlePossibleTestBoard = false;
                }
                if (move.NextPosititon.Col == 7)
                {
                    blackRightCastlePossibleTestBoard = false;
                }
            }
            Model.lastMoveTestBoard = move;
            if (Model.currentPlayerToMoveTestBoard == PieceColor.White)
            {
                Model.currentPlayerToMoveTestBoard = PieceColor.Black;
            }
            if (Model.currentPlayerToMoveTestBoard == PieceColor.Black)
            {
                Model.currentPlayerToMoveTestBoard = PieceColor.White;
            }
        }

        //testing purposes
        public IPiece[,] BoardDeepCopy()
        {
            IPiece[,] boardCopy = new IPiece[8, 8];
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (boardState[row, col] == null)
                    {
                        boardCopy[row, col] = null;
                    }
                    else
                    {
                        IPiece piece = boardState[row, col];
                        boardCopy[row, col] = Piece.NewPiece(piece);
                    }
                }
            }
            return boardCopy;
        }
    }
}
