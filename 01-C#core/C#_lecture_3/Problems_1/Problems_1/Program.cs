using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems_1
{
    delegate void MyDel();

    class Program
    {
        static void Method1()
        {
            Console.WriteLine("Method 1");
        }
        static void Method2()
        {
            Console.WriteLine("Method 2");
        }
        static void Method3()
        {
            Console.WriteLine("Method 3");
        }

        static void Main(string[] args)
        {
            MyDel x, y, z;
            x = Method1;
            x += Method2;
            x += Method3;

            y = Method2;
            y += Method1;
            

            z = x - y;
            z();      
        }
    }
}
