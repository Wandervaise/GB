using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ap
{
    /// <summary>
    /// обработка игровых исключений
    /// </summary>
    class GameObjectException:Exception
    {
        public GameObjectException(string message) : base(message)
        { }
    }
}
