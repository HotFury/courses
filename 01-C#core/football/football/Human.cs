using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace football
{
    abstract class Human
    {
        private int age;
        private string name;
        public Human()
        {
            this.age = 0;
            this.name = "";
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
        }

        public virtual int InitAge()
        {
            return this.age = new Random().Next(20, 55);
        }

        public string InitName(string name)
        {
            return this.name = name;
        }

    }
}
