using System;
using System.Windows.Forms;
using System.Drawing;

namespace Ap
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        public Game()
        {
        }
        public void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            pl_obj.Draw();
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }
        public static BaseObject[] _objs;
        public static BaseObject pl_obj;
        public static void Load()
        {
            _objs = new BaseObject[30];
            for (int i = 0; i < _objs.Length; i++)
            {
                _objs[i] = new BaseObject(
                     new Point(Width - 10, Height - 20),
                     new Point(10 - i, 15 - i),
                     new Size(10, 10));
            }

            for (int i = _objs.Length / 2; i < _objs.Length; i++)
            {
                _objs[i] = new Star(
                    new Point(750, i * 20),
                    new Point(-i, 0),
                    new Size(5, 5));
            }
            for (int i = 0; i < Width; i++)
            {
                pl_obj = new Planet(
                    new Point(Width-60, 100),
                    new Point(-1, 5),
                    new Size(150, 147));
            }
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            pl_obj.Update();
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}