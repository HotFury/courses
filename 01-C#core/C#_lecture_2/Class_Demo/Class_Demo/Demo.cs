using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Class_Demo
{
    class Demo : IEnumerable
    {
        private int x;
        private int y;
        private int z;

        public Demo(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public IEnumerator GetEnumerator()
        { 
            yield return x;
            yield return y;
            yield return z;
        }
    }

}
