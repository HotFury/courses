using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace BitVector32_1
{
    class Program
    {
        static void Main(string[] args)
        {
            BitVector32 bv = new BitVector32(1);

            Console.WriteLine(bv.ToString() + " = " + bv.Data);

            int b1 = BitVector32.CreateMask();
            int b2 = BitVector32.CreateMask(b1);
            bv[b1] = true;
            bv[b2] = true;
            Console.WriteLine(bv.ToString() + " = " + bv.Data);      
            
            BitVector32.Section s1 = BitVector32.CreateSection(8);
            BitVector32.Section s2 = BitVector32.CreateSection(10, s1);
            bv[s1] = 8;
            Console.WriteLine(bv.ToString() + " = " + bv.Data);
            Console.WriteLine(bv[s1]);
            bv[s2] = -10;
            Console.WriteLine(bv.ToString() + " = " + bv.Data);
            Console.WriteLine(bv[s2]);
        }
    }
}
