using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Class_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo d = new Demo(4, 2, 8);
            int i = 1;
            foreach(var t in d)
            {
                Console.WriteLine("Значение {0}-го поля равно {1}", i++, t);
            }

        }
    }
}
