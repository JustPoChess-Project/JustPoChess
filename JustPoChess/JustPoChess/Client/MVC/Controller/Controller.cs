using System;
using System.Linq;
using System.Collections.Generic;
using JustPoChess.Client.MVC.Controller.Contracts;
using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.View.Input;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.Abstract;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Client.MVC.View.Contracts;

namespace JustPoChess.Client.MVC.Controller
{
    public class Controller:IController
    {
        private readonly IModel model;
        private readonly IView view;

        public Controller(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
        }

        public IModel Model
        {
            get { return this.model; }
        }
        
        public IView View
        {
            get { return this.view; }
        }

        public void Start()
        {
            InputUtilities.ClearKeyBuffer();

            this.View.InitialScreen();
            this.View.InitializeMenu();
        }

        public bool IsMovePossible(IMove move)
        {
            IEnumerable<IMove> possibleMoves = this.GeneratePossibleMovesForPlayer(this.Model.Board.BoardState[move.CurrentPosition.Row, move.CurrentPosition.Col].PieceColor);
            return possibleMoves.Contains(move);
        }

        public bool MoveDiscoversCheckToOwnKing(IMove move)
        {
            if (move == null || model.Board.BoardState[move.CurrentPosition.Row, move.CurrentPosition.Col] == null)
            {
                return false;
            }
            
            PieceColor pieceColor = Model.Board.BoardState[move.CurrentPosition.Row, move.CurrentPosition.Col].PieceColor;
            Model.Board.PerformMoveOnTestBoard(move);
            foreach (IPiece boardPiece in model.Board.TestBoardState)
            {
                if (boardPiece != null && boardPiece.PieceColor != pieceColor && PieceGivesCheckToOpponentsKing(boardPiece))
                {
                    return true;
                }
            }
            model.Board.RevertTestBoardState();
            return false;
        }

        public bool PieceGivesCheckToOpponentsKing(IPiece piece)
        {
            if (piece == null)
            {
                return false;
            }
            ICollection<IMove> possibleMoves = new List<IMove>();
            possibleMoves = GeneratePossibleMovesForPieceWithoutConsideringDiscoveringCheck(piece);
            foreach (var boardPiece in model.Board.BoardState)
            {
                if (boardPiece != null && boardPiece.PieceType == PieceType.King && boardPiece.PieceColor != piece.PieceColor)
                {
                    if (possibleMoves.Any(move => move.NextPosition.Equals(boardPiece.PiecePosition)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsPieceProtected(IPiece piece)
        {
            if (piece == null)
            {
                return false;
            }
            IEnumerable<Position> guardedPositionsForAllPieces = new List<Position>();
            foreach (var boardPiece in model.Board.BoardState)
            {
                if (boardPiece != null 
                    && boardPiece.PieceColor == piece.PieceColor 
                    && GenerateGuardedPositionsForPiece(boardPiece).Contains(piece.PiecePosition))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidatePosition(Position position)
        {
            return position.Row >= 0 && position.Row <= 7 && position.Col >= 0 && position.Col <= 7;
        }

        // Possible moves generator
        public ICollection<IPosition> GenerateGuardedPositionsForPiece(IPiece piece)
        {
            ICollection<IPosition> guardedPiecesOnSquares = new List<IPosition>();
            if (piece == null)
            {
                return guardedPiecesOnSquares;
            }
            switch (piece.PieceType)
            {
                case PieceType.King:
                    Position positionOneKing = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1);
                    if (ValidatePosition(positionOneKing))
                    {
                        if (model.Board.BoardState[positionOneKing.Row, positionOneKing.Col] != null)
                        {
                            if (model.Board.BoardState[positionOneKing.Row, positionOneKing.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(positionOneKing);
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(positionOneKing);
                        }
                    }
                    Position positionTwoKing = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col);
                    if (ValidatePosition(positionTwoKing))
                    {
                        if (model.Board.BoardState[positionTwoKing.Row, positionTwoKing.Col] != null)
                        {
                            if (model.Board.BoardState[positionTwoKing.Row, positionTwoKing.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(positionTwoKing);
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(positionTwoKing);
                        }
                    }
                    Position positionThreeKing = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 1);
                    if (ValidatePosition(positionThreeKing))
                    {
                        if (model.Board.BoardState[positionThreeKing.Row, positionThreeKing.Col] != null)
                        {
                            if (model.Board.BoardState[positionThreeKing.Row, positionThreeKing.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(positionThreeKing);
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(positionThreeKing);
                        }
                    }
                    Position positionFourKing = new Position(piece.PiecePosition.Row, piece.PiecePosition.Col - 1);
                    if (ValidatePosition(positionFourKing))
                    {
                        if (model.Board.BoardState[positionFourKing.Row, positionFourKing.Col] != null)
                        {
                            if (model.Board.BoardState[positionFourKing.Row, positionFourKing.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(positionFourKing);
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(positionFourKing);
                        }
                    }
                    Position positionFiveKing = new Position(piece.PiecePosition.Row, piece.PiecePosition.Col + 1);
                    if (ValidatePosition(positionFiveKing))
                    {
                        if (model.Board.BoardState[positionFiveKing.Row, positionFiveKing.Col] != null)
                        {
                            if (model.Board.BoardState[positionFiveKing.Row, positionFiveKing.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(positionFiveKing);
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(positionFiveKing);
                        }
                    }
                    Position positionSixKing = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1);
                    if (ValidatePosition(positionSixKing))
                    {
                        if (model.Board.BoardState[positionSixKing.Row, positionSixKing.Col] != null)
                        {
                            if (model.Board.BoardState[positionSixKing.Row, positionSixKing.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(positionSixKing);
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(positionSixKing);
                        }
                    }
                    Position positionSevenKing = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col);
                    if (ValidatePosition(positionSevenKing))
                    {
                        if (model.Board.BoardState[positionSevenKing.Row, positionSevenKing.Col] != null)
                        {
                            if (model.Board.BoardState[positionSevenKing.Row, positionSevenKing.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(positionSevenKing);
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(positionSevenKing);
                        }
                    }
                    Position positionEightKing = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1);
                    if (ValidatePosition(positionEightKing))
                    {
                        if (model.Board.BoardState[positionEightKing.Row, positionEightKing.Col] != null)
                        {
                            if (model.Board.BoardState[positionEightKing.Row, positionEightKing.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(positionEightKing);
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(positionEightKing);
                        }
                    }
                    break;
                case PieceType.Queen:
                    int colQueen = piece.PiecePosition.Col - 1;
                    while (colQueen >= 0)
                    {
                        if (model.Board.BoardState[piece.PiecePosition.Row, colQueen] != null)
                        {
                            if (model.Board.BoardState[piece.PiecePosition.Row, colQueen].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(piece.PiecePosition.Row, colQueen));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(new Position(piece.PiecePosition.Row, colQueen));
                        }
                        colQueen--;
                    }
                    int rowQueen = piece.PiecePosition.Row - 1;
                    while (rowQueen >= 0)
                    {
                        if (model.Board.BoardState[rowQueen, piece.PiecePosition.Col] != null)
                        {
                            if (model.Board.BoardState[rowQueen, piece.PiecePosition.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowQueen, piece.PiecePosition.Col));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(new Position(rowQueen, piece.PiecePosition.Col));
                        }
                        rowQueen--;
                    }
                    colQueen = piece.PiecePosition.Col + 1;
                    while (colQueen <= 7)
                    {
                        if (model.Board.BoardState[piece.PiecePosition.Row, colQueen] != null)
                        {
                            if (model.Board.BoardState[piece.PiecePosition.Row, colQueen].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(piece.PiecePosition.Row, colQueen));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(new Position(piece.PiecePosition.Row, colQueen));
                        }
                        colQueen++;
                    }
                    rowQueen = piece.PiecePosition.Row + 1;
                    while (rowQueen <= 7)
                    {
                        if (model.Board.BoardState[rowQueen, piece.PiecePosition.Col] != null)
                        {
                            if (model.Board.BoardState[rowQueen, piece.PiecePosition.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowQueen, piece.PiecePosition.Col));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(new Position(rowQueen, piece.PiecePosition.Col));
                        }
                        rowQueen++;
                    }
                    rowQueen = piece.PiecePosition.Row - 1;
                    colQueen = piece.PiecePosition.Col - 1;
                    while (rowQueen >= 0 && colQueen >= 0)
                    {
                        if (model.Board.BoardState[rowQueen, colQueen] != null)
                        {
                            if (model.Board.BoardState[rowQueen, colQueen].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowQueen, colQueen));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(new Position(rowQueen, colQueen));
                        }
                        rowQueen--;
                        colQueen--;
                    }
                    rowQueen = piece.PiecePosition.Row - 1;
                    colQueen = piece.PiecePosition.Col + 1;
                    while (rowQueen >= 0 && colQueen <= 7)
                    {
                        if (model.Board.BoardState[rowQueen, colQueen] != null)
                        {
                            if (model.Board.BoardState[rowQueen, colQueen].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowQueen, colQueen));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(new Position(rowQueen, colQueen));
                        }
                        rowQueen--;
                        colQueen++;
                    }
                    rowQueen = piece.PiecePosition.Row + 1;
                    colQueen = piece.PiecePosition.Col + 1;
                    while (rowQueen <= 7 && colQueen <= 7)
                    {
                        if (model.Board.BoardState[rowQueen, colQueen] != null)
                        {
                            if (model.Board.BoardState[rowQueen, colQueen].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowQueen, colQueen));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(new Position(rowQueen, colQueen));
                        }
                        rowQueen++;
                        colQueen++;
                    }
                    rowQueen = piece.PiecePosition.Row + 1;
                    colQueen = piece.PiecePosition.Col - 1;
                    while (rowQueen <= 7 && colQueen >= 0)
                    {
                        if (model.Board.BoardState[rowQueen, colQueen] != null)
                        {
                            if (model.Board.BoardState[rowQueen, colQueen].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowQueen, colQueen));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(new Position(rowQueen, colQueen));
                        }
                        rowQueen++;
                        colQueen--;
                    }
                    break;
                case PieceType.Rook:
                    int colRook = piece.PiecePosition.Col - 1;
                    while (colRook >= 0)
                    {
                        if (model.Board.BoardState[piece.PiecePosition.Row, colRook] != null)
                        {
                            if (model.Board.BoardState[piece.PiecePosition.Row, colRook].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(piece.PiecePosition.Row, colRook));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(new Position(piece.PiecePosition.Row, colRook));
                        }
                        colRook--;
                    }
                    int rowRook = piece.PiecePosition.Row - 1;
                    while (rowRook >= 0)
                    {
                        if (model.Board.BoardState[rowRook, piece.PiecePosition.Col] != null)
                        {
                            if (model.Board.BoardState[rowRook, piece.PiecePosition.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowRook, piece.PiecePosition.Col));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(new Position(rowRook, piece.PiecePosition.Col));
                        }
                        rowRook--;
                    }
                    colRook = piece.PiecePosition.Col + 1;
                    while (colRook <= 7)
                    {
                        if (model.Board.BoardState[piece.PiecePosition.Row, colRook] != null)
                        {
                            if (model.Board.BoardState[piece.PiecePosition.Row, colRook].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(piece.PiecePosition.Row, colRook));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(new Position(piece.PiecePosition.Row, colRook));
                        }
                        colRook++;
                    }
                    rowRook = piece.PiecePosition.Row + 1;
                    while (rowRook <= 7)
                    {
                        if (model.Board.BoardState[rowRook, piece.PiecePosition.Col] != null)
                        {
                            if (model.Board.BoardState[rowRook, piece.PiecePosition.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowRook, piece.PiecePosition.Col));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(new Position(rowRook, piece.PiecePosition.Col));
                        }
                        rowRook++;
                    }
                    break;
                case PieceType.Knight:
                    Position positionOneKnight = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 2);
                    if (ValidatePosition(positionOneKnight))
                    {
                        if (model.Board.BoardState[positionOneKnight.Row, positionOneKnight.Col] != null)
                        {
                            if (model.Board.BoardState[positionOneKnight.Row, positionOneKnight.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(positionOneKnight);
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(positionOneKnight);
                        }
                    }
                    Position positionTwoKnight = new Position(piece.PiecePosition.Row - 2, piece.PiecePosition.Col - 1);
                    if (ValidatePosition(positionTwoKnight))
                    {
                        if (model.Board.BoardState[positionTwoKnight.Row, positionTwoKnight.Col] != null)
                        {
                            if (model.Board.BoardState[positionTwoKnight.Row, positionTwoKnight.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(positionTwoKnight);
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(positionTwoKnight);
                        }
                    }
                    Position positionThreeKnight = new Position(piece.PiecePosition.Row - 2, piece.PiecePosition.Col + 1);
                    if (ValidatePosition(positionThreeKnight))
                    {
                        if (model.Board.BoardState[positionThreeKnight.Row, positionThreeKnight.Col] != null)
                        {
                            if (model.Board.BoardState[positionThreeKnight.Row, positionThreeKnight.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(positionThreeKnight);
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(positionThreeKnight);
                        }
                    }
                    Position positionFourKnight = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 2);
                    if (ValidatePosition(positionFourKnight))
                    {
                        if (model.Board.BoardState[positionFourKnight.Row, positionFourKnight.Col] != null)
                        {
                            if (model.Board.BoardState[positionFourKnight.Row, positionFourKnight.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(positionFourKnight);
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(positionFourKnight);
                        }
                    }
                    Position positionFiveKnight = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 2);
                    if (ValidatePosition(positionFiveKnight))
                    {
                        if (model.Board.BoardState[positionFiveKnight.Row, positionFiveKnight.Col] != null)
                        {
                            if (model.Board.BoardState[positionFiveKnight.Row, positionFiveKnight.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(positionFiveKnight);
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(positionFiveKnight);
                        }
                    }
                    Position positionSixKnight = new Position(piece.PiecePosition.Row + 2, piece.PiecePosition.Col + 1);
                    if (ValidatePosition(positionSixKnight))
                    {
                        if (model.Board.BoardState[positionSixKnight.Row, positionSixKnight.Col] != null)
                        {
                            if (model.Board.BoardState[positionSixKnight.Row, positionSixKnight.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(positionSixKnight);
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(positionSixKnight);
                        }
                    }
                    Position positionSevenKnight = new Position(piece.PiecePosition.Row + 2, piece.PiecePosition.Col - 1);
                    if (ValidatePosition(positionSevenKnight))
                    {
                        if (model.Board.BoardState[positionSevenKnight.Row, positionSevenKnight.Col] != null)
                        {
                            if (model.Board.BoardState[positionSevenKnight.Row, positionSevenKnight.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(positionSevenKnight);
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(positionSevenKnight);
                        }
                    }
                    Position positionEightKnight = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 2);
                    if (ValidatePosition(positionEightKnight))
                    {
                        if (model.Board.BoardState[positionEightKnight.Row, positionEightKnight.Col] != null)
                        {
                            if (model.Board.BoardState[positionEightKnight.Row, positionEightKnight.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(positionEightKnight);
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(positionEightKnight);
                        }
                    }
                    break;
                case PieceType.Bishop:
                    int rowBishop = piece.PiecePosition.Row - 1;
                    int colBishop = piece.PiecePosition.Col - 1;
                    while (rowBishop >= 0 && colBishop >= 0)
                    {
                        if (model.Board.BoardState[rowBishop, colBishop] != null)
                        {
                            if (model.Board.BoardState[rowBishop, colBishop].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowBishop, colBishop));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(new Position(rowBishop, colBishop));
                        }
                        rowBishop--;
                        colBishop--;
                    }
                    rowBishop = piece.PiecePosition.Row - 1;
                    colBishop = piece.PiecePosition.Col + 1;
                    while (rowBishop >= 0 && colBishop <= 7)
                    {
                        if (model.Board.BoardState[rowBishop, colBishop] != null)
                        {
                            if (model.Board.BoardState[rowBishop, colBishop].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowBishop, colBishop));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(new Position(rowBishop, colBishop));
                        }
                        rowBishop--;
                        colBishop++;
                    }
                    rowBishop = piece.PiecePosition.Row + 1;
                    colBishop = piece.PiecePosition.Col + 1;
                    while (rowBishop <= 7 && colBishop <= 7)
                    {
                        if (model.Board.BoardState[rowBishop, colBishop] != null)
                        {
                            if (model.Board.BoardState[rowBishop, colBishop].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowBishop, colBishop));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(new Position(rowBishop, colBishop));
                        }
                        rowBishop++;
                        colBishop++;
                    }
                    rowBishop = piece.PiecePosition.Row + 1;
                    colBishop = piece.PiecePosition.Col - 1;
                    while (rowBishop <= 7 && colBishop >= 0)
                    {
                        if (model.Board.BoardState[rowBishop, colBishop] != null)
                        {
                            if (model.Board.BoardState[rowBishop, colBishop].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowBishop, colBishop));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            guardedPiecesOnSquares.Add(new Position(rowBishop, colBishop));
                        }
                        rowBishop++;
                        colBishop--;
                    }
                    break;
                case PieceType.Pawn:
                    if (piece.PieceColor == PieceColor.White)
                    {
                        Position positionOnePawn = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 1);
                        Position positionTwoPawn = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1);
                        if (ValidatePosition(positionOnePawn))
                        {
                            if (model.Board.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 1] != null)
                            {
                                if (model.Board.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 1].PieceColor == PieceColor.White)
                                {
                                    guardedPiecesOnSquares.Add(positionOnePawn);
                                }
                            }
                            else
                            {
                                guardedPiecesOnSquares.Add(positionOnePawn);
                            }
                        }
                        if (ValidatePosition(positionTwoPawn))
                        {
                            if (model.Board.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1] != null)
                            {
                                if (model.Board.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1].PieceColor == PieceColor.White)
                                {
                                    guardedPiecesOnSquares.Add(positionTwoPawn);
                                }
                            }
                            else
                            {
                                guardedPiecesOnSquares.Add(positionTwoPawn);
                            }
                        }
                    }
                    else
                    {
                        Position positionOnePawn = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1);
                        Position positionTwoPawn = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1);
                        if (ValidatePosition(positionOnePawn))
                        {
                            if (model.Board.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1] != null)
                            {
                                if (model.Board.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1].PieceColor == PieceColor.Black)
                                {
                                    guardedPiecesOnSquares.Add(positionOnePawn);
                                }
                            }
                            else
                            {
                                guardedPiecesOnSquares.Add(positionOnePawn);
                            }
                        }
                        if (ValidatePosition(positionTwoPawn))
                        {
                            if (model.Board.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1] != null)
                            {
                                if (model.Board.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1].PieceColor == PieceColor.Black)
                                {
                                    guardedPiecesOnSquares.Add(positionTwoPawn);
                                }
                            }
                            else
                            {
                                guardedPiecesOnSquares.Add(positionTwoPawn);
                            }
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid piece");
            }
            return guardedPiecesOnSquares;
        }

        public ICollection<IMove> GeneratePossibleMovesForPieceConsideringDiscoveringCheck(IPiece piece)
        {
            ICollection<IMove> possibleMoves = new List<IMove>();
            possibleMoves = GeneratePossibleMovesForPieceWithoutConsideringDiscoveringCheck(piece);
            ICollection<IMove> impossibleMoves = new List<IMove>();
            foreach (var move in possibleMoves)
            {
                if (MoveDiscoversCheckToOwnKing(move))
                {
                    impossibleMoves.Add(move);
                }
            }
            foreach (var move in impossibleMoves)
			{
				possibleMoves.Remove(move);
            }
            if (piece.PieceColor == PieceColor.White)
            {
                if (IsWhiteLeftCastlePossible())
                {
                    possibleMoves.Add(new Move(piece.PiecePosition, new Position(7, 2)));
                }
                if (IsWhiteRightCastlePossible())
                {
                    possibleMoves.Add(new Move(piece.PiecePosition, new Position(7, 6)));
                }
            }
            else
            {
                if (IsBlackLeftCastlePossible())
                {
                    possibleMoves.Add(new Move(piece.PiecePosition, new Position(0, 2)));
                }
                if (IsBlackRightCastlePossible())
                {
                    possibleMoves.Add(new Move(piece.PiecePosition, new Position(0, 6)));
                }
            }
            return possibleMoves;
        }

        public ICollection<IMove> GeneratePossibleMovesForPieceWithoutConsideringDiscoveringCheck(IPiece piece)
        {
            ICollection<IMove> possibleMoves = new List<IMove>();
            if (piece == null)
            {
                return possibleMoves;
            }
            switch (piece.PieceType)
            {
                case PieceType.King:
                    IEnumerable<IPosition> allGuardedPositionsByOpponent = new List<IPosition>();
                    foreach (var boardPiece in model.Board.BoardState)
                    {
                        if (boardPiece != null && boardPiece.PieceColor != piece.PieceColor)
                        {
                            allGuardedPositionsByOpponent = allGuardedPositionsByOpponent.Concat(GenerateGuardedPositionsForPiece(boardPiece));
                        }
                    }

                    Position positionOneKing = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1);
                    if (ValidatePosition(positionOneKing) && !allGuardedPositionsByOpponent.Contains(positionOneKing))
                    {
                        if (model.Board.BoardState[positionOneKing.Row, positionOneKing.Col] != null)
                        {
                            if (model.Board.BoardState[positionOneKing.Row, positionOneKing.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionOneKing));
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionOneKing));
                        }
                    }
                    Position positionTwoKing = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col);
                    if (ValidatePosition(positionTwoKing) && !allGuardedPositionsByOpponent.Contains(positionTwoKing))
                    {
                        if (model.Board.BoardState[positionTwoKing.Row, positionTwoKing.Col] != null)
                        {
                            if (model.Board.BoardState[positionTwoKing.Row, positionTwoKing.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionTwoKing));
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionTwoKing));
                        }
                    }
                    Position positionThreeKing = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 1);
                    if (ValidatePosition(positionThreeKing) && !allGuardedPositionsByOpponent.Contains(positionThreeKing))
                    {
                        if (model.Board.BoardState[positionThreeKing.Row, positionThreeKing.Col] != null)
                        {
                            if (model.Board.BoardState[positionThreeKing.Row, positionThreeKing.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionThreeKing));
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionThreeKing));
                        }
                    }
                    Position positionFourKing = new Position(piece.PiecePosition.Row, piece.PiecePosition.Col - 1);
                    if (ValidatePosition(positionFourKing) && !allGuardedPositionsByOpponent.Contains(positionFourKing))
                    {
                        if (model.Board.BoardState[positionFourKing.Row, positionFourKing.Col] != null)
                        {
                            if (model.Board.BoardState[positionFourKing.Row, positionFourKing.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionFourKing));
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionFourKing));
                        }
                    }
                    Position positionFiveKing = new Position(piece.PiecePosition.Row, piece.PiecePosition.Col + 1);
                    if (ValidatePosition(positionFiveKing) && !allGuardedPositionsByOpponent.Contains(positionFiveKing))
                    {
                        if (model.Board.BoardState[positionFiveKing.Row, positionFiveKing.Col] != null)
                        {
                            if (model.Board.BoardState[positionFiveKing.Row, positionFiveKing.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionFiveKing));
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionFiveKing));
                        }
                    }
                    Position positionSixKing = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1);
                    if (ValidatePosition(positionSixKing) && !allGuardedPositionsByOpponent.Contains(positionSixKing))
                    {
                        if (model.Board.BoardState[positionSixKing.Row, positionSixKing.Col] != null)
                        {
                            if (model.Board.BoardState[positionSixKing.Row, positionSixKing.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionSixKing));
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionSixKing));
                        }
                    }
                    Position positionSevenKing = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col);
                    if (ValidatePosition(positionSevenKing) && !allGuardedPositionsByOpponent.Contains(positionSevenKing))
                    {
                        if (model.Board.BoardState[positionSevenKing.Row, positionSevenKing.Col] != null)
                        {
                            if (model.Board.BoardState[positionSevenKing.Row, positionSevenKing.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionSevenKing));
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionSevenKing));
                        }
                    }
                    Position positionEightKing = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1);
                    if (ValidatePosition(positionEightKing) && !allGuardedPositionsByOpponent.Contains(positionEightKing))
                    {
                        if (model.Board.BoardState[positionEightKing.Row, positionEightKing.Col] != null)
                        {
                            if (model.Board.BoardState[positionEightKing.Row, positionEightKing.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionEightKing));
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionEightKing));
                        }
                    }
                    break;
                case PieceType.Queen:
                    int colQueen = piece.PiecePosition.Col - 1;
                    while (colQueen >= 0)
                    {
                        if (model.Board.BoardState[piece.PiecePosition.Row, colQueen] != null)
                        {
                            if (model.Board.BoardState[piece.PiecePosition.Row, colQueen].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, new Position(piece.PiecePosition.Row, colQueen)));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, new Position(piece.PiecePosition.Row, colQueen)));
                        }
                        colQueen--;
                    }
                    int rowQueen = piece.PiecePosition.Row - 1;
                    while (rowQueen >= 0)
                    {
                        if (model.Board.BoardState[rowQueen, piece.PiecePosition.Col] != null)
                        {
                            if (model.Board.BoardState[rowQueen, piece.PiecePosition.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowQueen, piece.PiecePosition.Col)));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowQueen, piece.PiecePosition.Col)));
                        }
                        rowQueen--;
                    }
                    colQueen = piece.PiecePosition.Col + 1;
                    while (colQueen <= 7)
                    {
                        if (model.Board.BoardState[piece.PiecePosition.Row, colQueen] != null)
                        {
                            if (model.Board.BoardState[piece.PiecePosition.Row, colQueen].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, new Position(piece.PiecePosition.Row, colQueen)));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, new Position(piece.PiecePosition.Row, colQueen)));
                        }
                        colQueen++;
                    }
                    rowQueen = piece.PiecePosition.Row + 1;
                    while (rowQueen <= 7)
                    {
                        if (model.Board.BoardState[rowQueen, piece.PiecePosition.Col] != null)
                        {
                            if (model.Board.BoardState[rowQueen, piece.PiecePosition.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowQueen, piece.PiecePosition.Col)));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowQueen, piece.PiecePosition.Col)));
                        }
                        rowQueen++;
                    }
                    rowQueen = piece.PiecePosition.Row - 1;
                    colQueen = piece.PiecePosition.Col - 1;
                    while (rowQueen >= 0 && colQueen >= 0)
                    {
                        if (model.Board.BoardState[rowQueen, colQueen] != null)
                        {
                            if (model.Board.BoardState[rowQueen, colQueen].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowQueen, colQueen)));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowQueen, colQueen)));
                        }
                        rowQueen--;
                        colQueen--;
                    }
                    rowQueen = piece.PiecePosition.Row - 1;
                    colQueen = piece.PiecePosition.Col + 1;
                    while (rowQueen >= 0 && colQueen <= 7)
                    {
                        if (model.Board.BoardState[rowQueen, colQueen] != null)
                        {
                            if (model.Board.BoardState[rowQueen, colQueen].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowQueen, colQueen)));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowQueen, colQueen)));
                        }
                        rowQueen--;
                        colQueen++;
                    }
                    rowQueen = piece.PiecePosition.Row + 1;
                    colQueen = piece.PiecePosition.Col + 1;
                    while (rowQueen <= 7 && colQueen <= 7)
                    {
                        if (model.Board.BoardState[rowQueen, colQueen] != null)
                        {
                            if (model.Board.BoardState[rowQueen, colQueen].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowQueen, colQueen)));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowQueen, colQueen)));
                        }
                        rowQueen++;
                        colQueen++;
                    }
                    rowQueen = piece.PiecePosition.Row + 1;
                    colQueen = piece.PiecePosition.Col - 1;
                    while (rowQueen <= 7 && colQueen >= 0)
                    {
                        if (model.Board.BoardState[rowQueen, colQueen] != null)
                        {
                            if (model.Board.BoardState[rowQueen, colQueen].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowQueen, colQueen)));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowQueen, colQueen)));
                        }
                        rowQueen++;
                        colQueen--;
                    }
                    break;
                case PieceType.Rook:
                    int colRook = piece.PiecePosition.Col - 1;
                    while (colRook >= 0)
                    {
                        if (model.Board.BoardState[piece.PiecePosition.Row, colRook] != null)
                        {
                            if (model.Board.BoardState[piece.PiecePosition.Row, colRook].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, new Position(piece.PiecePosition.Row, colRook)));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, new Position(piece.PiecePosition.Row, colRook)));
                        }
                        colRook--;
                    }
                    int rowRook = piece.PiecePosition.Row - 1;
                    while (rowRook >= 0)
                    {
                        if (model.Board.BoardState[rowRook, piece.PiecePosition.Col] != null)
                        {
                            if (model.Board.BoardState[rowRook, piece.PiecePosition.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowRook, piece.PiecePosition.Col)));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowRook, piece.PiecePosition.Col)));
                        }
                        rowRook--;
                    }
                    colRook = piece.PiecePosition.Col + 1;
                    while (colRook <= 7)
                    {
                        if (model.Board.BoardState[piece.PiecePosition.Row, colRook] != null)
                        {
                            if (model.Board.BoardState[piece.PiecePosition.Row, colRook].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, new Position(piece.PiecePosition.Row, colRook)));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, new Position(piece.PiecePosition.Row, colRook)));
                        }
                        colRook++;
                    }
                    rowRook = piece.PiecePosition.Row + 1;
                    while (rowRook <= 7)
                    {
                        if (model.Board.BoardState[rowRook, piece.PiecePosition.Col] != null)
                        {
                            if (model.Board.BoardState[rowRook, piece.PiecePosition.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowRook, piece.PiecePosition.Col)));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowRook, piece.PiecePosition.Col)));
                        }
                        rowRook++;
                    }
                    break;
                case PieceType.Knight:
                    Position positionOneKnight = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 2);
                    if (ValidatePosition(positionOneKnight))
                    {
                        if (model.Board.BoardState[positionOneKnight.Row, positionOneKnight.Col] != null)
                        {
                            if (model.Board.BoardState[positionOneKnight.Row, positionOneKnight.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionOneKnight));
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionOneKnight));
                        }
                    }
                    Position positionTwoKnight = new Position(piece.PiecePosition.Row - 2, piece.PiecePosition.Col - 1);
                    if (ValidatePosition(positionTwoKnight))
                    {
                        if (model.Board.BoardState[positionTwoKnight.Row, positionTwoKnight.Col] != null)
                        {
                            if (model.Board.BoardState[positionTwoKnight.Row, positionTwoKnight.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionTwoKnight));
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionTwoKnight));
                        }
                    }
                    Position positionThreeKnight = new Position(piece.PiecePosition.Row - 2, piece.PiecePosition.Col + 1);
                    if (ValidatePosition(positionThreeKnight))
                    {
                        if (model.Board.BoardState[positionThreeKnight.Row, positionThreeKnight.Col] != null)
                        {
                            if (model.Board.BoardState[positionThreeKnight.Row, positionThreeKnight.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionThreeKnight));
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionThreeKnight));
                        }
                    }
                    Position positionFourKnight = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 2);
                    if (ValidatePosition(positionFourKnight))
                    {
                        if (model.Board.BoardState[positionFourKnight.Row, positionFourKnight.Col] != null)
                        {
                            if (model.Board.BoardState[positionFourKnight.Row, positionFourKnight.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionFourKnight));
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionFourKnight));
                        }
                    }
                    Position positionFiveKnight = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 2);
                    if (ValidatePosition(positionFiveKnight))
                    {
                        if (model.Board.BoardState[positionFiveKnight.Row, positionFiveKnight.Col] != null)
                        {
                            if (model.Board.BoardState[positionFiveKnight.Row, positionFiveKnight.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionFiveKnight));
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionFiveKnight));
                        }
                    }
                    Position positionSixKnight = new Position(piece.PiecePosition.Row + 2, piece.PiecePosition.Col + 1);
                    if (ValidatePosition(positionSixKnight))
                    {
                        if (model.Board.BoardState[positionSixKnight.Row, positionSixKnight.Col] != null)
                        {
                            if (model.Board.BoardState[positionSixKnight.Row, positionSixKnight.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionSixKnight));
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionSixKnight));
                        }
                    }
                    Position positionSevenKnight = new Position(piece.PiecePosition.Row + 2, piece.PiecePosition.Col - 1);
                    if (ValidatePosition(positionSevenKnight))
                    {
                        if (model.Board.BoardState[positionSevenKnight.Row, positionSevenKnight.Col] != null)
                        {
                            if (model.Board.BoardState[positionSevenKnight.Row, positionSevenKnight.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionSevenKnight));
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionSevenKnight));
                        }
                    }
                    Position positionEightKnight = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 2);
                    if (ValidatePosition(positionEightKnight))
                    {
                        if (model.Board.BoardState[positionEightKnight.Row, positionEightKnight.Col] != null)
                        {
                            if (model.Board.BoardState[positionEightKnight.Row, positionEightKnight.Col].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionEightKnight));
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionEightKnight));
                        }
                    }
                    break;
                case PieceType.Bishop:
                    int rowBishop = piece.PiecePosition.Row - 1;
                    int colBishop = piece.PiecePosition.Col - 1;
                    while (rowBishop >= 0 && colBishop >= 0)
                    {
                        if (model.Board.BoardState[rowBishop, colBishop] != null)
                        {
                            if (model.Board.BoardState[rowBishop, colBishop].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowBishop, colBishop)));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowBishop, colBishop)));
                        }
                        rowBishop--;
                        colBishop--;
                    }
                    rowBishop = piece.PiecePosition.Row - 1;
                    colBishop = piece.PiecePosition.Col + 1;
                    while (rowBishop >= 0 && colBishop <= 7)
                    {
                        if (model.Board.BoardState[rowBishop, colBishop] != null)
                        {
                            if (model.Board.BoardState[rowBishop, colBishop].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowBishop, colBishop)));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowBishop, colBishop)));
                        }
                        rowBishop--;
                        colBishop++;
                    }
                    rowBishop = piece.PiecePosition.Row + 1;
                    colBishop = piece.PiecePosition.Col + 1;
                    while (rowBishop <= 7 && colBishop <= 7)
                    {
                        if (model.Board.BoardState[rowBishop, colBishop] != null)
                        {
                            if (model.Board.BoardState[rowBishop, colBishop].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowBishop, colBishop)));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowBishop, colBishop)));
                        }
                        rowBishop++;
                        colBishop++;
                    }
                    rowBishop = piece.PiecePosition.Row + 1;
                    colBishop = piece.PiecePosition.Col - 1;
                    while (rowBishop <= 7 && colBishop >= 0)
                    {
                        if (model.Board.BoardState[rowBishop, colBishop] != null)
                        {
                            if (model.Board.BoardState[rowBishop, colBishop].PieceColor != piece.PieceColor)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowBishop, colBishop)));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, new Position(rowBishop, colBishop)));
                        }
                        rowBishop++;
                        colBishop--;
                    }
                    break;
                case PieceType.Pawn:
                    if (piece.PieceColor == PieceColor.White)
                    {
                        Position positionOnePawn = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 1);
                        Position positionTwoPawn = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1);
                        if (ValidatePosition(positionOnePawn) && model.Board.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 1] != null && model.Board.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 1].PieceColor == PieceColor.Black)
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionOnePawn));
                        }
                        if (ValidatePosition(positionTwoPawn) && model.Board.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1] != null && model.Board.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1].PieceColor == PieceColor.Black)
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionTwoPawn));
                        }
                        Position positionThreePawn = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col);
                        if (ValidatePosition(positionThreePawn) && model.Board.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col] == null)
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionThreePawn));
                        }
                        if (piece.PiecePosition.Row == 6)
                        {
                            Position positionFourPawn = new Position(piece.PiecePosition.Row - 2, piece.PiecePosition.Col);
                            if (model.Board.BoardState[piece.PiecePosition.Row - 2, piece.PiecePosition.Col] == null && model.Board.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col] == null)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionFourPawn));
                            }
                        }
                    }
                    else
                    {
                        Position positionOnePawn = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1);
                        Position positionTwoPawn = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1);
                        if (ValidatePosition(positionOnePawn) && model.Board.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1] != null && model.Board.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1].PieceColor == PieceColor.White)
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionOnePawn));
                        }
                        if (ValidatePosition(positionTwoPawn) && model.Board.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1] != null && model.Board.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1].PieceColor == PieceColor.White)
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionTwoPawn));
                        }
                        Position positionThreePawn = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col);
                        if (ValidatePosition(positionThreePawn) && model.Board.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col] == null)
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionThreePawn));
                        }
                        if (piece.PiecePosition.Row == 1)
                        {
                            Position positionFourPawn = new Position(piece.PiecePosition.Row + 2, piece.PiecePosition.Col);
                            if (model.Board.BoardState[piece.PiecePosition.Row + 2, piece.PiecePosition.Col] == null && model.Board.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col] == null)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionFourPawn));
                            }
                        }
                    }

                    ICollection<IMove> posslbeEnPassantMoves = GeneratePosslbeEnPassantMoves();
                    foreach (var move in posslbeEnPassantMoves)
                    {
                        if (move.CurrentPosition == piece.PiecePosition)
                        {
                            possibleMoves.Add(move);
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid piece");
            }
            return possibleMoves;
        }

        public IEnumerable<IMove> GeneratePossibleMovesForPlayer(PieceColor pieceColor)
        {
            IEnumerable<IMove> possibleMoves = new List<IMove>();
            foreach (Piece boardPiece in model.Board.BoardState)
            {
                if (boardPiece != null && boardPiece.PieceColor == pieceColor)
                {
                    possibleMoves = possibleMoves.Concat(this.GeneratePossibleMovesForPieceConsideringDiscoveringCheck(boardPiece));
                }
            }
            return possibleMoves;
        }

        // Player Check
        public bool IsPlayerInCheck(PieceColor pieceColor)
        {
            foreach (IPiece boardPiece in model.Board.BoardState)
            {
                if (boardPiece != null 
                    && boardPiece.PieceColor != pieceColor 
                    && PieceGivesCheckToOpponentsKing(boardPiece))
                {
                    return true;
                }
            }
            return false;
        }

        //Castle Checks
        public bool IsCurrentPlayerLeftCastlePossible()
        {
            switch (model.Board.CurrentPlayerToMove)
            {
                case PieceColor.White:
                    return IsWhiteLeftCastlePossible();
                case PieceColor.Black:
                    return IsBlackLeftCastlePossible();
                default:
                    throw new ArgumentException("Invalid current player");
            }
        }

        public bool IsCurrentPlayerRightCastlePossible()
        {
            switch (model.Board.CurrentPlayerToMove)
            {
                case PieceColor.White:
                    return IsWhiteRightCastlePossible();
                case PieceColor.Black:
                    return IsBlackRightCastlePossible();
                default:
                    throw new ArgumentException("Invalid current player");
            }
        }

        public bool IsWhiteLeftCastlePossible()
        {
            if (model.Board.WhiteLeftCastlePossible
                && !IsPlayerInCheck(PieceColor.White)
                && model.Board.BoardState[7, 1] == null
                && model.Board.BoardState[7, 2] == null
                && model.Board.BoardState[7, 3] == null
            ) // has white moved the left && are there pieces between the left white rook and the white king
            {

                IEnumerable<IPosition> guardedPositionsForAllPieces = new List<IPosition>();
                foreach (IPiece boardPiece in model.Board.BoardState)
                {
                    if (boardPiece != null && boardPiece.PieceColor == PieceColor.Black)
                    {
                        guardedPositionsForAllPieces =
                            guardedPositionsForAllPieces.Concat(GenerateGuardedPositionsForPiece(boardPiece));
                    }
                }
                if (!guardedPositionsForAllPieces.Contains(new Position(7, 2)) &&
                    !guardedPositionsForAllPieces.Contains(new Position(7, 3))
                ) // are there squares that the white king has to go through that are attacked
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsWhiteRightCastlePossible()
        {
            if (model.Board.WhiteRightCastlePossible
                && !IsPlayerInCheck(PieceColor.White)
                && model.Board.BoardState[7, 5] == null
                && model.Board.BoardState[7, 6] == null)
            {
                IEnumerable<IPosition> guardedPositionsForAllPieces = new List<IPosition>();
                foreach (Piece boardPiece in model.Board.BoardState)
                {
                    if (boardPiece != null && boardPiece.PieceColor == PieceColor.Black)
                    {
                        guardedPositionsForAllPieces =
                            guardedPositionsForAllPieces.Concat(GenerateGuardedPositionsForPiece(boardPiece));
                    }
                }
                if (!guardedPositionsForAllPieces.Contains(new Position(7, 5)) &&
                    !guardedPositionsForAllPieces.Contains(new Position(7, 6)))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsBlackLeftCastlePossible()
        {
            if (model.Board.BlackLeftCastlePossible
                && IsPlayerInCheck(PieceColor.Black)
                && model.Board.BoardState[0, 1] == null
                && model.Board.BoardState[0, 2] == null
                && model.Board.BoardState[0, 3] == null)
            {
                IEnumerable<IPosition> guardedPositionsForAllPieces = new List<IPosition>();
                foreach (IPiece boardPiece in model.Board.BoardState)
                {
                    if (boardPiece != null && boardPiece.PieceColor == PieceColor.White)
                    {
                        guardedPositionsForAllPieces =
                            guardedPositionsForAllPieces.Concat(GenerateGuardedPositionsForPiece(boardPiece));
                    }
                }
                if (!guardedPositionsForAllPieces.Contains(new Position(0, 2)) &&
                    !guardedPositionsForAllPieces.Contains(new Position(0, 3)))
                {
                    return true;
                }

            }
            return false;
        }

        public bool IsBlackRightCastlePossible()
        {
            if (model.Board.BlackRightCastlePossible && !IsPlayerInCheck(PieceColor.Black))
            {
                if (model.Board.BoardState[0, 5] == null && model.Board.BoardState[0, 6] == null)
                {
                    IEnumerable<IPosition> guardedPositionsForAllPieces = new List<IPosition>();
                    foreach (IPiece boardPiece in model.Board.BoardState)
                    {
                        if (boardPiece != null && boardPiece.PieceColor == PieceColor.White)
                        {
                            guardedPositionsForAllPieces = guardedPositionsForAllPieces.Concat(GenerateGuardedPositionsForPiece(boardPiece));
                        }
                    }
                    if (!guardedPositionsForAllPieces.Contains(new Position(0, 5)) 
                     && !guardedPositionsForAllPieces.Contains(new Position(0, 6)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckIfKingVsKing()
        {
            foreach (IPiece boardPiece in model.Board.BoardState)
            {
                if (boardPiece != null && boardPiece.PieceType != PieceType.King)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckIfKingKnightVsKing()
        {
            int knightsCount = 0;
			foreach (IPiece boardPiece in model.Board.BoardState)
			{
                if (boardPiece.PieceType == PieceType.Knight) 
                {
                    knightsCount++;
                    continue;
                }
				if (boardPiece != null && boardPiece.PieceType != PieceType.King)
				{
					return false;
				}
			}
            return knightsCount == 1;
        }

		private bool CheckIfKingBishopVsKing()
		{
			int bishopsCount = 0;
			foreach (IPiece boardPiece in model.Board.BoardState)
			{
                if (boardPiece.PieceType == PieceType.Bishop)
				{
					bishopsCount++;
					continue;
				}
				if (boardPiece != null && boardPiece.PieceType != PieceType.King)
				{
					return false;
				}
			}
			return bishopsCount == 1;
		}

        public ICollection<IMove> GeneratePosslbeEnPassantMoves()
        {
            ICollection<IMove> possibleEnPassantMoves = new List<IMove>();
            if (model.LastMove == null || model.Board.BoardState[model.LastMove.NextPosition.Row, model.LastMove.NextPosition.Col].PieceType != PieceType.Pawn)
            { //check if last moved piece was actually a pawn
                return possibleEnPassantMoves;
            }
            PieceColor pieceColor = model.Board.BoardState[model.LastMove.NextPosition.Row, model.LastMove.NextPosition.Col].PieceColor; //check who moved last turn
            switch (pieceColor)
            {
                case PieceColor.White:
                    if (model.LastMove.NextPosition.Row != 4)
                    { //if it was white's turn and he didn't moved his pawn to the 4th row - return
                        return possibleEnPassantMoves;
                    }
                    break;
                case PieceColor.Black:
                    if (model.LastMove.NextPosition.Row != 3)
                    {
                        return possibleEnPassantMoves;
                    }
                    break;
            }
            foreach (var boardPiece in model.Board.BoardState)
            {
                if (boardPiece == null)
                {
                    continue;
                }
                if (boardPiece.PieceColor != pieceColor && boardPiece.PieceType == PieceType.Pawn) //iterating over all pawns from the current player
                {
                    switch (boardPiece.PieceColor)
                    {
                        case PieceColor.White:
                            if (boardPiece.PiecePosition.Row != 3) //in case if it's white's turn - check if his pawn is at row 3
                            {
                                return possibleEnPassantMoves;
                            }
                            break;
                        case PieceColor.Black:
                            if (model.LastMove.NextPosition.Row != 4)
                            {
                                return possibleEnPassantMoves;
                            }
                            break;
                    }
                }
                if (boardPiece.PiecePosition.Col == model.Board.BoardState[model.LastMove.NextPosition.Row, model.LastMove.NextPosition.Col].PiecePosition.Col + 1
                    || boardPiece.PiecePosition.Col == model.Board.BoardState[model.LastMove.NextPosition.Row, model.LastMove.NextPosition.Col].PiecePosition.Col - 1)
                { //ensure that the pawn is in an adjusted column

                    switch (boardPiece.PieceColor)
                    {
                        case PieceColor.White:
                            possibleEnPassantMoves.Add(new Move(boardPiece.PiecePosition, new Position(model.LastMove.NextPosition.Row - 1, model.LastMove.NextPosition.Col))); //in case all checks are successful add the move to the possible moves
                            break;
                        case PieceColor.Black:
                            possibleEnPassantMoves.Add(new Move(boardPiece.PiecePosition, new Position(model.LastMove.NextPosition.Row + 1, model.LastMove.NextPosition.Col)));
                            break;
                    }
                }
            }
            return possibleEnPassantMoves;
        }

        public bool CheckForCheckmate()
        {
            return !this.GeneratePossibleMovesForPlayer(model.Board.CurrentPlayerToMove).Any() 
                     && IsPlayerInCheck(model.Board.CurrentPlayerToMove);
        }

		public bool CheckForDraw()
		{
			if (!GeneratePossibleMovesForPlayer(model.Board.CurrentPlayerToMove).Any() && !IsPlayerInCheck(model.Board.CurrentPlayerToMove) || CheckIfKingVsKing() || CheckIfKingKnightVsKing() || CheckIfKingBishopVsKing())
			{
				return true;
			}
		    foreach (var key in model.Board.PositionOccurences)
		    {
		        if (key.Value == 3)
		        {
		            return true;
		        }
		    }
            return false;
		}
    }
}