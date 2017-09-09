using System;
using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;

namespace JustPoChess.Client.MVC.Model.Entities.Board
{
    public class Move:IMove
    {
        private IPosition currentPosition;
        private IPosition nextPosition;

        public Move(IPosition currentPosition, IPosition nextPosititon)
        {
            this.CurrentPosition = currentPosition;
            this.NextPosition = nextPosititon;
        }

        public IPosition CurrentPosition
        {
            get
            {
                return this.currentPosition;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Invalid Move");
                }
                this.currentPosition = value;
            }
        }

		public IPosition NextPosition
		{
			get
			{
				return this.nextPosition;
			}
			set
			{
			    if (value == null)
			    {
			        throw new ArgumentException("Invalid Move");
			    }
				this.nextPosition = value;
			}
		}

        //testing purposes
        public override string ToString()
        {
            return $"[Move: CurrentPosition={this.CurrentPosition}, NextPosititon={this.NextPosition}]";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Move move = obj as Move;
            return move.CurrentPosition.Row == this.CurrentPosition.Row
                        && move.CurrentPosition.Col == this.CurrentPosition.Col
                        && move.NextPosition.Row == this.NextPosition.Row
                        && move.NextPosition.Col == this.NextPosition.Col;
        }
    }
}
