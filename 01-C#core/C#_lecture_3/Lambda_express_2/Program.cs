using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Lambda_express_2
{
    delegate int del(int i);

    class Program
    {
        static void Main(string[] args)
        {
            del myDelegate = x => x * x;
            Console.WriteLine(myDelegate);
            int j = myDelegate(5);
            Console.WriteLine(j);


            Expression<del> myET = x => x * x * x;
            Console.WriteLine(myET);
            Console.WriteLine(myET.Compile()(2));
        }
    }
}
