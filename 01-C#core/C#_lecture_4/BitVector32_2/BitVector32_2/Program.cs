using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace BitVector32_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a BitVector32 with all of its bit flags set to false.
            BitVector32 bv = new BitVector32(0);
            // Create masks to isolate each of the first five bit flags.
            int myBit1 = BitVector32.CreateMask();
            int myBit2 = BitVector32.CreateMask(myBit1);
            int myBit3 = BitVector32.CreateMask(myBit2);
            int myBit4 = BitVector32.CreateMask(myBit3);
            int myBit5 = BitVector32.CreateMask(myBit4);
            // Set alternating bits to true.
            bv[myBit1] = true;
            bv[myBit3] = true;
            bv[myBit5] = true;
            Console.WriteLine(bv.ToString() + " = " + bv.Data);
        }
    }
}
