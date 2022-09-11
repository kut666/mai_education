using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISRPPS_Lab_6
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.Beep(150, 1500);
            Console.Write("ПРИВЕТ\n");

            LaunchModel model = new LaunchModel();

            LaunchView view1 = new LaunchView(model);
            ControlForm view3 = new ControlForm(model);
            Form1 view4 = new Form1(model);

           

            view1.Show();
            view4.Show();

            Application.Run(view3);

            Console.Beep(300, 1500);
        }
    }
}
