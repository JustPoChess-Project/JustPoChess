using System;

namespace JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition
{
    public class Position
    {
        private int row;
        private int col;

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
        
        public int Row
        {
            get
            {
                return this.row;               
            }
            set
            {
                if (this.row < 0 || this.row > 7)
                {
                    throw new ArgumentException("Invalid Position");
                }
                this.col = value;               
            }
        }

        public int Col
        {
            get
            {
                return this.col;                
            }
            set
            {
                if (this.col < 0 || this.col > 7)
                {
                    throw new ArgumentException("Invalid Position");
                }
                this.col = value;                
            }
        }

		//testing purposes
		public override string ToString()
        {
            return $"[Position: Row={this.Row}, Col={this.Col}]";
        }

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
            Position position = obj as Position;
            return position.Row == this.Row
				&& position.Col == this.Col;
		}
    }
}
