using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.Abstract;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Client.MVC.Controller
{
    class CastleChecks : Controller
    {
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

        public static bool IsWhiteLeftCastlePossible()
        {
            if (Board.Instance.WhiteLeftCastlePossible && !PlayerCheck.IsPlayerInCheck(PieceColor.White)) // has white moved the left 
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
            return false;
        }

        public static bool IsWhiteRightCastlePossible()
        {
            if (Board.Instance.WhiteRightCastlePossible && !PlayerCheck.IsPlayerInCheck(PieceColor.White))
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
            return false;
        }

        public static bool IsBlackLeftCastlePossible()
        {
            if (Board.Instance.BlackLeftCastlePossible && PlayerCheck.IsPlayerInCheck(PieceColor.Black))
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
            return false;
        }

        public static bool IsBlackRightCastlePossible()
        {
            if (Board.Instance.BlackRightCastlePossible && !PlayerCheck.IsPlayerInCheck(PieceColor.Black))
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
            return false;
        }
    }
}
