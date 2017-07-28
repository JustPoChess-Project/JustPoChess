using System;
using JustPoChess.Client.Model.Entities.Pieces.PiecePosition;

namespace JustPoChess.Client.Model.Entities.Move
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
