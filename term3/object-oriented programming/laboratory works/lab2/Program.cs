using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class A
    {
        public A() { }
        ~A() { }

        public void mA() { Console.WriteLine(" method of A"); }

        public B bA { get { Console.Write("get b ->"); return b; } }
        public J jA { get { Console.Write("get j ->"); return j; } }

        private B b = new B();
        private J j = new J();
    }

    class B
    {
        public B() { }
        ~B() { }
        public void mB() { Console.WriteLine(" method of B"); }

        public D dA
        {
            get { Console.Write("get d ->"); return d; }
        }

        private D d = new D();
    }

    class D
    {
        public D() { }
        ~D() { }
        public void mD() { Console.WriteLine(" method of D"); }
    }

    class J
    {
        public J() { }
        ~J() { }
        public void mJ() { Console.WriteLine(" method of J"); }

        public C cA
        {
            get { Console.Write("get c ->"); return c; }
        }

        private C c = new C();
    }

    class C
    {
        public C() { }
        ~C() { }

        public void mC() { Console.WriteLine(" method of C"); }

        public E eA { get { Console.Write("get e ->"); return e; } }
        public F fA { get { Console.Write("get f -> "); return f; } }
        public K kA { get { Console.Write("get k -> "); return k; } }

        private E e = new E();
        private F f = new F();
        private K k = new K();
    }

    class E
    {
        public E() { }
        ~E() { }
        public void mE() { Console.WriteLine(" method of E"); }
    }

    class F
    {
        public F() { }
        ~F() { }
        public void mF() { Console.WriteLine(" method of F"); }
    }

    class K
    {
        public K() { }
        ~K() { }
        public void mK() { Console.WriteLine(" method of K"); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();

            a.mA();
            a.bA.mB();
            a.jA.mJ();

            a.bA.dA.mD();
            a.jA.cA.mC();

            a.jA.cA.eA.mE();
            a.jA.cA.fA.mF();
            a.jA.cA.kA.mK();
            Console.ReadKey();
        }
    }
}
