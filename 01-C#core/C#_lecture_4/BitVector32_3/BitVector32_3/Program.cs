using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace BitVector32_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a BitVector32 with all of its bits set to 0.
            BitVector32 bv = new BitVector32(0);
            // Create sections with maximum values 6, 3, 1, and 15.
            BitVector32.Section mySect1 = BitVector32.CreateSection(6);
            BitVector32.Section mySect2 = BitVector32.CreateSection(3, mySect1);
            BitVector32.Section mySect3 = BitVector32.CreateSection(1, mySect2);
            BitVector32.Section mySect4 = BitVector32.CreateSection(15, mySect3);
            // Set each section to a value.
            bv[mySect1] = 5;
            bv[mySect2] = 3;
            bv[mySect3] = 1;
            bv[mySect4] = 9;
            Console.WriteLine(bv[mySect4]);
            Console.WriteLine(bv.ToString() + " = " + bv.Data);
        }
    }
}
