using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicType3
{
    class Program
    {
        static void Main(string[] args)
        {
            // The dynamic variable gets the return 
            // value of a function call and outputs it.
            dynamic x = DoubleIt("2"); //  2.ToString()
            Console.WriteLine(x);

            // Stop and wait
            Console.WriteLine("Press any key");
            Console.ReadLine();

        }

        private static dynamic DoubleIt(dynamic p)
        {
            // Attempt to "double" the argument whatever 
            // that happens to produce

            return p + p;
        }

    }
}
