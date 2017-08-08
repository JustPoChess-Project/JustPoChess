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
    public class PlayerCheck : Controller
    {
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
    }
}
