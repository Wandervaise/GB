using System;
using System.Drawing;

namespace Ap
{
    /// <summary>
    /// произволный объект - астероид 
    /// </summary>
    class Asteroid:BaseObject
    {
        Image newImage = Image.FromFile("Asteroid.png");

        public Asteroid(Point pos,Point dir, Size size):base (pos,dir,size)
        {
            //newImage = Image.FromFile("Asteroid.png");
        }
        /// <summary>
        /// функция отрисовки графики
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// функция обновления состояния объекта
        /// </summary>
        public override void Update()
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
