using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tale
{
    class Tale
    {
        // method tell you unique tale =))
        public void TellTale()
        {
            Console.WriteLine("***Сказка Цветик семицветик***");
            // girl walking from the store
            Girl girl = new Girl("Женя", new Random().Next(5,15));
            girl.TakeBagel();
            girl.LooseBagel();
            // grandy show up
            Grandy grandy = new Grandy("Галина Петровна", new Random().Next(60,95));
            
            girl.TakeFlower(grandy.GiveFlower(girl)); // grandy give girl flower
            // here start your action
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите приличное желание: ");
                string wish = Console.ReadLine();
                girl.MakeWish(wish);
                try
                {
                    girl.TakeOffLeaf(wish);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Не осталось у Жени больше лепесточков");
                    break;
                }
            }
            Console.WriteLine("Вот и сказочки конец! Кто дочитал - тот молодец!");
        }
    }
}
