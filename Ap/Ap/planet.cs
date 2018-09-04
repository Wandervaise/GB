using System.Drawing;

namespace Ap
{
    /// <summary>
    /// производный объект - планета
    /// </summary>
    class Planet:BaseObject
    {
        public Planet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        Image newImage = Image.FromFile("GreenPlanet.png");
        /// <summary>
        /// функция отрисовки графики
        /// </summary>
        public override void Draw()
        {            
            //Point planet_point = new Point(Pos.X, Pos.Y);
            Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y);
        }
        /// <summary>
        /// функция обновления состояния объекта
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width;
        }
    }
}