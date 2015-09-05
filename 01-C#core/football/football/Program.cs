using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace football
{
    class Program
    {
        static void Main(string[] args)
        {
            Game football = new Game(11, "team1", "team2", "judge1");
            football.MakeGame();
        }
    }
}
