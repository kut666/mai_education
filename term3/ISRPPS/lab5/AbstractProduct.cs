using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
     public abstract class AbstractProduct
    {
        public abstract double MadeCalculations(double m);
        public abstract void Draw(Form form);

    }

    public class DishCalculate : AbstractProduct
    {
        public override double MadeCalculations(double m)
        {
            return m * 1.5;
        }

        public override void Draw(Form form)
        {
            Window1 window1 = (Window1)form;
            window1.Show();
        }

    }

    public class DrinkCalculate : AbstractProduct
    {
        public override double MadeCalculations(double m)
        {
            return m * 0.5;
        }

        public override void Draw(Form form)
        {
            Window2 window2 = (Window2)form;
            window2.Show();
        }
    }
}
