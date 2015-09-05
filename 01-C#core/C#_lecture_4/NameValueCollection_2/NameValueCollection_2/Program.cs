using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace NameValueCollection_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an empty NameValueCollection and add multiple values for each key.
            NameValueCollection nvCol = new NameValueCollection();
            nvCol.Add("Minnesota", "St. Paul");
            nvCol.Add("Minnesota", "Minneapolis");
            nvCol.Add("Minnesota", "Rochester");
            nvCol.Add("Florida", "Miami");
            nvCol.Add("Florida", "Orlando");
            nvCol.Add("Arizona", "Pheonix");
            nvCol.Add("Arizona", "Tucson");
            // Get the key at index position 0 (Minnesota).
            string key = nvCol.GetKey(0);
            Console.WriteLine("Key 0: {0}", key);
            // Remove the entry for Minnesota by its key.
            nvCol.Remove(key);
            // Get the values for Florida as a string array.
            foreach (string val in nvCol.GetValues("Florida"))
            {
                Console.WriteLine("A value for 'Florida': {0}", val);
            }
            // Iterate through the entries (Florida and Arizona) in the NameValueCollection.
            foreach (string k in nvCol)
            {
                // Get the values for an entry as a comma-separated list.
                Console.WriteLine("Key: {0} Values: {1}", k, nvCol.Get(k));
            }
        }
    }
}
