using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tale
{
    // type for leaf
    class Leaf
    {
        private string color;
        private ConsoleColor consoleColor;

        public string Color
        {
            get { return color; }
        }

        public ConsoleColor ConsoleColor
        {
            get { return consoleColor; }
        }
        public Leaf(string color, ConsoleColor consoleColor)
        {
            this.consoleColor = consoleColor;
            this.color = color;
        }
    }
}
