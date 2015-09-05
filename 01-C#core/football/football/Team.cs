using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Schema;

namespace football
{
    class Team
    {
        private List<Player> players;
        private Coach coach;
        private int playersCount;
        private string teamName;
        private double skill;
        private double moneyToJudge;
        public List<Player> Players
        {
            get { return players; }
        }

        public string TeamName
        {
            get { return teamName; }
        }

        public double Skill
        {
            get { return skill; }
        }

        public double MoneyToJudge
        {
            get { return moneyToJudge; }
        }
        public Team(int playersCount, string teamName)
        {
            this.moneyToJudge = 0;
            this.teamName = teamName;
            this.playersCount = playersCount;
            players = new List<Player>();
            coach = new Coach();
            skill = 0;
        }

        public void InitPlayers(List<string> names)
        {

            for (int i = 0; i < playersCount; i++)
            {
                Players.Add(new Player());
                int num = new Random().Next(0, names.Count);
                Players[i].InitName(names[num]);
                names.RemoveAt(num);
                Players[i].InitAge();
                Players[i].InitSkillValue();
            }
        }

        public void InitCoach(string name)
        {
            coach.InitName(name);
            coach.InitAge();
            coach.InitLuck();
        }

        public double CalculateSkill()
        {
            this.skill = 0;
            foreach (Player player in Players)
            {
                this.skill += player.Skill;
            }
            this.skill *= coach.Luck;
            return this.skill;
        }

        public double JudgeTicket(double ticketValue)
        {
            return this.skill -= ticketValue;
        }

        public double JudgeHint(double hintValue)
        {
            return this.skill += hintValue;
        }

        public double GiveMoney(int minOffer, int maxOffer)
        {
            Thread.Sleep(20);
            return this.moneyToJudge =  new Random().Next(minOffer, maxOffer);
        }

        public void ViewTeamInfo()
        {
            Console.WriteLine(teamName);
            foreach(Player player in players)
                Console.WriteLine("player {0} age {1} has skill power:{2} ",player.Name, player.Age, player.Skill);
        }
    }
}
