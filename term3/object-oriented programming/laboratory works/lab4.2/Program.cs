using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4._2._1
{
    class D
    {
        public D()
        {
            Console.WriteLine("Конструкор класса D");
        }

        ~D()
        {
            Console.WriteLine("Деструктор класса D");
            System.Threading.Thread.Sleep(1000);
        }
        public virtual void Method_D() { }
    }
    interface iE
    {
        void Method_iE();
    }

    interface iF
    {
        void Method_iF();
    }
    class C : D, iE, iF
    {
        public C()
        {
            Console.WriteLine("Конструкор класса C");
        }

        ~C()
        {
            Console.WriteLine("Деструктор класса C");
            System.Threading.Thread.Sleep(1000);
        }

        public void Method_iE()
        {
            Console.WriteLine("Определение метода из E в классе C");
        }

        public virtual void Method_iF()
        {
            Console.WriteLine("Определение метода из F в классе C");
        }

        public virtual void Method_C()
        {
            Console.WriteLine("Определение метода C ");
        }
    }
    interface iK
    {
        void Method_iK();
    }
    interface iJ : iK
    {
        void Method_iJ();
    }
    class A : C, iJ
    {
        public A()
        {
            Console.WriteLine("Конструкор класса A");
        }

        ~A()
        {
            Console.WriteLine("Деструктор класса A");
            System.Threading.Thread.Sleep(1000);
        }

        public void Method_iJ()
        {
            Console.WriteLine("Метод iJ");
        }

        public override void Method_iF()
        {
            Console.WriteLine("Метод iF");
            base.Method_iF();
        }

        public void Method_iK()
        {
            Console.WriteLine("Метод iK");
        }

        public override void Method_C()
        {
            Console.WriteLine(" метод C ");
            base.Method_C();
        }
        public void Method_A()
        {
            Console.WriteLine("Метод A");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            /*A a = new A(); 
            Console.WriteLine(); 
            a.Method_A();*/

            iK k = new A();
            Console.WriteLine();

            k.Method_iK();

            ((iJ)k).Method_iJ();

            ((A)k).Method_A();


            Console.ReadKey();
            /* a.Method_C(); 
            a.Method_D(); 
            a.Method_iF(); 
            a.Method_iE(); 
            Console.WriteLine(); 

            a.Method_iJ(); 
            a.Method_iK(); 
            */
            /* iJ j = new A(); 
            j.Method_iJ(); 
            j.Method_iK();*/
        }
    }
}
