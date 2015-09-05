using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tale
{
    // class for adding method to objects that extends 'Human'
    static class SpellExtention
    {
        // spell method
        static public void Spell(this Human human)
        {
            Console.WriteLine("Лети, лети, лепесток,");
            Console.WriteLine("Через запад на восток,");
            Console.WriteLine("Через север, через юг,");
            Console.WriteLine("Возвращайся, сделав круг.");
            Console.WriteLine("Лишь коснешься ты земли -");
            Console.WriteLine("Быть по-моему вели.");

        }
    }
}
