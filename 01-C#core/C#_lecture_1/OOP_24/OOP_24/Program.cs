using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_24
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    Console.WriteLine("1");
                    //Генерируем исключение
                    throw new ArgumentException();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("2");
                    //Генерируем исключение
                    throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("3");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("4");
            }
        }

    }
}
