using System;
using System.Drawing;


namespace Ap
{
    /// <summary>
    /// объект астероид
    /// </summary>
    class comet : BaseObject, ICollision
    {
        public comet(Point pos,Point dir, Size size):base(pos,dir,size)
        {
        }
        /*public  object Clone()
        {
            comet comet = new comet(new Point(Pos.X, Pos.Y),
                new Point(Dir.Y, Dir.Y),
                new Size(Size.Width, Size.Height))
            { Power = Power };
            return comet;
        }
        */
        public Rectangle rect => new Rectangle(Pos, Size);
        Image newImage = Image.FromFile("Asteroid.png");
        /// <summary>
        /// функция отрисовки графики
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public bool Collision(ICollision obj) => obj.rect.IntersectsWith(this.rect);

        //public override void Update()
        //{
        //    Pos.X = Pos.X + Dir.X;
        //    Pos.Y = Pos.Y + Dir.Y;
        //    if (Pos.X < 0)
        //    { Pos.X = SplashScreen.Width - 50; }
        //    if (Pos.X >= SplashScreen.Width) Dir.X = -Dir.X;
        //    if (Pos.Y < 0) Dir.Y = -Dir.Y;
        //    if (Pos.Y >= SplashScreen.Height) Dir.Y = -Dir.Y;
        //}
        /// <summary>
        /// функция обновления состояния 
        /// </summary>
        public override void Update()
        {
            Random rnd = new Random();
            
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Pos.Y = rnd.Next(0,Game.Height)+Dir.Y;
                
            //if (Pos.X >= Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0)
            {
                Pos.Y = rnd.Next(0, Game.Height)-Dir.X;
            } 
            if (Pos.Y >= Game.Height) Dir.Y = -Dir.Y;
        }
        /// <summary>
        /// пересоздание объекта 
        /// </summary>
        public void resp()
        {
            Random rand = new Random();
            Pos.X = rand.Next(Game.Width - Size.Width);
            Pos.Y = rand.Next(Game.Height - Size.Height);
        }
    }
}
