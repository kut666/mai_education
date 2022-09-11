using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1_2
{
    class Parallelepiped
    {
        public double a;
        public double b;
        public double c;

        public Parallelepiped(double a_r, double b_r, double c_r)
        {
            a = a_r;
            b = b_r;
            c = c_r;
        }
        
        public double SurfaceArea () 
            {
            return 2 * a * b + 2 * a * c + 2 * b * c;
            }

        public double Volume ()
        {
            return a * b * c;
        }
    }

    static class Program
    {
        [STAThread]
       public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
