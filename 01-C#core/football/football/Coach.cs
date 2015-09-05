using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace football
{
    class Coach : Human
    {
        private double luck;

        public double Luck
        {
            get { return luck; }
        }
        public Coach() : base()
        {
            luck = 0.0;
        }
        /*public Coach(string name, int age) : base(name, age)
        {
            luck = 0.0;
        }
        */
        public override int InitAge()
        {
            return this.Age = new Random().Next(40, 70);
        }

        public double InitLuck()
        {
            return this.luck = (double)new Random().Next(1, 10) / 10; // luck coefficient from 0.1 to 0.9
        }

    }
}
