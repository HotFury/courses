using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tale
{
    class Flower
    {
        List<Leaf> leaf = new List<Leaf>(); 
        public Flower(Girl girl)
        {
            // adding leafs
            leaf.Add(new Leaf("жёлтый", ConsoleColor.Yellow));
            leaf.Add(new Leaf("красный", ConsoleColor.Red));
            leaf.Add(new Leaf("зелёный", ConsoleColor.Green));
            leaf.Add(new Leaf("синий", ConsoleColor.DarkBlue));
            leaf.Add(new Leaf("оранжевый", ConsoleColor.DarkYellow));
            leaf.Add(new Leaf("фиолетовый", ConsoleColor.Magenta));
            leaf.Add(new Leaf("голубой", ConsoleColor.Blue));
            // this object will get notufy about event
            girl.useLeaf += DeleteLeaf;
        }

        public void DeleteLeaf(object sender, NewWishEventArgs e)
        {
            
            string leafColor = leaf[e.LeafIndex].Color;
            Console.BackgroundColor = leaf[e.LeafIndex].ConsoleColor;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("оторвала Женя {0} лепесток, кинула его и сказала:", leafColor);
            leaf.RemoveAt(e.LeafIndex);
        }
        
        public int GetLeafCount()
        {
            return leaf.Count;
        }
    }
}
