using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3_4._1
{
    public abstract class Figure
    {
        protected string Fnames;

        public Figure(string Fnames)
        {
            Console.WriteLine("Конструктор Фигура");
            this.Fnames = Fnames;
        }

        ~Figure()
        {
            Console.WriteLine("Деструктор Фигура");
            System.Threading.Thread.Sleep(1000);
        }
        protected string Name { get { return Fnames; } }
        public abstract double area();
        public abstract double perimeter();
        public abstract void Info();
    }

    public class Сircle : Figure
    {
        private double r;

        public Сircle(double r) : base("Круг")
        {
            this.r = r;
            Console.WriteLine("Конструктор Круг");
        }
        ~Сircle()
        {
            Console.WriteLine("Деструктор Круг");
            System.Threading.Thread.Sleep(1000);
        }
        public override double area()
        {
            return (Math.PI * Math.Pow(r, 2));
        }
        public override double perimeter()
        {
            return (2 * Math.PI * r);
        }
        public override void Info()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Радиус {0}", r);
        }
    }

    public class Rectangle : Figure
    {
        double a, b;

        public Rectangle(double a, double b) : base("Прямоугольник")
        {
            Console.WriteLine("Конструктор Прямоугольник");
            this.a = a;
            this.b = b;
        }

        ~Rectangle()
        {
            Console.WriteLine("Деструктор Прямоугольник");
            System.Threading.Thread.Sleep(1000);
        }

        public override double area()
        {
            return (a * b);
        }
        public override double perimeter()
        {
            return (2 * (a + b));
        }
        public override void Info()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Стороны {0} {1} {2} {3}", a, b, a, b);
        }
    }

    public class Tangle : Figure
    {
        double a, b, c;

        public Tangle(double a, double b, double c) : base("Треугольник")
        {
            this.a = a;
            this.b = b;
            this.c = c;
            Console.WriteLine("Конструктор Треугольник");
        }

        ~Tangle()
        {
            Console.WriteLine("Деструктор Треугольник");
            System.Threading.Thread.Sleep(1000);
        }

        public override double area()
        {
            double p = (a + b + c) / 2;
            return (Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
        }
        public override double perimeter()
        {
            return (a + b + c);
        }
        public virtual void height() { }
        public override void Info()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Стороны {0} {1} {2}", a, b, c);
        }
    }

    public class Square : Rectangle
    {
        private double a;

        public Square(double a) : base(a, a)
        {
            this.a = a;
            Fnames = "Квадрат";
            Console.WriteLine("Конструктор Квадрат");
        }

        ~Square()
        {
            Console.WriteLine("Деструктор Квадрат");
            System.Threading.Thread.Sleep(1000);
        }
    }

    public class RegularTriangle : Tangle
    {
        private double a;

        public RegularTriangle(double a) : base(a, a, a)
        {
            this.a = a;
            Fnames = "Правильный Треугольник";
            Console.WriteLine("Конструктор Правильный Треугольник");
        }

        ~RegularTriangle()
        {
            Console.WriteLine("Деструктор Правильный Треугольник");
            System.Threading.Thread.Sleep(1000);
        }
        public override void height()
        {
            Console.WriteLine("Высота {0}", Math.Sqrt(3) * a / 3);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Figure F = new Circle(4);
            Console.WriteLine("Площадь = " + F.area());
            Figure F = new Square(5);
            Console.WriteLine("Площадь = " + F.area());

            Figure[] arr = new Figure[5];
            arr[0] = new Сircle(4);
            Console.WriteLine("-----------------------------------------");
            arr[1] = new Rectangle(5.2, 8.6);
            Console.WriteLine("-----------------------------------------");
            arr[2] = new Tangle(3, 4, 5);
            Console.WriteLine("-----------------------------------------");
            arr[3] = new Square(5);
            Console.WriteLine("-----------------------------------------");
            arr[4] = new RegularTriangle(7);
            Console.WriteLine("-----------------------------------------");

            for (int i = 0; i < 5; i++)
            {
                switch (arr[i].GetType().Name)
                {
                    case "Сircle":
                        arr[i].Info();
                        Console.WriteLine("Площадь = " + arr[i].area());
                        Console.WriteLine("Периметр = " + arr[i].perimeter());
                        Console.WriteLine("-----------------------------------------");
                        break;
                    case "Rectangle":
                        arr[i].Info();
                        ((Rectangle)arr[i]).diag();
                        Console.WriteLine("Площадь = " + arr[i].area());
                        Console.WriteLine("-----------------------------------------");
                        break;
                    case "Tangle":
                        arr[i].Info();
                        ((Tangle)arr[i]).height();
                        Console.WriteLine("Периметр = " + arr[i].perimeter());
                        Console.WriteLine("-----------------------------------------");
                        break;
                    case "Square":
                        arr[i].Info();
                        ((Square)arr[i]).diag();
                        Console.WriteLine("Площадь = " + arr[i].area());
                        Console.WriteLine("Периметр = " + arr[i].perimeter());
                        Console.WriteLine("-----------------------------------------");
                        break;
                    case "RegularTriangle":
                        arr[i].Info();
                        ((RegularTriangle)arr[i]).height();
                        Console.WriteLine("Периметр = " + arr[i].perimeter());
                        Console.WriteLine("-----------------------------------------");
                        break;
                    default:
                        Console.WriteLine("Ошибка");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
