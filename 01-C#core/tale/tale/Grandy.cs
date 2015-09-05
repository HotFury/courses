using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tale
{
    class Grandy : Human
    {
        public Grandy(string name, int age) : base(name, age)
        {
            Console.WriteLine("Вдруг откуда ни возьмись - старушка {0} {1} лет.",this.Name, this.Age);
            Console.WriteLine("- Девочка, девочка, почему ты плачешь?");
            Console.WriteLine("Женя старушке все и рассказала.");
        }
        // grandy make and gives flower to girl
        public Flower GiveFlower(Girl girl)
        {
            Console.WriteLine("Пожалела старушка Женю, привела ее в свой садик и говорит:");
            Console.WriteLine("- Ничего, не плачь, я тебе помогу.");
            Console.WriteLine("Я тебе подарю цветик-семицветик, он все устроит.");
            Console.WriteLine("С этими словами старушка подала девочке Жене цветок");
            Console.WriteLine("- Этот цветик может исполнить все, что ты захочешь.");
            Console.WriteLine("Для этого надо только оторвать один из лепестков, бросить его и сказать:");
            this.Spell();     // teaching girl make spell
            Flower flower = new Flower(girl); // giving flower
            return  flower;
        }
        
    }
}
