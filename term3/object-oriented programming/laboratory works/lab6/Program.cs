using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class D
    {
        public D() { N = 5; this.e = new E[N]; }
        public D(int N)
        {
            this.N = N;
            this.e = new E[N];
        }
        ~D() { }
        public void setE(E e) { if (size < N) { this.e[size] = e; size++; } }
        public E getNext(int index)
        {
            if (index < size)
            {
                return e[index];
            }
            return null;
        }

        private int N = 0;

        private E[] e = null;
        private int size = 0;
    }

    class E
    {
        public E() { }
        public E(D d) { d.setE(this); }
        ~E() { }
        public int f() { return v; }
        private int v = 20;
        public D d { set; get; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            D d = new D(); D dS = new D(8);


            E e_1 = new E();
            d.setE(e_1);
            e_1.d = d;
            Console.WriteLine(" e_1.d.getNext().f() = {0}", e_1.d.getNext(0).f());

            Console.WriteLine(" d.getNext().f() = {0}", d.getNext(0).f());
            E e_2 = new E(d);

            Console.ReadKey();
        }
    }
}
