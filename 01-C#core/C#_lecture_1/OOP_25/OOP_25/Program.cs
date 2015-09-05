using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_25
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    throw new ArgumentException();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("1");
                    throw new Exception();
                }
                catch (Exception) 
                {
                    Console.WriteLine("2");
                }
                finally
                {
                    int i = 0;
                    Console.WriteLine("3");
                    int b = 2 / i;
                    Console.WriteLine("4");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("5");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("6");
            }
        }
    }
}
