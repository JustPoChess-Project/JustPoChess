using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.Abstract;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;
using JustPoChess.Client.MVC.View.Input;
using JustPoChess.Client.MVC.View.Messages;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;

namespace JustPoChess.Client.MVC.Controller
{
    public static class Controller
    {
        public static void Start()
        {
            Console.WriteLine(Messages.FontWarrning);
            Console.WriteLine(Messages.FontColorWarrning);
            Thread.Sleep(5000);
            InputUtilities.ClearKeyBuffer();

            View.View.InitialScreen();
            View.View.InitializeMenu();
        }

        public static void StartHotSeat()
        {
            Model.Model.InitBoard();
            Console.Clear();
            View.View.MirrorPrintBoard();

            while (true)
            {

            }
        }

        public static bool MoveDiscoversCheckToOwnKing(Move move)
        {
            PieceColor pieceColor = Board.boardState[move.CurrentPosition.Row, move.CurrentPosition.Col].PieceColor;
            Board.PerformMoveOnTestBoard(move);
            foreach (Piece boardPiece in Board.testBoardState)
            {
                if (boardPiece.PieceColor != pieceColor && PieceGivesCheckToOpponentsKing(boardPiece))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool PieceGivesCheckToOpponentsKing(Piece piece)
        {
            List<Move> possibleMoves = new List<Move>();
            possibleMoves = GeneratePossibleMovesForPiece(piece);
            foreach (Piece boardPiece in Board.boardState)
            {
                if (boardPiece.PieceType == PieceType.King && boardPiece.PieceColor != piece.PieceColor)
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
            List<Position> guardedPositionsForAllPieces = new List<Position>();
            foreach (Piece boardPiece in Board.boardState)
            {
                if (boardPiece.PieceColor == piece.PieceColor)
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

        public static List<Position> GenerateGuardedPositionsForPiece(Piece piece)
        {
            List<Position> guardedPiecesOnSquares = new List<Position>();
            switch (piece.PieceType)
            {
                case PieceType.King:
                    Position positionOneKing = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1);
                    if (ValidatePosition(positionOneKing) && Board.boardState[positionOneKing.Row, positionOneKing.Col] != null && Board.boardState[positionOneKing.Row, positionOneKing.Col].PieceColor == piece.PieceColor)
                    {
                        guardedPiecesOnSquares.Add(positionOneKing);
                    }
                    Position positionTwoKing = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col);
                    if (ValidatePosition(positionTwoKing) && Board.boardState[positionTwoKing.Row, positionTwoKing.Col] != null && Board.boardState[positionTwoKing.Row, positionTwoKing.Col].PieceColor == piece.PieceColor)
                    {
                        guardedPiecesOnSquares.Add(positionTwoKing);
                    }
                    Position positionThreeKing = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 1);
                    if (ValidatePosition(positionThreeKing) && Board.boardState[positionThreeKing.Row, positionThreeKing.Col] != null && Board.boardState[positionThreeKing.Row, positionThreeKing.Col].PieceColor == piece.PieceColor)
                    {
                        guardedPiecesOnSquares.Add(positionThreeKing);
                    }
                    Position positionFourKing = new Position(piece.PiecePosition.Row, piece.PiecePosition.Col - 1);
                    if (ValidatePosition(positionFourKing) && Board.boardState[positionFourKing.Row, positionFourKing.Col] != null && Board.boardState[positionFourKing.Row, positionFourKing.Col].PieceColor == piece.PieceColor)
                    {
                        guardedPiecesOnSquares.Add(positionFourKing);
                    }
                    Position positionFiveKing = new Position(piece.PiecePosition.Row, piece.PiecePosition.Col + 1);
                    if (ValidatePosition(positionFiveKing) && Board.boardState[positionFiveKing.Row, positionFiveKing.Col] != null && Board.boardState[positionFiveKing.Row, positionFiveKing.Col].PieceColor == piece.PieceColor)
                    {
                        guardedPiecesOnSquares.Add(positionFiveKing);
                    }
                    Position positionSixKing = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1);
                    if (ValidatePosition(positionSixKing) && Board.boardState[positionSixKing.Row, positionSixKing.Col] != null && Board.boardState[positionSixKing.Row, positionSixKing.Col].PieceColor == piece.PieceColor)
                    {
                        guardedPiecesOnSquares.Add(positionSixKing);
                    }
                    Position positionSevenKing = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col);
                    if (ValidatePosition(positionSevenKing) && Board.boardState[positionSevenKing.Row, positionSevenKing.Col] != null && Board.boardState[positionSevenKing.Row, positionSevenKing.Col].PieceColor == piece.PieceColor)
                    {
                        guardedPiecesOnSquares.Add(positionSevenKing);
                    }
                    Position positionEightKing = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1);
                    if (ValidatePosition(positionEightKing) && Board.boardState[positionEightKing.Row, positionEightKing.Col] != null && Board.boardState[positionEightKing.Row, positionEightKing.Col].PieceColor == piece.PieceColor)
                    {
                        guardedPiecesOnSquares.Add(positionEightKing);
                    }
                    break;
                case PieceType.Queen:
                    int colQueen = piece.PiecePosition.Col--;
                    while (colQueen >= 0)
                    {
                        if (Board.boardState[piece.PiecePosition.Row, colQueen] != null)
                        {
                            if (Board.boardState[piece.PiecePosition.Row, colQueen].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(piece.PiecePosition.Row, colQueen));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        colQueen--;
                    }
                    int rowQueen = piece.PiecePosition.Row--;
                    while (rowQueen >= 0)
                    {
                        if (Board.boardState[rowQueen, piece.PiecePosition.Col] != null)
                        {
                            if (Board.boardState[rowQueen, piece.PiecePosition.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowQueen, piece.PiecePosition.Col));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        rowQueen--;
                    }
                    colQueen = piece.PiecePosition.Col++;
                    while (colQueen <= 7)
                    {
                        if (Board.boardState[piece.PiecePosition.Row, colQueen] != null)
                        {
                            if (Board.boardState[piece.PiecePosition.Row, colQueen].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(piece.PiecePosition.Row, colQueen));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        colQueen++;
                    }
                    rowQueen = piece.PiecePosition.Row++;
                    while (rowQueen <= 7)
                    {
                        if (Board.boardState[rowQueen, piece.PiecePosition.Col] != null)
                        {
                            if (Board.boardState[rowQueen, piece.PiecePosition.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowQueen, piece.PiecePosition.Col));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        rowQueen++;
                    }
                    rowQueen = piece.PiecePosition.Row--;
                    colQueen = piece.PiecePosition.Col--;
                    while (rowQueen >= 0 && colQueen >= 0)
                    {
                        if (Board.boardState[rowQueen, colQueen] != null)
                        {
                            if (Board.boardState[rowQueen, colQueen].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowQueen, colQueen));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        rowQueen--;
                        colQueen--;
                    }
                    rowQueen = piece.PiecePosition.Row--;
                    colQueen = piece.PiecePosition.Col++;
                    while (rowQueen >= 0 && colQueen <= 7)
                    {
                        if (Board.boardState[rowQueen, colQueen] != null)
                        {
                            if (Board.boardState[rowQueen, colQueen].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowQueen, colQueen));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        rowQueen--;
                        colQueen++;
                    }
                    rowQueen = piece.PiecePosition.Row++;
                    colQueen = piece.PiecePosition.Col++;
                    while (rowQueen <= 7 && colQueen <= 7)
                    {
                        if (Board.boardState[rowQueen, colQueen] != null)
                        {
                            if (Board.boardState[rowQueen, colQueen].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowQueen, colQueen));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        rowQueen++;
                        colQueen++;
                    }
                    rowQueen = piece.PiecePosition.Row++;
                    colQueen = piece.PiecePosition.Col--;
                    while (rowQueen <= 7 && colQueen >= 0)
                    {
                        if (Board.boardState[rowQueen, colQueen] != null)
                        {
                            if (Board.boardState[rowQueen, colQueen].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowQueen, colQueen));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        rowQueen++;
                        colQueen--;
                    }
                    break;
                case PieceType.Rook:
                    int colRook = piece.PiecePosition.Col--;
                    while (colRook >= 0)
                    {
                        if (Board.boardState[piece.PiecePosition.Row, colRook] != null)
                        {
                            if (Board.boardState[piece.PiecePosition.Row, colRook].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(piece.PiecePosition.Row, colRook));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        colRook--;
                    }
                    int rowRook = piece.PiecePosition.Row--;
                    while (rowRook >= 0)
                    {
                        if (Board.boardState[rowRook, piece.PiecePosition.Col] != null)
                        {
                            if (Board.boardState[rowRook, piece.PiecePosition.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowRook, piece.PiecePosition.Col));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        rowRook--;
                    }
                    colRook = piece.PiecePosition.Col++;
                    while (colRook <= 7)
                    {
                        if (Board.boardState[piece.PiecePosition.Row, colRook] != null)
                        {
                            if (Board.boardState[piece.PiecePosition.Row, colRook].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(piece.PiecePosition.Row, colRook));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        colRook++;
                    }
                    rowRook = piece.PiecePosition.Row++;
                    while (rowRook <= 7)
                    {
                        if (Board.boardState[rowRook, piece.PiecePosition.Col] != null)
                        {
                            if (Board.boardState[rowRook, piece.PiecePosition.Col].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowRook, piece.PiecePosition.Col));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        rowRook++;
                    }
                    break;
                case PieceType.Knight:
                    Position positionOneKnight = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 2);
                    if (ValidatePosition(positionOneKnight) && Board.boardState[positionOneKnight.Row, positionOneKnight.Col] != null && Board.boardState[positionOneKnight.Row, positionOneKnight.Col].PieceColor == piece.PieceColor)
                    {
                        guardedPiecesOnSquares.Add(positionOneKnight);
                    }
                    Position positionTwoKnight = new Position(piece.PiecePosition.Row - 2, piece.PiecePosition.Col - 1);
                    if (ValidatePosition(positionTwoKnight) && Board.boardState[positionTwoKnight.Row, positionTwoKnight.Col] != null && Board.boardState[positionTwoKnight.Row, positionTwoKnight.Col].PieceColor == piece.PieceColor)
                    {
                        guardedPiecesOnSquares.Add(positionTwoKnight);
                    }
                    Position positionThreeKnight = new Position(piece.PiecePosition.Row - 2, piece.PiecePosition.Col + 1);
                    if (ValidatePosition(positionThreeKnight) && Board.boardState[positionThreeKnight.Row, positionThreeKnight.Col] != null && Board.boardState[positionThreeKnight.Row, positionThreeKnight.Col].PieceColor == piece.PieceColor)
                    {
                        guardedPiecesOnSquares.Add(positionThreeKnight);
                    }
                    Position positionFourKnight = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 2);
                    if (ValidatePosition(positionFourKnight) && Board.boardState[positionFourKnight.Row, positionFourKnight.Col] != null && Board.boardState[positionFourKnight.Row, positionFourKnight.Col].PieceColor == piece.PieceColor)
                    {
                        guardedPiecesOnSquares.Add(positionFourKnight);
                    }
                    Position positionFiveKnight = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 2);
                    if (ValidatePosition(positionFiveKnight) && Board.boardState[positionFiveKnight.Row, positionFiveKnight.Col] != null && Board.boardState[positionFiveKnight.Row, positionFiveKnight.Col].PieceColor == piece.PieceColor)
                    {
                        guardedPiecesOnSquares.Add(positionFiveKnight);
                    }
                    Position positionSixKnight = new Position(piece.PiecePosition.Row + 2, piece.PiecePosition.Col + 1);
                    if (ValidatePosition(positionSixKnight) && Board.boardState[positionSixKnight.Row, positionSixKnight.Col] != null && Board.boardState[positionSixKnight.Row, positionSixKnight.Col].PieceColor == piece.PieceColor)
                    {
                        guardedPiecesOnSquares.Add(positionSixKnight);
                    }
                    Position positionSevenKnight = new Position(piece.PiecePosition.Row + 2, piece.PiecePosition.Col - 1);
                    if (ValidatePosition(positionSevenKnight) && Board.boardState[positionSevenKnight.Row, positionSevenKnight.Col] != null && Board.boardState[positionSevenKnight.Row, positionSevenKnight.Col].PieceColor == piece.PieceColor)
                    {
                        guardedPiecesOnSquares.Add(positionSevenKnight);
                    }
                    Position positionEightKnight = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 2);
                    if (ValidatePosition(positionEightKnight) && Board.boardState[positionEightKnight.Row, positionEightKnight.Col] != null && Board.boardState[positionEightKnight.Row, positionEightKnight.Col].PieceColor == piece.PieceColor)
                    {
                        guardedPiecesOnSquares.Add(positionEightKnight);
                    }
                    break;
                case PieceType.Bishop:
                    int rowBishop = piece.PiecePosition.Row--;
                    int colBishop = piece.PiecePosition.Col--;
                    while (rowBishop >= 0 && colBishop >= 0)
                    {
                        if (Board.boardState[rowBishop, colBishop] != null)
                        {
                            if (Board.boardState[rowBishop, colBishop].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowBishop, colBishop));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        rowBishop--;
                        colBishop--;
                    }
                    rowBishop = piece.PiecePosition.Row--;
                    colBishop = piece.PiecePosition.Col++;
                    while (rowBishop >= 0 && colBishop <= 7)
                    {
                        if (Board.boardState[rowBishop, colBishop] != null)
                        {
                            if (Board.boardState[rowBishop, colBishop].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowBishop, colBishop));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        rowBishop--;
                        colBishop++;
                    }
                    rowBishop = piece.PiecePosition.Row++;
                    colBishop = piece.PiecePosition.Col++;
                    while (rowBishop <= 7 && colBishop <= 7)
                    {
                        if (Board.boardState[rowBishop, colBishop] != null)
                        {
                            if (Board.boardState[rowBishop, colBishop].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowBishop, colBishop));
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        rowBishop++;
                        colBishop++;
                    }
                    rowBishop = piece.PiecePosition.Row++;
                    colBishop = piece.PiecePosition.Col--;
                    while (rowBishop <= 7 && colBishop >= 0)
                    {
                        if (Board.boardState[rowBishop, colBishop] != null)
                        {
                            if (Board.boardState[rowBishop, colBishop].PieceColor == piece.PieceColor)
                            {
                                guardedPiecesOnSquares.Add(new Position(rowBishop, colBishop));
                                break;
                            }
                            else
                            {
                                break;
                            }
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
                        if (ValidatePosition(positionOnePawn) && Board.boardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 1] != null && Board.boardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 1].PieceColor == PieceColor.White)
                        {
                            guardedPiecesOnSquares.Add(positionOnePawn);
                        }
                        if (ValidatePosition(positionTwoPawn) && Board.boardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1] != null && Board.boardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1].PieceColor == PieceColor.White)
                        {
                            guardedPiecesOnSquares.Add(positionTwoPawn);
                        }
                    }
                    else
                    {
                        Position positionOnePawn = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1);
                        Position positionTwoPawn = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1);
                        if (ValidatePosition(positionOnePawn) && Board.boardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1] != null && Board.boardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1].PieceColor == PieceColor.Black)
                        {
                            guardedPiecesOnSquares.Add(positionOnePawn);
                        }
                        if (ValidatePosition(positionTwoPawn) && Board.boardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1] != null && Board.boardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1].PieceColor == PieceColor.Black)
                        {
                            guardedPiecesOnSquares.Add(positionTwoPawn);
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid piece");
            }
            return guardedPiecesOnSquares;
        }

        public static List<Move> GeneratePossibleMovesForPiece(Piece piece)
        {
            List<Move> possibleMoves = new List<Move>();
            switch (piece.PieceType)
            {
                case PieceType.King:
                    break;
                case PieceType.Queen:
                    break;
                case PieceType.Rook:
                    int colRook = piece.PiecePosition.Col--;
                    while (colRook >= 0)
                    {
                        if (Board.boardState[piece.PiecePosition.Row, colRook] != null)
                        {
                            if (Board.boardState[piece.PiecePosition.Row, colRook].PieceColor != piece.PieceColor)
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
                    int rowRook = piece.PiecePosition.Row--;
                    while (rowRook >= 0)
                    {
                        if (Board.boardState[rowRook, piece.PiecePosition.Col] != null)
                        {
                            if (Board.boardState[rowRook, piece.PiecePosition.Col].PieceColor != piece.PieceColor)
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
                            possibleMoves.Add(new Move(piece.PiecePosition, new Position(piece.PiecePosition.Row, colRook)));
                        }
                        rowRook--;
                    }
                    colRook = piece.PiecePosition.Col++;
                    while (colRook <= 7)
                    {
                        if (Board.boardState[piece.PiecePosition.Row, colRook] != null)
                        {
                            if (Board.boardState[piece.PiecePosition.Row, colRook].PieceColor != piece.PieceColor)
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
                    rowRook = piece.PiecePosition.Row++;
                    while (rowRook <= 7)
                    {
                        if (Board.boardState[rowRook, piece.PiecePosition.Col] != null)
                        {
                            if (Board.boardState[rowRook, piece.PiecePosition.Col].PieceColor != piece.PieceColor)
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
                            possibleMoves.Add(new Move(piece.PiecePosition, new Position(piece.PiecePosition.Row, colRook)));
                        }
                        rowRook++;
                    }
                    break;
                case PieceType.Knight:
                    Position positionOneKnight = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 2);
                    if (ValidatePosition(positionOneKnight) && Board.boardState[positionOneKnight.Row, positionOneKnight.Col] != null && Board.boardState[positionOneKnight.Row, positionOneKnight.Col].PieceColor != piece.PieceColor)
                    {
                        possibleMoves.Add(new Move(piece.PiecePosition, positionOneKnight));
                    }
                    Position positionTwoKnight = new Position(piece.PiecePosition.Row - 2, piece.PiecePosition.Col - 1);
                    if (ValidatePosition(positionTwoKnight) && Board.boardState[positionTwoKnight.Row, positionTwoKnight.Col] != null && Board.boardState[positionTwoKnight.Row, positionTwoKnight.Col].PieceColor != piece.PieceColor)
                    {
                        possibleMoves.Add(new Move(piece.PiecePosition, positionTwoKnight));
                    }
                    Position positionThreeKnight = new Position(piece.PiecePosition.Row - 2, piece.PiecePosition.Col + 1);
                    if (ValidatePosition(positionThreeKnight) && Board.boardState[positionThreeKnight.Row, positionThreeKnight.Col] != null && Board.boardState[positionThreeKnight.Row, positionThreeKnight.Col].PieceColor != piece.PieceColor)
                    {
                        possibleMoves.Add(new Move(piece.PiecePosition, positionThreeKnight));
                    }
                    Position positionFourKnight = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 2);
                    if (ValidatePosition(positionFourKnight) && Board.boardState[positionFourKnight.Row, positionFourKnight.Col] != null && Board.boardState[positionFourKnight.Row, positionFourKnight.Col].PieceColor != piece.PieceColor)
                    {
                        possibleMoves.Add(new Move(piece.PiecePosition, positionFourKnight));
                    }
                    Position positionFiveKnight = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 2);
                    if (ValidatePosition(positionFiveKnight) && Board.boardState[positionFiveKnight.Row, positionFiveKnight.Col] != null && Board.boardState[positionFiveKnight.Row, positionFiveKnight.Col].PieceColor != piece.PieceColor)
                    {
                        possibleMoves.Add(new Move(piece.PiecePosition, positionFiveKnight));
                    }
                    Position positionSixKnight = new Position(piece.PiecePosition.Row + 2, piece.PiecePosition.Col + 1);
                    if (ValidatePosition(positionSixKnight) && Board.boardState[positionSixKnight.Row, positionSixKnight.Col] != null && Board.boardState[positionSixKnight.Row, positionSixKnight.Col].PieceColor != piece.PieceColor)
                    {
                        possibleMoves.Add(new Move(piece.PiecePosition, positionSixKnight));
                    }
                    Position positionSevenKnight = new Position(piece.PiecePosition.Row + 2, piece.PiecePosition.Col - 1);
                    if (ValidatePosition(positionSevenKnight) && Board.boardState[positionSevenKnight.Row, positionSevenKnight.Col] != null && Board.boardState[positionSevenKnight.Row, positionSevenKnight.Col].PieceColor != piece.PieceColor)
                    {
                        possibleMoves.Add(new Move(piece.PiecePosition, positionSevenKnight));
                    }
                    Position positionEightKnight = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 2);
                    if (ValidatePosition(positionEightKnight) && Board.boardState[positionEightKnight.Row, positionEightKnight.Col] != null && Board.boardState[positionEightKnight.Row, positionEightKnight.Col].PieceColor != piece.PieceColor)
                    {
                        possibleMoves.Add(new Move(piece.PiecePosition, positionEightKnight));
                    }
                    break;
                case PieceType.Bishop:
                    break;
                case PieceType.Pawn:
                    if (piece.PieceColor == PieceColor.White)
                    {
                        Position positionOnePawn = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 1);
                        Position positionTwoPawn = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1);
                        if (ValidatePosition(positionOnePawn) && Board.boardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 1] != null && Board.boardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col + 1].PieceColor == PieceColor.Black)
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionOnePawn));
                        }
                        if (ValidatePosition(positionTwoPawn) && Board.boardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1] != null && Board.boardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col - 1].PieceColor == PieceColor.Black)
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionTwoPawn));
                        }
                        Position positionThreePawn = new Position(piece.PiecePosition.Row - 1, piece.PiecePosition.Col);
                        if (ValidatePosition(positionThreePawn) && Board.boardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col] == null)
                        {
                            possibleMoves.Add(new Move(piece.PiecePosition, positionThreePawn));
                        }
                        if (piece.PiecePosition.Row == 6)
                        {
                            Position positionFourPawn = new Position(piece.PiecePosition.Row - 2, piece.PiecePosition.Col);
                            if (Board.boardState[piece.PiecePosition.Row - 2, piece.PiecePosition.Col] == null && Board.boardState[piece.PiecePosition.Row - 1, piece.PiecePosition.Col] == null)
                            {
                                possibleMoves.Add(new Move(piece.PiecePosition, positionFourPawn));
                            }
                        }
                    }
                    else
                    {
						Position positionOnePawn = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1);
						Position positionTwoPawn = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1);
                        if (ValidatePosition(positionOnePawn) && Board.boardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1] != null && Board.boardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col + 1].PieceColor == PieceColor.White)
						{
							possibleMoves.Add(new Move(piece.PiecePosition, positionOnePawn));
						}
                        if (ValidatePosition(positionTwoPawn) && Board.boardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1] != null && Board.boardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col - 1].PieceColor == PieceColor.White)
						{
							possibleMoves.Add(new Move(piece.PiecePosition, positionTwoPawn));
						}
						Position positionThreePawn = new Position(piece.PiecePosition.Row + 1, piece.PiecePosition.Col);
						if (ValidatePosition(positionThreePawn) && Board.boardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col] == null)
						{
							possibleMoves.Add(new Move(piece.PiecePosition, positionThreePawn));
						}
						if (piece.PiecePosition.Row == 1)
						{
							Position positionFourPawn = new Position(piece.PiecePosition.Row + 2, piece.PiecePosition.Col);
							if (Board.boardState[piece.PiecePosition.Row + 2, piece.PiecePosition.Col] == null && Board.boardState[piece.PiecePosition.Row + 1, piece.PiecePosition.Col] == null)
							{
								possibleMoves.Add(new Move(piece.PiecePosition, positionFourPawn));
							}
						}
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid piece");
            }
            throw new NotImplementedException();
            foreach (Move move in possibleMoves)
            {
                if (MoveDiscoversCheckToOwnKing(move))
                {
                    possibleMoves.Remove(move);
                }
            }
            return possibleMoves;
        }

        public static bool IsMovePossible(Move move)
        {
            List<Move> possibleMoves = GeneratePossibleMovesForPlayer(Board.boardState[move.CurrentPosition.Row, move.CurrentPosition.Col].PieceColor);
            if (possibleMoves.Contains(move))
            {
                return true;
            }
            return false;
        }

        public static bool IsPlayerInCheck(PieceColor pieceColor)
        {
            foreach (Piece boardPiece in Board.boardState)
            {
                if (boardPiece.PieceColor != pieceColor && PieceGivesCheckToOpponentsKing(boardPiece))
                {
                    return true;
                }
            }
            return false;
        }

        public static List<Move> GeneratePossibleMovesForPlayer(PieceColor pieceColor)
        {
            List<Move> possibleMoves = new List<Move>();
            foreach (Piece boardPiece in Board.boardState)
            {
                if (boardPiece.PieceColor == pieceColor)
                {
                    possibleMoves.Concat(GeneratePossibleMovesForPiece(boardPiece));
                }
            }
            return possibleMoves;
        }

        public static bool CheckForDraw()
        {
            if ((GeneratePossibleMovesForPlayer(Model.Model.currentPlayerToMove.color).Count == 0 && !IsPlayerInCheck(Model.Model.currentPlayerToMove.color)) || CheckIfKingVsKing())
            {
                return true;
            }
            return false;
        }

        public static bool CheckForCheckmate()
        {
            if (GeneratePossibleMovesForPlayer(Model.Model.currentPlayerToMove.color).Count == 0 && IsPlayerInCheck(Model.Model.currentPlayerToMove.color))
            {
                return true;
            }
            return false;
        }

        public static bool CheckIfKingVsKing()
        {
            foreach (Piece boardPiece in Board.boardState)
            {
                if (boardPiece.PieceType != PieceType.King)
                {
                    return false;
                }
            }
            return true;
        }
    }
}