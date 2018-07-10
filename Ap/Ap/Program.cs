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
            form.Show();
            Application.Run(form);
        }
    }
}
