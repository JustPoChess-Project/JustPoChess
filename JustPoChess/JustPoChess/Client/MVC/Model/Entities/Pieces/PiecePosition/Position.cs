namespace JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition
{
    public class Position
    {
        private int row;
        private int col;

        public int Row
        {
            get
            {
                return this.row;               
            }
            set
            {
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
                this.col = value;                
            }
        }

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
}
