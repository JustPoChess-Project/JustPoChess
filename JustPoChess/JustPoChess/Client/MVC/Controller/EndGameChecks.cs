using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.Abstract;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Client.MVC.Controller
{
    public class EndGameChecks : Controller
    {
        private static bool CheckIfKingVsKing()
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

        private static bool CheckIfKingKnightVsKing()
        {
            int knightsCount = 0;
            foreach (Piece boardPiece in Board.Instance.BoardState)
            {
                if (boardPiece.PieceType == PieceType.Knight)
                {
                    knightsCount++;
                    continue;
                }
                if (boardPiece.PieceType != PieceType.King)
                {
                    return false;
                }
            }
            return knightsCount == 1;
        }

        private static bool CheckIfKingBishopVsKing()
        {
            int bishopsCount = 0;
            foreach (Piece boardPiece in Board.Instance.BoardState)
            {
                if (boardPiece.PieceType == PieceType.Bishop)
                {
                    bishopsCount++;
                    continue;
                }
                if (boardPiece.PieceType != PieceType.King)
                {
                    return false;
                }
            }
            return bishopsCount == 1;
        }

        public bool CheckForCheckmate()
        {
            if (this.GeneratePossibleMovesForPlayer(model.Board.CurrentPlayerToMove).Count() == 0 
                && PlayerCheck.IsPlayerInCheck(Board.Instance.CurrentPlayerToMove))
            {
                return true;
            }
            return false;
        }

        public bool CheckForDraw()
        {
            if ((GeneratePossibleMovesForPlayer(model.Board.CurrentPlayerToMove).Count() == 0 
                && !PlayerCheck.IsPlayerInCheck(Board.Instance.CurrentPlayerToMove)) 
                || CheckIfKingVsKing() 
                || CheckIfKingKnightVsKing() 
                || CheckIfKingBishopVsKing())
            {
                return true;
            }
            return Board.Instance.PositionOccurences.ContainsValue(3);
        }
    }
}
