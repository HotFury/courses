using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tale
{
    // base abstract class for girl and grandy
    abstract class Human
    {
        private readonly string name;
        private readonly int age;

        public string Name
        {
            get { return name; }
        }

        public int Age
        {
            get { return age; }
        }

        protected Human(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}
