using JustPoChess.Remaster.Client.MVC.Model.Contracts;
using JustPoChess.Remaster.Client.MVC.Model.Enums;

namespace JustPoChess.Remaster.Client.MVC.Model.Pieces
{
    public class King : Piece
    {
        public King(PieceColor pieceColor)
             :base(pieceColor)
        {
        }
        
        public override PieceType PieceType
        {
            get
            {
                return PieceType.King;
                
            }
        }
    }
}