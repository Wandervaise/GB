using System;
using System.Drawing;

namespace Ap
{
    /// <summary>
    /// объект пуля
    /// </summary>
    class Bullet:BaseObject, ICollision
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        { }

        public Rectangle rect => new Rectangle(Pos, Size);

        /// <summary>
        /// функция отрисовки графики
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed,Pos.X,Pos.Y,Size.Width,Size.Height);
        }

        public bool Collision(ICollision obj) => obj.rect.IntersectsWith(this.rect);
        int BULLET_MOVEMENT = 32;
        /// <summary>
        /// функция обновления состояния объекта
        /// </summary>
        public override void Update()
        {
            Pos.X += BULLET_MOVEMENT;
        }
    }
}