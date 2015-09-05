using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lambda_express_6
{
    class Program
    {
        static Func<T, S> Chain<T, R, S>(Func<T, R> func1,
                                         Func<R, S> func2)
        {
            return x => func2(func1(x));
        }

        static void Main(string[] args)
        {
            Func<int, double> func = Chain((int x) => x * 3,
                                (int x) => x + 3.5);

            Console.WriteLine(func(2));
        }

    }
}
