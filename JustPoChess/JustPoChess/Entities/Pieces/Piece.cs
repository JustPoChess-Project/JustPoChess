using JustPoChess.Interfaces;

namespace JustPoChess.Entities
{
    public abstract class Piece : IMovable, IDrawable
    {
        public abstract void Draw();
        public abstract void Move();
    }
}
