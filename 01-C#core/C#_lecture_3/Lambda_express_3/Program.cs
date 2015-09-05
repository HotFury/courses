using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lambda_express_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> func = x => x;
            Console.WriteLine(func(5));
            
            // или можно так:
            var result = new Func<int, int>(x => x)(5);
            Console.WriteLine(result);

            var result1 = new Func<int, int>(x => x + 2)(2);
            Console.WriteLine(result1);

            var result2 = new Func<Func<int, int>, int>(x => x(2))(new Func<int, int>(y => y + 1));
            Console.WriteLine(result2);

            var result3 = new Func<int, Func<int, int>>(x => y => y + x + 3)(2);
            Console.WriteLine(result3);

            var result4 = new Func<int, Func<int, int>>(x => y => y - x + 3)(2)(3);
            Console.WriteLine(result4);
        }        
    }
}
