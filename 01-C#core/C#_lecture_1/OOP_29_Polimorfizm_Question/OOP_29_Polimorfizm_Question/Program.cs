using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_29_Polimorfizm_Question
{
    class A
    { 
        public virtual void M() { Console.Write("A"); } 
    }
    class B : A
    { 
        public override void M() { Console.Write("B"); } 
    }
    class C : B
    { 
        public new virtual void M() { Console.Write("C"); } 
    }
    class D : C
    {
        public override void M() { Console.Write("D"); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            {
                D d = new D(); C c = d; B b = c; A a = b;
                d.M(); c.M(); b.M(); a.M();
                Console.WriteLine();
                
            }
        }

    }
}
    

