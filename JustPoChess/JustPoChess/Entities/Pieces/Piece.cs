using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustPoChess.Interfaces;

namespace JustPoChess.Entities
{
    public abstract class Piece : IMovable, IDrawable
    {
        private Position.Position position;

        public Position.Position Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        public abstract void Draw();
        public abstract void Move();
    }
}
