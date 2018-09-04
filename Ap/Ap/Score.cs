using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ap
{
    public delegate void ADD_Point<T>(T arg);
    /// <summary>
    /// класс подсчитывающий набранные очки
    /// </summary>
    class Score
    {
        private int score;
        private int points;

        public Score()
        {
            score = 0;
            points = 0;
        }
        /// <summary>
        /// свойство возвращающее текущее значение полученных очков
        /// </summary>
        public int Points { get { return points; } }
        /// <summary>
        /// начисление очков
        /// </summary>
        /// <param name="n"></param>
        public void Add_points(int n)
        {
            points += n;
        }

    }
}


/*
*                       
*/