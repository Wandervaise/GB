using System;
using System.Windows.Forms;
using System.Drawing;

namespace Ap
{
    /// <summary>
    /// Основной класс инициализирующий основные параметры игры
    /// </summary>
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        public Game()
        {
        }
        /// <summary>
        /// Класс инициализации методов
        /// </summary>
        /// <param name="form"></param>
        public void Init(Form form)
        {
            if (form.Width > 1000 || form.Height>1000)
            {
                throw new ArgumentOutOfRangeException();
            }
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            int timerInterval = 100;
            Timer timer = new Timer { Interval = timerInterval };
            try
            {
                if (timerInterval!=100)
                { throw new GameObjectException("Высокая  скорость игры"); }
            }
            catch( GameObjectException )
            {
                Console.WriteLine("высокая скорость игры");
            }
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        /// <summary>
        /// Вывод графики
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            pl_obj.Draw();
            //foreach (BaseObject obj in _objs)
            //    obj.Draw();
            //foreach (Asteroid strd in _asteroid) strd.Draw();
            foreach (Star star in _star) star.Draw();

            foreach(comet cmt in _comet)
            {
                cmt.Draw();
            }
            _bullet.Draw();
            
            try
            {
                Buffer.Render();
            }
            catch (ArgumentException)
            {
                Application.Exit();
            }
        }

        public static comet[] _comet;
        public static Planet pl_obj;
        //public static Asteroid[] _asteroid;
        public static Star[] _star;
        public static Bullet _bullet;
        /// <summary>
        /// класс для инициализации объектов
        /// </summary>
        public static void Load()
        {
            var rnd = new Random();
            int asteroidNum = rnd.Next(30,35);

            for (int i = 0; i < Width; i++)
            {
                pl_obj = new Planet(
                    new Point(Width - 60, 100),
                    new Point(-1, 5),
                    new Size(150, 147));
            }
            _star = new Star[30];
            //_asteroid = new Asteroid[15];

            for (var i = 0; i < _star.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _star[i] = new Star(new Point(1000, rnd.Next(0, Game.Height)), new
                Point(-r, r), new Size(3, 3));
            }
            //for (var i = 0; i < _asteroid.Length; i++)
            //{
            //    int r = rnd.Next(5, 50);
            //    _asteroid[i] = new Asteroid(new Point(1000, rnd.Next(0, Game.Height)),
            //    new Point(-r / 5, r), new Size(r, r));
            //}

            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(40, 10));
            _comet = new comet[asteroidNum];
            for (int i = 0; i < _comet.Length; i++)
            {
                _comet[i] = new comet(
                     new Point(Width - 10, Height - 20),
                     new Point(10 - i, 15 - i),
                     new Size(30, 30));
            }
        }
        /// <summary>
        /// класс для изменения состояния объектов 
        /// </summary>
        public static void Update()
        {
            foreach (Star obj in _star)
            { obj.Update(); }
            //foreach(Asteroid strd in _asteroid)
            //{
            //    strd.Update();
            //}
                pl_obj.Update();
            foreach(comet cmt in _comet)
            {
                cmt.Update();
                if (cmt.Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    cmt.resp();
                }
            }
            _bullet.Update();

        }
        /// <summary>
        /// таймер обрабатывающий события
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

    }
}