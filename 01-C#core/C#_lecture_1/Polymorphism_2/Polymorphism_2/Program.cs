using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polymorphism_2
{
    class A
    {
        public virtual void M(int param)
        {
            Console.WriteLine("A int param");
        }

    }

    class B : A
    {
        
        public void M(double param)
        {            
            Console.WriteLine("B double param");
        }
        public void M(long param)
        {
            Console.WriteLine("B long param");
        }
        public override void M(int param)
        {
            Console.WriteLine("B int param");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            int x = 5;
            a.M(x);
            b.M(x);
            ((A)b).M(x);

        }
    }
}
