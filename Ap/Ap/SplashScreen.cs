using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ap
{
    public class SplashScreen
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
            // Графическое устройство для вывода графики
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для
            //текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в
            //буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            //Load();
            //Timer timer = new Timer { Interval = 100 };
            //timer.Start();
            //timer.Tick += Timer_Tick;

            Button b1 = new Button();
            b1.Location = new Point(Width / 2 - 40, Height / 2 - 100);
            b1.Size = new Size(100, 40);
            b1.Text = "Выход";
            b1.UseVisualStyleBackColor = true;
            b1.Click += new EventHandler(b1_click);
            form.Controls.Add(b1);
        }
        //Rectangle button = new Rectangle(Width / 2 - 40, Height / 2 - 100, 100, 40);

        /*    остановился тут
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
        private static void b1_click(object sender, EventArgs e)
        {

            Application.Exit();
            Game WGame = new Game();
            //WGame.Init(form);
            Game.Draw();
        }
        
        private void panel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Update the mouse path with the mouse information
            Point mouseDownLocation = new Point(e.X, e.Y);
        }

        public static void Splash_Draw()
        {
            Buffer.Graphics.Clear(Color.AliceBlue);

            Buffer.Graphics.DrawRectangle(Pens.BlueViolet, Width / 2 - 40, Height / 2 - 100, 100, 40);

            Buffer.Render();
        }
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
        }*/

        public static void Load()
        {

        }
        public static void Update()
        {

        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            //Draw();
            Update();
        }
    }
}
