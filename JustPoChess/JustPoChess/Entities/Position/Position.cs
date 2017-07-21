using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustPoChess.Entities.Position
{
    public struct Position
    {
        private int row;
        private int col;

        public int Row
        {
            get
            {
                return this.row;               
            }
        }

        public int Col
        {
            get
            {
                return this.col;                
            }
        }

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
}
