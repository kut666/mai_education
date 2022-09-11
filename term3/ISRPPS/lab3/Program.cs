using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    abstract class Menu
    {
        protected string name;
        protected int mass;
        protected int price;
        abstract public string info();

        public Menu(string name, int mass, int price)
        {
            this.name = name;
            this.mass = mass;
            this.price = price;
        }

        public int Mass
        {
            get { return mass; }
        }

        public int Price
        {
            get { return price; }
        }
    }

    class Dish : Menu
    {
        public Dish(string name, int mass, int price) : base(name, mass, price)
        {
            this.name = name;
            this.mass = mass;
            this.price = price;
        }

        public override string info()
        {
            return string.Format("{0,-20}{1,10:d2}{2,30:d2}",
                 name, mass, price);
        }
    }

    class Drink : Menu
    {
        public Drink(string name, int mass, int price) : base(name, mass, price)
        {
            this.name = name;
            this.mass = mass;
            this.price = price;
        }

        public override string info()
        {
            return string.Format("{0,-20}{1,10:d2}{2,30:d2}",
                 name, mass, price);
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
