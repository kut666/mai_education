using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    public class Stack<T> // Обобщенный тип - Стек
    {
        int position;
        T[] data = new T[100];

        public void Push(T obj) { data[position++] = obj; }
        public T Pop() { return data[--position]; }

        public void swap(ref T s1, ref T s2)
        {
            T temp = s1;
            s1 = s2;
            s2 = temp;
        }
    }

    class Wel<T1, T2>
    {
        public Wel() { }
        ~Wel() { }
        public void pas(T1 t1, T2 t2)
        {
            Console.WriteLine("Значение первого типа " + t1);
            Console.WriteLine("Тип второго значения- " + typeof(T2));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(5);
            stack.Push(10);
            Console.WriteLine(stack.Pop());
            Console.WriteLine();

            Stack<bool> bstack = new Stack<bool>();
            bstack.Push(5 > 3);
            bstack.Push(10 < 2);
            Console.WriteLine(bstack.Pop());
            Console.WriteLine();

            Stack<string> stack1 = new Stack<string>();
            stack1.Push("Adam");
            stack1.Push("Mike");
            string y = stack1.Pop();

            Stack<string> stack2 = new Stack<string>();
            stack2.Push("Eva");
            stack2.Push("Railly");

            string x = stack2.Pop();


            Console.WriteLine("До swap ");
            Console.WriteLine(x + " " + y);

            stack.swap(ref x, ref y);

            Console.WriteLine("После swap");
            Console.WriteLine(x + " " + y);
            Console.WriteLine();

            Wel<bool, int> wel = new Wel<bool, int>();
            wel.pas(5 > 3, 8);

            Console.ReadKey();
        }
    }
}