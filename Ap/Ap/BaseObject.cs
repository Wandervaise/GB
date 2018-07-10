using System.Drawing;

namespace Ap
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public virtual void Draw()
        {
            Image newImage = Image.FromFile("Asteroid.png");
            Rectangle rect = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(newImage, rect);
            
        }
        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0)
            { Pos.X = Game.Width - 50; }
            if (Pos.X >= Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y >= Game.Height) Dir.Y = -Dir.Y;
        }
    }
}
