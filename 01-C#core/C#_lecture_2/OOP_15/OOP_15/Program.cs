using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_15
{
    interface I1
    {
        int Method(int x);
    }
    interface I2
    {
        int Method(int x);
    }

    class A : I1, I2
    {

        int I1.Method(int x)
        {
            return x + 1;
        }

        int I2.Method(int x)
        {
            return x + 2;
        }

        public int Method(int x)
        {
            return x+8;
        }
    }

   

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
           
            Console.WriteLine(a.Method(5));
            Console.WriteLine(((I1)a).Method(5));
            Console.WriteLine(((I2)a).Method(5));
                      
            I1 c1 = new A();
            I2 c2 = new A();
                      
            Console.WriteLine(c1.Method(5));
            Console.WriteLine(c2.Method(5));

            Console.WriteLine((a as I1).Method(5));
            
        }
    }

}
