using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqTest
{
    class Program
    {
        static double[] DeleteElements(double[] array, double lim)
        {
            IEnumerable<double> subset = from i in array where i < lim select i;
            return subset.ToArray();
        }
        static void Main(string[] args)
        {
            double[] numbers = {10, 50, 1, 2, 6, 85, 25, 9};
            int lim = 10;
            double[] res = DeleteElements(numbers, lim);
            for (int i = 0; i < res.Length; i++)
            {
                Console.WriteLine(res[i]);
            }
        }
    }
}
