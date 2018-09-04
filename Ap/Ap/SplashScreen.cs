using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ap
{
    /// <summary>
    /// заставка - меню игры
    /// </summary>
    class SplashScreen
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        public SplashScreen(Form form)
        {
            form = new Form();
        }
        /// <summary>
        /// инициализация основных параметров 
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
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

            #region
            Button start_button = new Button();
            start_button.Location = new Point(Width / 2 - 40, Height / 2 - 120);
            start_button.Size = new Size(100, 35);
            start_button.Text = "Старт";
            start_button.UseVisualStyleBackColor = true;
            start_button.Click += new EventHandler(start_button_click);
            form.Controls.Add(start_button);

            Button score_button = new Button();
            score_button.Location = new Point(Width / 2 - 40, Height / 2 - 80);
            score_button.Size = new Size(100, 35);
            score_button.Text = "Рекорды";
            score_button.UseVisualStyleBackColor = true;
            score_button.Click += new EventHandler(start_button_click);
            form.Controls.Add(score_button);

            Button button_exit = new Button();
            button_exit.Location = new Point(Width / 2 - 40, Height / 2 - 40);
            button_exit.Size = new Size(100, 35);
            button_exit.Text = "Выход";
            button_exit.UseVisualStyleBackColor = true;
            button_exit.Click += new EventHandler(b1_click);
            form.Controls.Add(button_exit);

            Label name = new Label();
            name.Text = "Управление:\n Движение ↑ ↓ → ← \n Выстрел Ctrl";
            name.Location = new Point(Width/2-50,Height-100);
            name.Size = new Size(120,40);
            form.Controls.Add(name);
            #endregion
        }

        //Rectangle button = new Rectangle(Width / 2 - 40, Height / 2 - 100, 100, 40);

        /*    
       public void MyButton()
       {
           Button b1 = new Button();
           b1.Location = new System.Drawing.Point(this.ClientRectangle.Width / 2 - 125 / 2, this.ClientRectangle.Height / 2 - 32);
           b1.Size = new Size(125, 32);
           b1.TabIndex = 0;
           b1.Text = "TEXT";
           b1.UseVisualStyleBackColor = true;
           b1.Click += new EventHandler(b1_click);
           Controls.Add(b1);
       }

           */

        /// <summary>
        /// кнопка выхода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void b1_click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// кнопка начала игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void start_button_click(object sender,EventArgs e)
        {
            var form = new Form();
            form.Width = 800;
            form.Height = 600;
            var newGame = new Game();
            newGame.Init(form);
            form.Show();
        }
        /// <summary>
        /// рекорды
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void score_button_click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// отрисовка объектов на экране заставки
        /// </summary>
        public static void Splash_Draw()
        {
            //Buffer.Graphics.Clear(Color.Black);
            //foreach (dust obj in _objs)
            //    obj.Draw();
            ////Buffer.Graphics.DrawRectangle(Pens.BlueViolet, Width / 2 - 40, Height / 2 - 100, 100, 40);
            //Buffer.Render();
            Buffer.Graphics.Clear(Color.Black);
            //pl_obj.Draw();
            foreach (dust obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        public static dust[] _objs;
        /// <summary>
        /// инициализация объектов на экране заставки
        /// </summary>
        public static void Load()
        {
            //_objs = new dust[30];
            ////for (int i = 0; i < _objs.Length; i++)
            ////{
            ////    _objs[i] = new dust(
            ////         new Point(Width - 10, Height - 20),
            ////         new Point(10 - i, 15 - i),
            ////         new Size(10, 10));
            ////}
            //for (int i = _objs.Length / 2; i < _objs.Length; i++)
            //{
            //    _objs[i] = new dust(
            //        new Point(750, i * 20),
            //        new Point(-i, 0),
            //        new Size(5, 5));
            //}
            _objs = new dust[30];
            for (int i = 0; i < _objs.Length; i++)
            {
                Random rnd = new Random();
                int dust_size = rnd.Next(5,10);
                int rpos_x = rnd.Next(0,Width);
                int rpos_y = rnd.Next(0,Height);
                _objs[i] = new dust(
                     //new Point(Width - 10, Height - 20),
                     new Point(rpos_x,rpos_y),
                     new Point(10 - i, 15 - i),
                     //new Size(10, 10));
                     new Size(dust_size,dust_size));
            }



        }
        /// <summary>
        /// класс изменения состояния объектов экрана заставки
        /// </summary>
        public static void Update()
        {
            //foreach (dust obj in _objs)
            //    obj.Update();
            ////pl_obj.Update();
            foreach (dust obj in _objs)
                obj.Update();
            //pl_obj.Update();
        }
        /// <summary>
        /// обработчик событий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Splash_Draw();
            Update();
        }
    }
}