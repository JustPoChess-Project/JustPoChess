using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using JustPoChess.Client.MVC.View.Input;
using JustPoChess.Client.MVC.View.Messages;
using JustPoChess.Client.MVC.Model;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.Abstract;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;

namespace JustPoChess.Client.MVC.Controller
{
    public class Controller
    {
        private static Controller instance;
        
        private Model.Model model = Model.Model.Instance;

        private Controller()
        {
        }
        
        public static Controller Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Controller();
                }
                return instance;
            }
        }
        
        public static void Start()
        {
            Console.WriteLine(Messages.FontWarrning);
            Console.WriteLine(Messages.FontColorWarrning);
            Thread.Sleep(5000);
            InputUtilities.ClearKeyBuffer();

            View.View.InitialScreen();
            View.View.InitializeMenu();
        }

        public bool IsMovePossible(Move move)
        {
            ICollection<Move> possibleMoves = this.GeneratePossibleMovesForPlayer(Board.Instance.BoardState[move.CurrentPosition.Row, move.CurrentPosition.Col].PieceColor);
            if (possibleMoves.Contains(move))
            {
                return true;
            }
            return false;
        }

        public static bool MoveDiscoversCheckToOwnKing(Move move)
        {
            if (move == null)
            {
                return false;
            }
            if (Board.Instance.BoardState[move.CurrentPosition.Row, move.CurrentPosition.Col] == null)
            {
                return false;
            }
            PieceColor pieceColor = Board.Instance.BoardState[move.CurrentPosition.Row, move.CurrentPosition.Col].PieceColor;
            Board.Instance.PerformMoveOnTestBoard(move);
            foreach (Piece boardPiece in Board.Instance.TestBoardState)
            {
                if (boardPiece != null && boardPiece.PieceColor != pieceColor && PieceGivesCheckToOpponentsKing(boardPiece))
                {
                    return true;
                }
            }
            Board.Instance.RevertTestBoardState();
            return false;
        }

        public static bool PieceGivesCheckToOpponentsKing(Piece piece)
        {
            if (piece == null)
            {
                return false;
            }
            ICollection<Move> possibleMoves = new List<Move>();
            possibleMoves = GeneratePossibleMovesForPieceWithoutConsideringDiscoveringCheck(piece);
            foreach (Piece boardPiece in Board.Instance.BoardState)
            {
                if (boardPiece != null && boardPiece.PieceType == PieceType.King && boardPiece.PieceColor != piece.PieceColor)
                {
                    foreach (Move move in possibleMoves)
                    {
                        if (move.NextPosititon == boardPiece.PiecePosition)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool IsPieceProtected(Piece piece)
        {
            if (piece == null)
            {
                return false;
            }
            IEnumerable<Position> guardedPositionsForAllPieces = new List<Position>();
            foreach (Piece boardPiece in Board.Instance.BoardState)
            {
                if (boardPiece != null && boardPiece.PieceColor == piece.PieceColor)
                {
                    if (GenerateGuardedPositionsForPiece(boardPiece).Contains(piece.PiecePosition))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool ValidatePosition(Position position)
        {
            return position.Row >= 0 && position.Row <= 7 && position.Col >= 0 && position.Col <= 7;
        }

        // Possible moves generator
        public static ICollection<Position> GenerateGuardedPositionsForPiece(Piece piece)
        {
            ICollection<Position> guardedPiecesOnSquares = new List<Position>();
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
                        if (Board.Instance.BoardState[positionOneKing.Row, positionOneKing.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionOneKing.Row, positionOneKing.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionTwoKing.Row, positionTwoKing.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionTwoKing.Row, positionTwoKing.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionThreeKing.Row, positionThreeKing.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionThreeKing.Row, positionThreeKing.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionFourKing.Row, positionFourKing.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionFourKing.Row, positionFourKing.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionFiveKing.Row, positionFiveKing.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionFiveKing.Row, positionFiveKing.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionSixKing.Row, positionSixKing.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionSixKing.Row, positionSixKing.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionSevenKing.Row, positionSevenKing.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionSevenKing.Row, positionSevenKing.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionEightKing.Row, positionEightKing.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionEightKing.Row, positionEightKing.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[piece.PiecePosition.Row, colQueen] != null)
                        {
                            if (Board.Instance.BoardState[piece.PiecePosition.Row, colQueen].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowQueen, piece.PiecePosition.Col] != null)
                        {
                            if (Board.Instance.BoardState[rowQueen, piece.PiecePosition.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[piece.PiecePosition.Row, colQueen] != null)
                        {
                            if (Board.Instance.BoardState[piece.PiecePosition.Row, colQueen].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowQueen, piece.PiecePosition.Col] != null)
                        {
                            if (Board.Instance.BoardState[rowQueen, piece.PiecePosition.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowQueen, colQueen] != null)
                        {
                            if (Board.Instance.BoardState[rowQueen, colQueen].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowQueen, colQueen] != null)
                        {
                            if (Board.Instance.BoardState[rowQueen, colQueen].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowQueen, colQueen] != null)
                        {
                            if (Board.Instance.BoardState[rowQueen, colQueen].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowQueen, colQueen] != null)
                        {
                            if (Board.Instance.BoardState[rowQueen, colQueen].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[piece.PiecePosition.Row, colRook] != null)
                        {
                            if (Board.Instance.BoardState[piece.PiecePosition.Row, colRook].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowRook, piece.PiecePosition.Col] != null)
                        {
                            if (Board.Instance.BoardState[rowRook, piece.PiecePosition.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[piece.PiecePosition.Row, colRook] != null)
                        {
                            if (Board.Instance.BoardState[piece.PiecePosition.Row, colRook].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowRook, piece.PiecePosition.Col] != null)
                        {
                            if (Board.Instance.BoardState[rowRook, piece.PiecePosition.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionOneKnight.Row, positionOneKnight.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionOneKnight.Row, positionOneKnight.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionTwoKnight.Row, positionTwoKnight.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionTwoKnight.Row, positionTwoKnight.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionThreeKnight.Row, positionThreeKnight.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionThreeKnight.Row, positionThreeKnight.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionFourKnight.Row, positionFourKnight.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionFourKnight.Row, positionFourKnight.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionFiveKnight.Row, positionFiveKnight.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionFiveKnight.Row, positionFiveKnight.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionSixKnight.Row, positionSixKnight.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionSixKnight.Row, positionSixKnight.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionSevenKnight.Row, positionSevenKnight.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionSevenKnight.Row, positionSevenKnight.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionEightKnight.Row, positionEightKnight.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionEightKnight.Row, positionEightKnight.Col].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowBishop, colBishop] != null)
                        {
                            if (Board.Instance.BoardState[rowBishop, colBishop].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowBishop, colBishop] != null)
                        {
                            if (Board.Instance.BoardState[rowBishop, colBishop].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowBishop, colBishop] != null)
                        {
                            if (Board.Instance.BoardState[rowBishop, colBishop].PieceColor == piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowBishop, colBishop] != null)
                        {
                            if (Board.Instance.BoardState[rowBishop, colBishop].PieceColor == piece.PieceColor)
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
                            if (Board.Instance.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 1] != null)
                            {
                                if (Board.Instance.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 1].PieceColor == PieceColor.White)
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
                            if (Board.Instance.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1] != null)
                            {
                                if (Board.Instance.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1].PieceColor == PieceColor.White)
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
                            if (Board.Instance.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1] != null)
                            {
                                if (Board.Instance.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1].PieceColor == PieceColor.Black)
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
                            if (Board.Instance.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1] != null)
                            {
                                if (Board.Instance.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1].PieceColor == PieceColor.Black)
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

        public ICollection<Move> GeneratePossibleMovesForPieceConsideringDiscoveringCheck(Piece piece)
        {
            ICollection<Move> possibleMoves = new List<Move>();
            possibleMoves = GeneratePossibleMovesForPieceWithoutConsideringDiscoveringCheck(piece);
            foreach (Move move in possibleMoves)
            {
                if (MoveDiscoversCheckToOwnKing(move))
                {
                    possibleMoves.Remove(move);
                }
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

        public static ICollection<Move> GeneratePossibleMovesForPieceWithoutConsideringDiscoveringCheck(Piece piece)
        {
            ICollection<Move> possibleMoves = new List<Move>();
            if (piece == null)
            {
                return possibleMoves;
            }
            switch (piece.PieceType)
            {
                case PieceType.King:
                    IEnumerable<Position> allGuardedPositionsByOpponent = new List<Position>();
                    foreach (Piece boardPiece in Board.Instance.BoardState)
                    {
                        if (boardPiece != null && boardPiece.PieceColor != piece.PieceColor)
                        {
                            allGuardedPositionsByOpponent = allGuardedPositionsByOpponent.Concat(GenerateGuardedPositionsForPiece(boardPiece));
                        }
                    }

                    Position positionOneKing = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1);
                    if (ValidatePosition(positionOneKing) && !allGuardedPositionsByOpponent.Contains(positionOneKing))
                    {
                        if (Board.Instance.BoardState[positionOneKing.Row, positionOneKing.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionOneKing.Row, positionOneKing.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionTwoKing.Row, positionTwoKing.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionTwoKing.Row, positionTwoKing.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionThreeKing.Row, positionThreeKing.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionThreeKing.Row, positionThreeKing.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionFourKing.Row, positionFourKing.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionFourKing.Row, positionFourKing.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionFiveKing.Row, positionFiveKing.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionFiveKing.Row, positionFiveKing.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionSixKing.Row, positionSixKing.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionSixKing.Row, positionSixKing.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionSevenKing.Row, positionSevenKing.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionSevenKing.Row, positionSevenKing.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionEightKing.Row, positionEightKing.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionEightKing.Row, positionEightKing.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[piece.PiecePosition.Row, colQueen] != null)
                        {
                            if (Board.Instance.BoardState[piece.PiecePosition.Row, colQueen].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowQueen, piece.PiecePosition.Col] != null)
                        {
                            if (Board.Instance.BoardState[rowQueen, piece.PiecePosition.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[piece.PiecePosition.Row, colQueen] != null)
                        {
                            if (Board.Instance.BoardState[piece.PiecePosition.Row, colQueen].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowQueen, piece.PiecePosition.Col] != null)
                        {
                            if (Board.Instance.BoardState[rowQueen, piece.PiecePosition.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowQueen, colQueen] != null)
                        {
                            if (Board.Instance.BoardState[rowQueen, colQueen].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowQueen, colQueen] != null)
                        {
                            if (Board.Instance.BoardState[rowQueen, colQueen].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowQueen, colQueen] != null)
                        {
                            if (Board.Instance.BoardState[rowQueen, colQueen].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowQueen, colQueen] != null)
                        {
                            if (Board.Instance.BoardState[rowQueen, colQueen].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[piece.PiecePosition.Row, colRook] != null)
                        {
                            if (Board.Instance.BoardState[piece.PiecePosition.Row, colRook].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowRook, piece.PiecePosition.Col] != null)
                        {
                            if (Board.Instance.BoardState[rowRook, piece.PiecePosition.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[piece.PiecePosition.Row, colRook] != null)
                        {
                            if (Board.Instance.BoardState[piece.PiecePosition.Row, colRook].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowRook, piece.PiecePosition.Col] != null)
                        {
                            if (Board.Instance.BoardState[rowRook, piece.PiecePosition.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionOneKnight.Row, positionOneKnight.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionOneKnight.Row, positionOneKnight.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionTwoKnight.Row, positionTwoKnight.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionTwoKnight.Row, positionTwoKnight.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionThreeKnight.Row, positionThreeKnight.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionThreeKnight.Row, positionThreeKnight.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionFourKnight.Row, positionFourKnight.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionFourKnight.Row, positionFourKnight.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionFiveKnight.Row, positionFiveKnight.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionFiveKnight.Row, positionFiveKnight.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionSixKnight.Row, positionSixKnight.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionSixKnight.Row, positionSixKnight.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionSevenKnight.Row, positionSevenKnight.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionSevenKnight.Row, positionSevenKnight.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[positionEightKnight.Row, positionEightKnight.Col] != null)
                        {
                            if (Board.Instance.BoardState[positionEightKnight.Row, positionEightKnight.Col].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowBishop, colBishop] != null)
                        {
                            if (Board.Instance.BoardState[rowBishop, colBishop].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowBishop, colBishop] != null)
                        {
                            if (Board.Instance.BoardState[rowBishop, colBishop].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowBishop, colBishop] != null)
                        {
                            if (Board.Instance.BoardState[rowBishop, colBishop].PieceColor != piece.PieceColor)
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
                        if (Board.Instance.BoardState[rowBishop, colBishop] != null)
                        {
                            if (Board.Instance.BoardState[rowBishop, colBishop].PieceColor != piece.PieceColor)
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
                        if (ValidatePosition(positionOnePawn) && Board.Instance.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 1] != null && Board.Instance.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 1].PieceColor == PieceColor.Black)
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionOnePawn));
                        }
                        if (ValidatePosition(positionTwoPawn) && Board.Instance.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1] != null && Board.Instance.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1].PieceColor == PieceColor.Black)
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionTwoPawn));
                        }
                        Position positionThreePawn = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col);
                        if (ValidatePosition(positionThreePawn) && Board.Instance.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col] == null)
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionThreePawn));
                        }
                        if (piece.PiecePosition.Row == 6)
                        {
                            Position positionFourPawn = new Position(piece.PiecePosition.Row - 2, piece.PiecePosition.Col);
                            if (Board.Instance.BoardState[piece.PiecePosition.Row - 2, piece.PiecePosition.Col] == null && Board.Instance.BoardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col] == null)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionFourPawn));
                            }
                        }
                    }
                    else
                    {
                        Position positionOnePawn = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1);
                        Position positionTwoPawn = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1);
                        if (ValidatePosition(positionOnePawn) && Board.Instance.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1] != null && Board.Instance.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1].PieceColor == PieceColor.White)
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionOnePawn));
                        }
                        if (ValidatePosition(positionTwoPawn) && Board.Instance.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1] != null && Board.Instance.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1].PieceColor == PieceColor.White)
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionTwoPawn));
                        }
                        Position positionThreePawn = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col);
                        if (ValidatePosition(positionThreePawn) && Board.Instance.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col] == null)
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionThreePawn));
                        }
                        if (piece.PiecePosition.Row == 1)
                        {
                            Position positionFourPawn = new Position(piece.PiecePosition.Row + 2, piece.PiecePosition.Col);
                            if (Board.Instance.BoardState[piece.PiecePosition.Row + 2, piece.PiecePosition.Col] == null && Board.Instance.BoardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col] == null)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionFourPawn));
                            }
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid piece");
            }
            return possibleMoves;
        }

        public ICollection<Move> GeneratePossibleMovesForPlayer(PieceColor pieceColor)
        {
            ICollection<Move> possibleMoves = new List<Move>();
            foreach (Piece boardPiece in Board.Instance.BoardState)
            {
                if (boardPiece != null && boardPiece.PieceColor == pieceColor)
                {
                    possibleMoves = (System.Collections.Generic.ICollection<JustPoChess.Client.MVC.Model.Entities.Board.Move>)possibleMoves.Concat(this.GeneratePossibleMovesForPieceConsideringDiscoveringCheck(boardPiece));
                }
            }
            return possibleMoves;
        }

        // Player Check
        public static bool IsPlayerInCheck(PieceColor pieceColor)
        {
            foreach (Piece boardPiece in Board.Instance.BoardState)
            {
                if (boardPiece != null && boardPiece.PieceColor != pieceColor && PieceGivesCheckToOpponentsKing(boardPiece))
                {
                    return true;
                }
            }
            return false;
        }

        //Castle Checks
        public bool IsCurrentPlayerLeftCastlePossible()
        {
            switch (this.model.CurrentPlayerToMove)
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
            switch (model.CurrentPlayerToMove)
            {
                case PieceColor.White:
                    return IsWhiteRightCastlePossible();
                case PieceColor.Black:
                    return IsBlackRightCastlePossible();
                default:
                    throw new ArgumentException("Invalid current player");
            }
        }

        public static bool IsWhiteLeftCastlePossible()
        {
            if (Board.Instance.WhiteLeftCastlePossible) // has white moved the left rook / king
            {
                if (!IsPlayerInCheck(PieceColor.White)) // is white in check
                {
                    if (Board.Instance.BoardState[7, 1] == null && Board.Instance.BoardState[7, 2] == null && Board.Instance.BoardState[7, 3] == null) // are there pieces between the left white rook and the white king
                    {
                        IEnumerable<Position> guardedPositionsForAllPieces = new List<Position>();
                        foreach (Piece boardPiece in Board.Instance.BoardState)
                        {
                            if (boardPiece != null && boardPiece.PieceColor == PieceColor.Black)
                            {
                                guardedPositionsForAllPieces = guardedPositionsForAllPieces.Concat(GenerateGuardedPositionsForPiece(boardPiece));
                            }
                        }
                        if (!guardedPositionsForAllPieces.Contains(new Position(7, 2)) && !guardedPositionsForAllPieces.Contains(new Position(7, 3))) // are there squares that the white king has to go through that are attacked
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool IsWhiteRightCastlePossible()
        {
            if (Board.Instance.WhiteRightCastlePossible)
            {
                if (!IsPlayerInCheck(PieceColor.White))
                {
                    if (Board.Instance.BoardState[7, 5] == null && Board.Instance.BoardState[7, 6] == null)
                    {
                        IEnumerable<Position> guardedPositionsForAllPieces = new List<Position>();
                        foreach (Piece boardPiece in Board.Instance.BoardState)
                        {
                            if (boardPiece != null && boardPiece.PieceColor == PieceColor.Black)
                            {
                                guardedPositionsForAllPieces = guardedPositionsForAllPieces.Concat(GenerateGuardedPositionsForPiece(boardPiece));
                            }
                        }
                        if (!guardedPositionsForAllPieces.Contains(new Position(7, 5)) && !guardedPositionsForAllPieces.Contains(new Position(7, 6)))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool IsBlackLeftCastlePossible()
        {
            if (Board.Instance.BlackLeftCastlePossible)
            {
                if (!IsPlayerInCheck(PieceColor.Black))
                {
                    if (Board.Instance.BoardState[0, 1] == null && Board.Instance.BoardState[0, 2] == null && Board.Instance.BoardState[0, 3] == null)
                    {
                        IEnumerable<Position> guardedPositionsForAllPieces = new List<Position>();
                        foreach (Piece boardPiece in Board.Instance.BoardState)
                        {
                            if (boardPiece != null && boardPiece.PieceColor == PieceColor.White)
                            {
                                guardedPositionsForAllPieces = guardedPositionsForAllPieces.Concat(GenerateGuardedPositionsForPiece(boardPiece));
                            }
                        }
                        if (!guardedPositionsForAllPieces.Contains(new Position(0, 2)) && !guardedPositionsForAllPieces.Contains(new Position(0, 3)))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool IsBlackRightCastlePossible()
        {
            if (Board.Instance.BlackRightCastlePossible)
            {
                if (!IsPlayerInCheck(PieceColor.Black))
                {
                    if (Board.Instance.BoardState[0, 5] == null && Board.Instance.BoardState[0, 6] == null)
                    {
                        IEnumerable<Position> guardedPositionsForAllPieces = new List<Position>();
                        foreach (Piece boardPiece in Board.Instance.BoardState)
                        {
                            if (boardPiece != null && boardPiece.PieceColor == PieceColor.White)
                            {
                                guardedPositionsForAllPieces = guardedPositionsForAllPieces.Concat(GenerateGuardedPositionsForPiece(boardPiece));
                            }
                        }
                        if (!guardedPositionsForAllPieces.Contains(new Position(0, 5)) && !guardedPositionsForAllPieces.Contains(new Position(0, 6)))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }



        // GameState Checks
        public bool CheckForDraw()
        {
            if ((GeneratePossibleMovesForPlayer(model.CurrentPlayerToMove).Count == 0 && !IsPlayerInCheck(model.CurrentPlayerToMove)) || CheckIfKingVsKing())
            {
                return true;
            }
            return false;
        }

        public bool CheckForCheckmate()
        {
            if (GeneratePossibleMovesForPlayer(model.CurrentPlayerToMove).Count == 0 && IsPlayerInCheck(model.CurrentPlayerToMove))
            {
                return true;
            }
            return false;
        }

        private bool CheckIfKingVsKing()
        {
            foreach (Piece boardPiece in Board.Instance.BoardState)
            {
                if (boardPiece != null && boardPiece.PieceType != PieceType.King)
                {
                    return false;
                }
            }
            return true;
        }
    }
}