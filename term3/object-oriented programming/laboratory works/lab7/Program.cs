using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    class B
    { //server
        public B() { }
        ~B() { }
        public int f() { return 77; }
    }

    static class C
    { // utility 
        public static int f() { return 11; }
    }

    class A
    {
        public A() { }
        ~A() { }
        public void m(B b) { Console.WriteLine(" class A client m() {0}", b.f()); }
        public void utility() { Console.WriteLine(" class C utility f  {0}", C.f()); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            A a = new A();
            a.m(b);
            //
            a.utility();
            C.f();

            Console.ReadKey();

        }
    }
}
