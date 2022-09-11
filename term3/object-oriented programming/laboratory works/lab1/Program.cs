using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class A            
    {
        public A(B b, J j)      
        {
            this.b = b;
            this.j = j;
        }
        ~A() { }                     

        public void mA() { Console.WriteLine("A"); }

        public B bA
        {
            set { Console.WriteLine("set b"); b = value; }
            get { Console.Write("get b -> "); return b;  }
        }

        public J jA
        {
            set { Console.WriteLine("set j"); j = value; }
            get { Console.Write("get j -> "); return j; }
        } 
        private B b = null;
        private J j = null;
    }

    class B                
    {
        public B(D d)
        {
            this.d = d;
        }
        ~B() { }

        public void mB() { Console.WriteLine("B"); }

        public D dA
        {
            set { Console.WriteLine("set d"); d = value; }
            get { Console.Write("get d -> "); return d; }
        }

        private D d = null;
    }

    class D                
    {
        public D() { }
        ~D() { }
        public void mD() { Console.WriteLine("D"); }
    }

    class J             
    {
        public J(C c)
        {
            this.c = c;
        }
        ~J() { }

        public void mJ() { Console.WriteLine("J"); }

        public C cA
        {
            set { Console.WriteLine("set c"); c = value; }
            get { Console.Write("get c -> "); return c; }
        }

        private C c = null;
    }

    class C                        
    {
    public C(E e, F f, K k)
    {
        this.e = e;
        this.f = f;
        this.k = k;
    }
    ~C() { }

    public void mC() { Console.WriteLine("C"); }
        public E eA
        {
            set { Console.WriteLine("set e"); e = value; }
            get { Console.Write("get e -> "); return e; }
        }

        public F fA
        {
            set { Console.WriteLine("set f"); f = value; }
            get { Console.Write("get f -> "); return f; }
        }
        public K kA
        {
        set { Console.WriteLine("set k"); k = value; }
        get { Console.Write("get k -> "); return k; }
        }

        private E e = null;
        private F f = null;
        private K k = null;
    }

    class E      
    {
        public E() { }
        ~E() { }
        public void mE() { Console.WriteLine("E"); }
    }

    class F      
    {
        public F() { }
        ~F() { }
        public void mF() { Console.WriteLine("F"); }
    }

    class K      
    {
        public K() { }
        ~K() { }
        public void mK() { Console.WriteLine("K"); }
    }

class Program
    {
        public static void Main(string[] args)
        {
            D d = new D();
            E e = new E();
            F f = new F();
            K k = new K();

            B b = new B(d);
            C c = new C(e,f,k);
            J j = new J(c);
            A a = new A(b, j);

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
