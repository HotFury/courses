using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polymorphism_1
{
    class A
    {
        public void M()
        {
            Console.WriteLine("A");
        }
        public virtual void M1()
        {
            Console.WriteLine("A1");
        }
        
    }

    class B : A
    {
        public new void M()
        {
            Console.WriteLine("B");
        }
        public override void M1()
        {
            Console.WriteLine("B1");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            A ab = new B();
           // B ba = new A();    

            a.M();
            b.M();
            ab.M();
            ((A)b).M();

            a.M1();
            b.M1();
            ab.M1();
            ((A)b).M1();
            
          

        }
    }
}
