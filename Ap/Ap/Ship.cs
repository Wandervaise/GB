using System;
using System.Drawing;

namespace Ap
{
    /// <summary>
    /// объект управляемый корабль
    /// </summary>
    class Ship :BaseObject,ICollision
    {
  
        public static LogData logdata = new LogData();
        private int _energy;
        public int Energy => _energy;   //список параметров=>выражение
        /// <summary>
        /// обработка полученного урона
        /// </summary>
        /// <param name="n"></param>
        public void EnergyLow(int n)    // переименовать
        {
            _energy -= n;
            Log llll = new Log(logdata.LogConsoleWrite);// Создание экземпляра делегата
            //llll("Получено {0} ед. урона", n); // Вызов функции
            llll("Получено " + n + " ед. урона");
            
        }
        /// <summary>
        /// увеличение прочности
        /// </summary>
        /// <param name="n">число, восстанавливаемых единиц прочности</param>
        public void EnergyUp(int n)    // переименовать
        {
            _energy += n;
            Log llll = new Log(logdata.LogConsoleWrite);// Создание экземпляра делегата
            llll("Восстановлено " + n + " ед. прочности щита");
        }

        public Ship(Point pos,Point dir,Size size): base (pos,dir,size)
        {
            _energy = 100;
        }
        /// <summary>
        /// отрисовка графики
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Yellow, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// обновление состояния объекта
        /// </summary>
        public override void Update()
        { }
        /// <summary>
        /// движение вверх
        /// </summary>
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y -= Dir.Y;
        }
        /// <summary>
        /// движение вниз
        /// </summary>
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y += Dir.Y;
        }
        /// <summary>
        /// движение вправо
        /// </summary>
        public void Right()
        {
            if (Pos.X < Game.Width) Pos.X += Dir.X;
        }
        /// <summary>
        /// движение влево
        /// </summary>
        public void Left()
        {
            if (Pos.X > 0) Pos.X -=  Dir.X;
        }
        /// <summary>
        /// крушение объекта
        /// </summary>
        public void Crash()
        {
            MessageCrash?.Invoke();
        }
        public static event Message MessageCrash;
        public Rectangle rect => new Rectangle(Pos, Size);
        public bool Collision(ICollision obj) => obj.rect.IntersectsWith(this.rect);
    }
}