using System;
using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Pieces;
using JustPoChess.Client.MVC.Model.Entities.Pieces.Abstract;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Client.MVC.Model.Entities.Board
{
    public class Board
    {
        private const int BoardSize = 8;
        
        private static Board instance;
        
        private IPiece[,] boardState;
        private IPiece[,] testBoardState;

        private bool whiteLeftCastlePossible = true;
        private bool whiteRightCastlePossible = true;
        private bool blackLeftCastlePossible = true;
        private bool blackRightCastlePossible = true;

        private bool whiteLeftCastlePossibleTestBoard = true;
        private bool whiteRightCastlePossibleTestBoard = true;
        private bool blackLeftCastlePossibleTestBoard = true;
        private bool blackRightCastlePossibleTestBoard = true;

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

        public IPiece[,] BoardState
        {
            get
            {
                return this.boardState;
            }
            set
            {
//                if (value == null)
//                {
//                    throw new ArgumentNullException();
//                }
//                if (this.boardState.GetLength(0) < BoardSize || this.boardState.GetLength(0) > BoardSize )
//                {
//                    throw new ArgumentException("Invalid Move");
//                }
//                if (this.boardState.GetLength(1) < BoardSize || this.boardState.GetLength(1) > BoardSize )
//                {
//                    throw new ArgumentException("Invalid Move");
//                }
                this.boardState = value;
            }
        }

        public IPiece[,] TestBoardState
        {
            get
            {
                return this.testBoardState;
            }
            set
            {
//                if (value == null)
//                {
//                    throw new ArgumentNullException();
//                }
//                if (this.testBoardState.GetLength(0) < BoardSize || this.testBoardState.GetLength(0) > BoardSize )
//                {
//                    throw new ArgumentException("Invalid Move");
//                }
//                if (this.testBoardState.GetLength(1) < BoardSize || this.testBoardState.GetLength(1) > BoardSize )
//                {
//                    throw new ArgumentException("Invalid Move");
//                }
                this.testBoardState = value;
            }
        }

        public bool WhiteLeftCastlePossible
        {
            get
            {
                return this.whiteLeftCastlePossible;
            }
            set
            {
                this.whiteLeftCastlePossible = value;
            }
        }

        public bool WhiteRightCastlePossible
        {
            get
            {
                return this.whiteRightCastlePossible;
            }
            set
            {
                this.whiteRightCastlePossible = value;
            }
        }

        public bool BlackLeftCastlePossible
        {
            get
            {
                return this.blackLeftCastlePossible;
            }
            set
            {
                this.blackLeftCastlePossible = value;
            }
        }

        public bool BlackRightCastlePossible
        {
            get
            {
                return this.blackRightCastlePossible;
            }
            set
            {
                this.blackRightCastlePossible = value;
            }
        }

        public bool WhiteLeftCastlePossibleTestBoard
        {
            get
            {
                return this.whiteLeftCastlePossibleTestBoard;
            }
            set
            {
                this.whiteLeftCastlePossibleTestBoard = value;
            }
        }

        public bool WhiteRightCastlePossibleTestBoard
        {
            get
            {
                return this.whiteRightCastlePossibleTestBoard;
            }
            set
            {
                this.whiteRightCastlePossibleTestBoard = value;
            }
        }

        public bool BlackLeftCastlePossibleTestBoard
        {
            get
            {
                return this.blackLeftCastlePossibleTestBoard;
            }
            set
            {
                this.blackLeftCastlePossibleTestBoard = value;
            }
        }

        public bool BlackRightCastlePossibleTestBoard
        {
            get
            {
                return this.blackRightCastlePossibleTestBoard;
            }
            set
            {
                this.blackRightCastlePossibleTestBoard = value;
            }
        }

        public void InitBoard()
        {
            this.BoardState = new IPiece[,]
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

            this.testBoardState = this.BoardDeepCopy();
        }

        public void RevertTestBoardState()
        {
            this.testBoardState = this.BoardDeepCopy();
            Model.currentPlayerToMoveTestBoard = Model.currentPlayerToMove;
            Model.lastMoveTestBoard = Model.lastMove;
            this.WhiteLeftCastlePossibleTestBoard = this.WhiteLeftCastlePossible;
            this.WhiteRightCastlePossibleTestBoard = this.WhiteRightCastlePossible;
            this.BlackLeftCastlePossibleTestBoard = this.BlackLeftCastlePossible;
            this.BlackRightCastlePossibleTestBoard = this.BlackRightCastlePossible;
        }

        public void PerformMove(Move move)
        {
            IPiece piece = this.BoardState[move.CurrentPosition.Row, move.CurrentPosition.Col];
            this.BoardState[move.CurrentPosition.Row, move.CurrentPosition.Col] = null;
            this.BoardState[move.NextPosititon.Row, move.NextPosititon.Col] = piece;
            piece.PiecePosition = new Position(move.NextPosititon.Row, move.NextPosititon.Col);

            if (move.CurrentPosition.Row == 7)
            {
                if (move.CurrentPosition.Col == 0)
                {
                    this.WhiteLeftCastlePossible = false;
                    this.WhiteLeftCastlePossibleTestBoard = false;
                }
                if (move.CurrentPosition.Col == 4)
                {
                    this.WhiteLeftCastlePossible = false;
                    this.WhiteLeftCastlePossibleTestBoard = false;
                    this.WhiteRightCastlePossible = false;
                    this.WhiteRightCastlePossibleTestBoard = false;
                }
                if (move.CurrentPosition.Col == 7)
                {
                    this.WhiteRightCastlePossible = false;
                    this.WhiteRightCastlePossibleTestBoard = false;
                }
            }
            if (move.CurrentPosition.Row == 0)
            {
                if (move.CurrentPosition.Col == 0)
                {
                    this.BlackLeftCastlePossible = false;
                    this.BlackLeftCastlePossibleTestBoard = false;
                }
                if (move.CurrentPosition.Col == 4)
                {
                    this.BlackLeftCastlePossible = false;
                    this.BlackLeftCastlePossibleTestBoard = false;
                    this.BlackRightCastlePossible = false;
                    this.BlackRightCastlePossibleTestBoard = false;
                }
                if (move.CurrentPosition.Col == 7)
                {
                    this.BlackRightCastlePossible = false;
                    this.BlackRightCastlePossibleTestBoard = false;
                }
            }
            if (move.NextPosititon.Row == 7)
            {
                if (move.NextPosititon.Col == 0)
                {

                    this.WhiteLeftCastlePossible = false;
                    this.WhiteLeftCastlePossibleTestBoard = false;
                }
                if (move.NextPosititon.Col == 4)
                {
                    this.WhiteLeftCastlePossible = false;
                    this.WhiteLeftCastlePossibleTestBoard = false;
                    this.WhiteRightCastlePossible = false;
                    this.WhiteRightCastlePossibleTestBoard = false;
                }
                if (move.NextPosititon.Col == 7)
                {
                    this.WhiteRightCastlePossible = false;
                    this.WhiteRightCastlePossibleTestBoard = false;
                }
            }
            if (move.NextPosititon.Row == 0)
            {
                if (move.NextPosititon.Col == 0)
                {
                    this.BlackLeftCastlePossible = false;
                    this.BlackLeftCastlePossibleTestBoard = false;
                }
                if (move.NextPosititon.Col == 4)
                {
                    this.BlackLeftCastlePossible = false;
                    this.BlackLeftCastlePossibleTestBoard = false;
                    this.BlackRightCastlePossible = false;
                    this.BlackRightCastlePossibleTestBoard = false;
                }
                if (move.NextPosititon.Col == 7)
                {
                    this.BlackRightCastlePossible = false;
                    this.BlackRightCastlePossibleTestBoard = false;
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
            this.TestBoardState = this.BoardDeepCopy();
        }

        public void PerformMoveOnTestBoard(Move move)
        {
            IPiece piece = this.TestBoardState[move.CurrentPosition.Row, move.CurrentPosition.Col];
            IPiece newPiece = Piece.NewPiece(piece);
            this.TestBoardState[move.CurrentPosition.Row, move.CurrentPosition.Col] = null;
            this.TestBoardState[move.NextPosititon.Row, move.NextPosititon.Col] = newPiece;
            piece.PiecePosition = new Position(move.NextPosititon.Row, move.NextPosititon.Col);
            newPiece.PiecePosition = new Position(move.NextPosititon.Row, move.NextPosititon.Col);

            if (move.CurrentPosition.Row == 7)
            {
                if (move.CurrentPosition.Col == 0)
                {
                    this.WhiteLeftCastlePossibleTestBoard = false;
                }
                if (move.CurrentPosition.Col == 4)
                {
                    this.WhiteLeftCastlePossibleTestBoard = false;
                    this.WhiteRightCastlePossibleTestBoard = false;
                }
                if (move.CurrentPosition.Col == 7)
                {
                    this.WhiteRightCastlePossibleTestBoard = false;
                }
            }
            if (move.CurrentPosition.Row == 0)
            {
                if (move.CurrentPosition.Col == 0)
                {
                    this.BlackLeftCastlePossibleTestBoard = false;
                }
                if (move.CurrentPosition.Col == 4)
                {
                    this.BlackLeftCastlePossibleTestBoard = false;
                    this.BlackRightCastlePossibleTestBoard = false;
                }
                if (move.CurrentPosition.Col == 7)
                {
                    this.BlackRightCastlePossibleTestBoard = false;
                }
            }
            if (move.NextPosititon.Row == 7)
            {
                if (move.NextPosititon.Col == 0)
                {

                    this.WhiteLeftCastlePossibleTestBoard = false;
                }
                if (move.NextPosititon.Col == 4)
                {
                    this.WhiteLeftCastlePossibleTestBoard = false;
                    this.WhiteRightCastlePossibleTestBoard = false;
                }
                if (move.NextPosititon.Col == 7)
                {
                    this.WhiteRightCastlePossibleTestBoard = false;
                }
            }
            if (move.NextPosititon.Row == 0)
            {
                if (move.NextPosititon.Col == 0)
                {
                    this.BlackLeftCastlePossibleTestBoard = false;
                }
                if (move.NextPosititon.Col == 4)
                {
                    this.BlackLeftCastlePossibleTestBoard = false;
                    this.BlackRightCastlePossibleTestBoard = false;
                }
                if (move.NextPosititon.Col == 7)
                {
                    this.BlackRightCastlePossibleTestBoard = false;
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

        public IPiece[,] BoardDeepCopy()
        {
            IPiece[,] boardCopy = new IPiece[8, 8];
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (this.BoardState[row, col] == null)
                    {
                        boardCopy[row, col] = null;
                    }
                    else
                    {
                        IPiece piece = this.BoardState[row, col];
                        boardCopy[row, col] = Piece.NewPiece(piece);
                    }
                }
            }
            return boardCopy;
        }
    }
}
