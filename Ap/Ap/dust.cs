using System.Drawing;

namespace Ap
{
    /// <summary>
    /// объект экрана меню
    /// </summary>
    class dust
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        public dust(Point pos,Point dir,Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawEllipse(
                Pens.Gray,
                Pos.X, Pos.Y,
                Size.Width, Size.Height);
        }
        public void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0)
            { Pos.X = SplashScreen.Width - 50; }
            if (Pos.X >= SplashScreen.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y >= SplashScreen.Height) Dir.Y = -Dir.Y;
        }
    }
}
