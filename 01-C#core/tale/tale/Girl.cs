using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tale
{
    class Girl : Human
    {
        private Flower flower;  // flower that grnady will give
        private string wish;    // current wish
        public event EventHandler<NewWishEventArgs> useLeaf;  // event for leaf using
        public Girl(string name, int age) : base(name, age)
        {
            Console.WriteLine("Жила девочка {0} {1} лет. Однажды послала её мама в магазин за баранками.",this.Name, this.Age);
            Console.WriteLine("Купила Женя семь баранок.");
            wish = "";
        }
        
        public void TakeBagel()
        {
            Console.WriteLine("Взяла Женя связку баранок и отправилась домой.");
            Console.WriteLine("Идет, по сторонам зевает, вывески читает, ворон считает.");
            Console.WriteLine("Обернулась, да уж поздно. Мочалка болтается пустая, а собака последнюю,");
        }

        public void LooseBagel()
        {
            Console.WriteLine("розовую Павликову бараночку доедает, и счастливо облизывается.");
            Console.WriteLine("- Ах, вредная собака! - закричала Женя и бросилась ее догонять.");
            Console.WriteLine("Бежала, бежала, собаку не догнала, только сама заблудилась.");
        }
        // take flower from Grandy
        public void TakeFlower(Flower flower)
        {
            this.flower = flower; // flower that Grandy give became also Girl flower
            Console.WriteLine("Женя вежливо поблагодарила старушку, вышла за калитку");
            Console.WriteLine("И решила она позагадывать желания");
        }
        // method for notify registrated objects about event
        public void OnUseLeaf(NewWishEventArgs e)
        {
            // if object registrated
            if (useLeaf != null)
            {
                useLeaf(this, e); // notify object
                int leafsCount = flower.GetLeafCount();
                int index = new Random().Next(0, leafsCount);               
                this.Spell();
                Console.WriteLine("Не успела она это сказать, как в тот же миг");
                Console.WriteLine("желание ({0}) исполнилось", wish);
            }

        }
        // method for translation information about event
        public void TakeOffLeaf(string wish)
        {
            int leafIndex = new Random().Next(0,this.flower.GetLeafCount());
            NewWishEventArgs e = new NewWishEventArgs(wish, leafIndex);
            OnUseLeaf(e);
        }

        public void MakeWish(string wish)
        {
            this.wish = wish;
        }
    }
}
