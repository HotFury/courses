using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace NameValueCollection_1
{
    class Program
    {
        static void Main(string[] args)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("city", "New York");
            nvc.Add("country", "U.S.");
            nvc.Add("city", "California");
            nvc.Add("city", "California");
            nvc.Add("city", "Boston");

           // nvc.Remove("city");
            nvc.Add("country", "United States");
            foreach (string key in nvc.AllKeys)
                Console.WriteLine("{0} = {1}", key, nvc.Get(key));
            // alternate way
            for (int x = 0; x < nvc.Count; x++)
            {
                Console.WriteLine(nvc.Get(x));
            }
        }
    }
}
