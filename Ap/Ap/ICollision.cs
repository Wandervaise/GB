using System;
using System.Drawing;
namespace Ap
{/// <summary>
/// интерфейс столкновения
/// </summary>
    interface ICollision
    {
        bool Collision(ICollision obj);

        Rectangle rect { get; }
    }
    
}
