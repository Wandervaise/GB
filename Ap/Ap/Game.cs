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
        private static Timer timer = new Timer();
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
            timer.Interval = timerInterval;
            //тут Timer timer = new Timer { Interval = timerInterval };
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
            form.KeyDown += Form_KeyDown;
            Ship.MessageCrash += Finish;
             _ship= new Ship(
            new Point(10, 400),
            new Point(5, 5),
            new Size(10, 10));
        }
        public static LogData logdata = new LogData();

        /// <summary>
        /// Окончание игры
        /// </summary>
        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString(END_GAME, 
                new Font(FontFamily.GenericSansSerif, 60, 
                FontStyle.Underline), 
                Brushes.White, 200, 100);
            Buffer.Render();
           
            Log llll = new Log(logdata.LogConsoleWrite);// Создание экземпляра делегата
            llll(END_GAME); // Вызов функции
            
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
            _bullet?.Draw();
            _ship?.Draw();
            _repairKit?.Draw();

            if (_ship!=null)
            {
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
                Buffer.Graphics.DrawString("Score points:" + score.Points, SystemFonts.DefaultFont, Brushes.White, 0, 10);
            }

            try
            {
                Buffer.Render();
            }
            catch (ArgumentException)
            {
                Application.Exit();
            }
        }
        #region объявление констант и объектов
        public static comet[] _comet;
        public static Planet pl_obj;
        public static Star[] _star;
        public static Bullet _bullet;
        public static Ship _ship;
        public static RepairKit _repairKit;
        public static Score score = new Score();

        public static int ASTEROID_NUM_MIN = 10;
        public static int ASTEROID_NUM_MAX = 35;

        public static int PLANET_POS_X = Width - 60;
        public static int PLANET_POS_Y = 100;
        public static int PLANET_DIR_X = -1;   
        public static int PLANET_DIR_Y = 5;
        public static int PLANET_SIZE = 150;

        public static int STAR_POS_X = 1000;
        public static int STAR_SIZE = 3;
        public static int STAR_NUM = 30;

        public static int COMET_POS_X = Width - 10;
        public static int COMET_POS_Y = Height - 20;
        public static int COMET_DIR_X = 15;
        public static int COMET_DIR_Y = 10;
        public static int COMET_SIZE = 30;

        public static int RANDOM_DIR_MIN = 5;
        public static int RANDOM_DIR_MAX = 50;

        public static int BULLET_POS_X = 0;
        public static int BULLET_POS_Y = 200;
        public static int BULLET_DIR_X = 5;
        public static int BULLET_DIR_Y = 0;
        public static int BULLET_SIZE_X = 40;
        public static int BULLET_SIZE_Y = 20;

        public static int RK_POS_X = 300;
        public static int RK_POS_Y = 400;
        public static int RK_DIR_X = 5;
        public static int RK_DIR_Y = 0;
        public static int RK_SIZE_X = 15;
        public static int RK_SIZE_Y = 15;
        public static int RK_SHIELD_POINT = 30;

        public static int POINT_FOR_COMET = 10;
        public static int POINT_FOR_RK = 5;

        public static string END_GAME = "Game over";
        #endregion

        /// <summary>
        /// класс для инициализации объектов
        /// </summary>
        public static void Load()
        {
            var rnd = new Random();
            int asteroidNum = rnd.Next(ASTEROID_NUM_MIN, ASTEROID_NUM_MAX);

            for (int i = 0; i < Width; i++)
            {
                pl_obj = new Planet(
                    new Point(PLANET_POS_X, PLANET_POS_Y),
                    new Point(PLANET_DIR_X, PLANET_DIR_Y),
                    new Size(PLANET_SIZE, PLANET_SIZE));
            }
            _star = new Star[STAR_NUM];
            for (var i = 0; i < _star.Length; i++)
            {
                int r = rnd.Next(RANDOM_DIR_MIN, RANDOM_DIR_MAX);
                _star[i] = new Star(
                    new Point(STAR_POS_X, rnd.Next(0, Game.Height)),
                    new Point(-r, r), 
                    new Size(STAR_SIZE, STAR_SIZE));
            }
           
            _comet = new comet[asteroidNum];
            _repairKit = new RepairKit(
                new Point(RK_POS_X, RK_POS_Y),
                new Point(RK_DIR_X, RK_DIR_Y),
                new Size(RK_SIZE_X, RK_SIZE_Y)
                );
            for (int i = 0; i < _comet.Length; i++)
            {
                
                _comet[i] = new comet(
                     new Point(rnd.Next(0,Width), rnd.Next(0,Height)),
                     new Point(COMET_DIR_X-i, COMET_DIR_Y+i),
                     new Size(COMET_SIZE, COMET_SIZE));
            }
        }

        /// <summary>
        /// Метод отвечающий за нажатие клавиш 
        /// </summary>
        /// <param name="sender">объект к которому относится нажатие клавиш?</param>
        /// <param name="e">событие нажатия клавиш</param>
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.ControlKey)
            {
                
                _bullet = new Bullet(
                    new Point(
                        _ship.rect.X + 10,
                        _ship.rect.Y + 4),
                    new Point(4, 0), new Size(50, 100));
            }
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
            if (e.KeyCode == Keys.Right) _ship.Right();
            if (e.KeyCode == Keys.Left) _ship.Left();
        }

        /// <summary>
        /// класс для изменения состояния объектов 
        /// </summary>
        public static void Update()
        {
            //ADD_Point<int> add_score_point = new ADD_Point<int>(score.Add_points);
            ADD_Point<int> add_score_point = score.Add_points;
            // данные которые получаем и метод занимающийся обработкой
            /*
            очки передаем методу add_points (занимающийся подсчетом очков) <- вот этим должен занмиаться метод, котоырй мы напишем сейчас 
            */
            


            var rnd = new Random();

            foreach (Star obj in _star)
            { obj.Update(); }
            //foreach(Asteroid strd in _asteroid)
            //{
            //    strd.Update();
            //}
                pl_obj.Update();
            _repairKit?.Update();
            foreach (comet cmt in _comet)
            {
                cmt.Update();
               
                if (_bullet!=null)
                {
                    if (cmt.Collision(_bullet))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        score.Add_points(POINT_FOR_COMET);
                        cmt.resp();
                    }
                }
                if (cmt.Collision(_ship))
                {
                    _ship?.EnergyLow(rnd.Next(1, 10));
                    System.Media.SystemSounds.Asterisk.Play();
                    cmt.resp();
                }
                
            }
            _bullet?.Update();


            if (_repairKit.Collision(_ship))
            {
                _repairKit.resp();                
                _ship?.EnergyUp(RK_SHIELD_POINT);
                add_score_point(POINT_FOR_RK);
            }
            //if (_ship.Energy < 50)
            //{
                //_repairKit.resp();
                if (_ship.Energy <= 0) _ship?.Crash();
            //}
            
            //LogData logdata = new LogData();
            //Log log = new Log(logdata.LogConsoleWrite);
            //Log log = logdata.LogConsoleWrite;
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