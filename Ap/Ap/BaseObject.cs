using System.Drawing;

namespace Ap
{
    /// <summary>
    /// базовый класс объектов игры
    /// </summary>
    abstract class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        /// <summary>
        /// отрисовка графики
        /// </summary>
        public abstract void Draw();
        /// <summary>
        /// обновление состояний объекта
        /// </summary>
        public abstract void Update();

        public delegate void Message();
    }
}