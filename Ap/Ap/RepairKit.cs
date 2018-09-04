using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Ap
{
    /// <summary>
    /// объект аптечка
    /// </summary>
    class RepairKit : BaseObject,ICollision
    {
        public RepairKit(Point pos, Point dir, Size size) : base(pos, dir, size)
        { }
        /// <summary>
        /// отрисовка графики
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(
                Pens.SkyBlue,
                Pos.X,Pos.Y,
                Size.Width,Size.Height
                );
        }
        /// <summary>
        /// функция обновления состояния объекта
        /// </summary>
        public override void Update()
        {
            Pos.X -=  Dir.X;
            if (Pos.X < 0) resp();
        }
        /// <summary>
        /// перерождение объекта
        /// </summary>
        public void resp()
        {
            Random rand = new Random();
            Pos.X = Game.Width;
            Pos.Y = rand.Next(Game.Height - Size.Height);
        }
        public Rectangle rect => new Rectangle(Pos, Size);
        public bool Collision(ICollision obj) => obj.rect.IntersectsWith(this.rect);
    }
}