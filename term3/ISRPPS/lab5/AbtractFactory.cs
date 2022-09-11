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
    public abstract class AbstractFactory
    {
        public abstract AbstractProduct CreateProduct();
        public abstract Form CreateWindow();
    }

    public class Dish : AbstractFactory
    {
        public override AbstractProduct CreateProduct()
        {
            return new DishCalculate();
        }

        public override Form CreateWindow()
        {
            return new Window1();
        }
    }

    public class Drink : AbstractFactory
    {
        public override AbstractProduct CreateProduct()
        {
            return new DrinkCalculate();
        }

        public override Form CreateWindow()
        {
            return new Window2();
        }
    }

    class Client
    {
        private AbstractProduct product;
        private Form former;
        public int Mass { get; set; }

        public Client(AbstractFactory factory)
        {
            product = factory.CreateProduct();
            former = factory.CreateWindow();
        }

        public double Run1()
        {
            return product.MadeCalculations(Mass);
        }

        public void Run2 ()
        {
            product.Draw(former);
        }
    }
}
