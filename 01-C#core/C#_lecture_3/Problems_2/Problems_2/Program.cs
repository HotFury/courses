using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems_2
{
    delegate int Sum(int number);
    class Program
    {
        static Sum SomeVar()
        {
            int result = 0;
            // Вызов анонимного метода
            Sum del = delegate(int number)
            {
                for (int i = 0; i <= number; i++)
                    result += i;
                return result;
            };
            return del;
        }

        static void Main(string[] args)
        {
            Sum del1 = SomeVar();

            Console.WriteLine("Cумма от 1 до {0} равна: {1}", 5, del1(5));
            Console.WriteLine("Cумма от 1 до {0} равна: {1}", 2, del1(2));
        }
    }
}
