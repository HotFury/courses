using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethods_7
{
    public interface IMyInterface
    {       
        void MethodB();
    }

    class A : IMyInterface
    {
        public void MethodB() { Console.WriteLine("A.MethodB()"); }
    }

    class B : IMyInterface
    {
        public void MethodB() { Console.WriteLine("B.MethodB()"); }
        public void MethodA(int i) { Console.WriteLine("B.MethodA(int i)"); }
    }

    class C : IMyInterface
    {
        public void MethodB() { Console.WriteLine("C.MethodB()"); }
        public void MethodA(object obj)
        {
            Console.WriteLine("C.MethodA(object obj)");
        }
    }

    public static class Extension
    {
        public static void MethodA(this IMyInterface myInterface, int i)
        {
            Console.WriteLine("Расширяющий метод MethodA с параметром int");
        }

        public static void MethodA(this IMyInterface myInterface, string s)
        {
            Console.WriteLine("Расширяющий метод MethodA с параметром string");
        }
      
        public static void MethodB(this IMyInterface myInterface)
        {
            Console.WriteLine("Расширяющий метод MethodB без параметров");
        }
    }   

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();
      
            c.MethodA(1);           
            c.MethodA("hello"); 
            c.MethodB();         
                       
        }

    }

}
