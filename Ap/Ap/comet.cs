using System;
using System.Drawing;


namespace Ap
{
    /// <summary>
    /// объект астероид
    /// </summary>
    class comet : BaseObject,ICollision
    {
        public comet(Point pos,Point dir, Size size):base(pos,dir,size)
        {

        }

        public Rectangle rect => new Rectangle(Pos, Size);
        Image newImage = Image.FromFile("Asteroid.png");
        public override void Draw()
        {
            //Game.Buffer.Graphics.DrawEllipse(Pens.Red,
            //    Pos.X, Pos.Y,
            //    Size.Width, Size.Height);

            Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y, Size.Width, Size.Height);

        }

        public bool Collision(ICollision obj) => obj.rect.IntersectsWith(this.rect);

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0)
            { Pos.X = SplashScreen.Width - 50; }
            if (Pos.X >= SplashScreen.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y >= SplashScreen.Height) Dir.Y = -Dir.Y;
        }
        public void resp()
        {
            Random rand = new Random();
            Pos.X = rand.Next(Game.Width - Size.Width);
            Pos.Y = rand.Next(Game.Height - Size.Height);
        }
    }
}
