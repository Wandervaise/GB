﻿using System;
using System.Drawing;

namespace Ap
{
    class Star:BaseObject
    {
        //public static Star[] _objs;
        public Star(Point pos,Point dir,Size size):base(pos,dir,size)
        {
            
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(
                Pens.White, 
                Pos.X, Pos.Y, 
                Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(
                Pens.White, 
                Pos.X + Size.Width, Pos.Y, 
                Pos.X, Pos.Y + Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            //if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
            if (Pos.X < 0) Pos.X = Game.Width-47;// + Size.Width; *1 то же самое что о в базовом методе класса 
        }
 
    }
}