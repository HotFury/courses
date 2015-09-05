using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace football
{
    class Player : Human
    {
        private int skill; // from 1 to 100

        public int Skill 
        {
            get
            {
                return skill;
            }
        }

        public Player() : base()
        {
            this.skill = 0;
        }
        public int InitSkillValue()
        {
            Thread.Sleep(20);
            return this.skill = new Random().Next(1, 100);
        }
    }
}
