using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;

namespace JustPoChess.Client.MVC.Model.Entities.Board
{
    public class Move
    {
        Position currentPosition;
        Position nextPosititon;

        public Move(Position currentPosition, Position nextPosititon)
        {
            this.currentPosition = currentPosition;
            this.nextPosititon = nextPosititon;
        }

    }
}
