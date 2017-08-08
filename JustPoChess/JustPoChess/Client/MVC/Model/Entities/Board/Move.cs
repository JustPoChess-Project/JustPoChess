using System;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;

namespace JustPoChess.Client.MVC.Model.Entities.Board
{
    public class Move
    {
        private Position currentPosition;
        private Position nextPosititon;

        public Move(Position currentPosition, Position nextPosititon)
        {
            this.currentPosition = currentPosition;
            this.nextPosititon = nextPosititon;
        }

        public Position CurrentPosition
        {
            get
            {
                return this.currentPosition;
            }
            set
            {
                if (this.currentPosition == null)
                {
                    throw new ArgumentException("Invalid Move");
                }
                this.currentPosition = value;
            }
        }

		public Position NextPosititon
		{
			get
			{
				return this.nextPosititon;
			}
			set
			{
			    if (this.nextPosititon == null)
			    {
			        throw new ArgumentException("Invalid Move");
			    }
				this.nextPosititon = value;
			}
		}

        //testing purposes
        public override string ToString()
        {
            return string.Format("[Move: CurrentPosition={0}, NextPosititon={1}]", CurrentPosition, NextPosititon);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) {
                return false;
            }
            Move move = obj as Move;
            return move.CurrentPosition.Row == this.CurrentPosition.Row
                        && move.CurrentPosition.Col == this.CurrentPosition.Col
                        && move.NextPosititon.Row == this.NextPosititon.Row
                        && move.NextPosititon.Col == this.NextPosititon.Col;
        }
    }
}
