using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9_2_Lambda
{
    class Program
    {
        delegate int Lambda(int x, int y);
        delegate void Ld();

        static void Main(string[] args)
        {
            // Step 1. lambda
            Console.WriteLine(" Find index of first odd element in list");
            List<int> elements = new List<int>() { 10, 20, 31, 40 };
            // ... Find index of first odd element.
            int oddIndex = elements.FindIndex(x => x % 2 != 0);
            Console.WriteLine(elements[oddIndex]);
            Console.ReadKey();

            //Step 2. анонимный delegate  + lambda 
            Lambda lambda = delegate (int x, int y) {
                return x + y;
            };
            Console.WriteLine(" lambda {0} ", lambda(1, 2));

            Lambda lambda1 = (x, y) => x + y;
            Console.WriteLine(" lambda {0} ", lambda1(1, 2));

            Ld ld = () => Console.WriteLine(" ld ");
            ld();
            Console.ReadKey();

            Func<int, int> f1 = x => x + 1;

            Func<int, int> f2 = x => { return x + 1; };

            Func<int, int> f3 = (int x) => x + 1;

            Func<int, int> f4 = (int x) => { return x + 1; };

            Func<int, int, int> f5 = (x, y) => x * y;

            Action f6 = () => Console.WriteLine();

            Func<int, int> f7 = delegate (int x) { return x + 1; };

            Func<int> f8 = delegate { return 1 + 1; };

            Console.WriteLine(f1.Invoke(1));
            Console.WriteLine(f2.Invoke(1));
            Console.WriteLine(f3.Invoke(1));
            Console.WriteLine(f4.Invoke(1));
            Console.WriteLine(f5.Invoke(2, 2));
            f6.Invoke();
            Console.WriteLine(f7.Invoke(1));
            Console.WriteLine(f8.Invoke());

            Console.WriteLine(" Predicate<T> + Lambda");
            Console.ReadKey();

            Predicate<int> predicate = value => value == 5;
            Console.WriteLine(predicate.Invoke(4));
            Console.WriteLine(predicate.Invoke(5));

            Console.ReadKey();
        }

    }
}
