using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicType2
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic p;
            int q = 2;
            p = q;
            if (p==q)
            Console.WriteLine(p);
            p="s";
            Console.WriteLine(p);

        }
    }
}
