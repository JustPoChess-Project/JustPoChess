using System;
using JustPoChess.Client.Model.Entities.Pieces.PiecePosition;

namespace JustPoChess.Client.Model.Entities.Board
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
