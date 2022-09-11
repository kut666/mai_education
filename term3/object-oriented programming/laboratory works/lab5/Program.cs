using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    public interface A
    {
        void mIA();
        int m();
    }

    public class B : A
    {
        public B()
        {
            Console.WriteLine(" constructor B ()");
            this.b = 88;
        }
        public B(int b)
        {
            Console.WriteLine(" constructor B(int b) ");
            this.b = b;
        }

        public int fAS() { return this.b; }

        public void mIA() { }
        public int m() { return 10; }
       
    }

    public interface C : A
    {
        int fIC();
        void mIC();
        int m();
    }

    public class D : B, C
    {
        

        public D() { this.a = this.fAS(); }

        public D(int b, int a) : base(b)
        {
            Console.WriteLine(" constructor D");
            this.a = a;
        }

        public int fIC() { return 77; }
        public void mIC() { this.a = this.fIA() + this.fIC(); }

        private int a = 0;
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = null;
            a = new B();
            Console.WriteLine(" B  a.fIA() = {0}", b.m());

            C c = null;
            c = new D();
            Console.WriteLine(" C  c.fIA() = {0}", c.m());

            a = new D();

            Console.WriteLine(" +++++++++++++");

            a = new D(88, 55);



            Console.ReadKey();
        }
    }
}
