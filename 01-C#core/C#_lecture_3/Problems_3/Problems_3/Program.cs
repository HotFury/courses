using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems_3
{
    delegate void MyDel1 ();
    delegate void MyDel2(int x);
    delegate int MyDel3(string s);

    class Program
    {
        static void Main(string[] args)
        {
            MyDel1 md1 = delegate
            {
                Console.WriteLine("Делегат без параметров");
            };
            md1();


        }
    }
}
