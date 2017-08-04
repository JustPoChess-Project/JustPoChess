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
                return currentPosition;
            }
            set
            {
                this.currentPosition = value;
            }
        }

		public Position NextPosititon
		{
			get
			{
				return nextPosititon;
			}
			set
			{
				this.nextPosititon = value;
			}
		}
    }
}
