using JustPoChess.Remaster.Client.MVC.Model.Contracts;

namespace JustPoChess.Remaster.Client.MVC.Model.Entities
{
    public class Position:IPosition
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
                this.row = value;
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
    }
}