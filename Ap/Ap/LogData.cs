using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Ap
{
    public delegate void Log(string LogMsg);
    /// <summary>
    /// Ведение журнала событий
    /// </summary>
    class LogData
    {   
        /// <summary>
        /// функция отображения и записи логов
        /// </summary>
        /// <param name="msg">получаемая строка</param>               
        public  void LogConsoleWrite(string msg)
        {
            Console.WriteLine(msg);
            using (var sw = new StreamWriter( "Log.txt",true))
            {
                sw.WriteLine(msg);
            }

        }
    }
}
