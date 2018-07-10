using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ap
{
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
            name.Text = "Имя автора";
            name.Location = new Point(Width/2-40,Height-100);
            form.Controls.Add(name);
            #endregion
        }

        private static void b1_click(object sender, EventArgs e)
        {
            Application.Exit();
            //Game WGame = new Game();
            ////WGame.Init(form);
            //Game.Draw();
        }
        
        private static void start_button_click(object sender,EventArgs e)
        {
            
            var form = new Form();
            form.Width = 800;
            form.Height = 600;
            var f = new Game();
            f.Init(form);
            form.Show();
        }

        private static void score_button_click(object sender, EventArgs e)
        {
            var form = new Form();
            var f = new Game();
            f.Init(form);
            form.Show();
        }

        private void panel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            Point mouseDownLocation = new Point(e.X, e.Y);
        }

        public static void Splash_Draw()
        {

            Buffer.Graphics.Clear(Color.Black);
            foreach (dust obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        public static dust[] _objs;
        public static void Load()
        {
            _objs = new dust[30];
            for (int i = 0; i < _objs.Length; i++)
            {
                _objs[i] = new dust(
                     new Point(Width - 10, Height - 20),
                     new Point(10 - i, 15 - i),
                     new Size(10, 10));
            }
        }
        public static void Update()
        {
            foreach (dust obj in _objs)
                obj.Update();
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Splash_Draw();
            Update();
        }
    }
}
