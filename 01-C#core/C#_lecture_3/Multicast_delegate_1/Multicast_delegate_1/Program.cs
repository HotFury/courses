﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Multicast_delegate_1
{
    delegate void Del(string s);
    delegate void MyDel();

    class Program
    {
        static void Hello(string s)
        {
            System.Console.WriteLine("  Hello, {0}!", s);
        }

        static void Goodbye(string s)
        {
            System.Console.WriteLine("  Goodbye, {0}!", s);
        }

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


        static void Main()
        {
            Del a, b, c, d;

            // Create the delegate object a that references 
            // the method Hello:
            a = Hello;

            // Create the delegate object b that references 
            // the method Goodbye:
            b = Goodbye;

            // The two delegates, a and b, are composed to form c: 
            c = a + b;
            //c = Hello;
            c += Goodbye;
            // Remove a from the composed delegate, leaving d, 
            // which calls only the method Goodbye:
            d = c - a;

            //System.Console.WriteLine("Invoking delegate a:");
            //a("A");
            //System.Console.WriteLine("Invoking delegate b:");
            //b("B");
            //System.Console.WriteLine("Invoking delegate c:");
            //c("C");
            //System.Console.WriteLine("Invoking delegate d:");
            //d("D");

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