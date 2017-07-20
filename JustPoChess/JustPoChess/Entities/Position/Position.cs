using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustPoChess.Entities.Position
{
    public struct Position
    {
        private readonly int x;
        private readonly int y;

        public int X
        {
            get
            {
                return this.x;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
        }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
