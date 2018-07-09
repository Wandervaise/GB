using System;
using System.Windows.Forms;


namespace Ap
{
    class Program
    {

            static void Main(string[] args)
        {
            
             Form form = new Form();
             form.Width = 800;
             form.Height = 600;
            SplashScreen.Init(form);
            //Game.Init(form);
            form.Show();
            
            //Game WGame = new Game();
             //WGame.Init(form);
             //в splash screen организовать вызов метода Game  
             //черз те самые кнопки

            //Game.Draw();
            //SplashScreen.Splash_Draw();
            //Game.Draw();

            Application.Run(form);
        }

    }
}
