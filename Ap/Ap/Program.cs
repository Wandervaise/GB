using System;
using System.Windows.Forms;

/*
Переделать виртуальный метод Update в BaseObject в абстрактный 
и реализовать его в наследниках.
*/
namespace Ap
{
    class Program
    {
        static void Main(string[] args)
        {
            //убрать магические числа
            Form form = new Form()
            {
                Width = Screen.PrimaryScreen.Bounds.Width,
                Height = Screen.PrimaryScreen.Bounds.Height
            };
            form.Width = 800;
            form.Height = 600;
            SplashScreen.Init(form);
            form.Show();
            Application.Run(form);


            
        }
        
    }
}
