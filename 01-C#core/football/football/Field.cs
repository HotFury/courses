using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace football
{
    class Field
    {
        private Team team1;
        private Team team2;
        private Judge judge;

        public Team Team1
        {
            get { return team1; }
        }
        public Team Team2
        {
            get { return team2; }
        }
        public Judge Judge
        {
            get { return judge; }
        }

        public Field(int playersCount, string team1Name, string team2Name, string judgeName)
        {
            this.team1 = new Team(playersCount, team1Name);
            this.team2 = new Team(playersCount, team2Name);
            this.judge = new Judge();
            this.judge.InitName(judgeName);
            this.judge.InitAge();
            this.judge.InitHonest();
        }
    }
}
