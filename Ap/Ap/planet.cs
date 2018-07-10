using System.Drawing;

namespace Ap
{
    class Planet:BaseObject
    {
        public Planet(Point pos, Point dir, Size size) : base(pos, dir, size) { }

        public override void Draw()
        {
            Image newImage = Image.FromFile("GreenPlanet.png");
            Point planet_point = new Point(Pos.X, Pos.Y);
            Game.Buffer.Graphics.DrawImage(newImage,planet_point);
        }
        

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width;

        }

    }
}