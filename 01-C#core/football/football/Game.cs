using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Schema;

namespace football
{
    internal class Game
    {
        private const int MinOffer = 1000000;
        private const int MaxOffer = 10000000;
        private string[] Names = new string[] { "player1", "player2", "player3", "player4", "player5", "player6", "player7", "player8", "player9", "player10", "player11", "player12", "player13", "player14", "player15", "player16", "player17", "player18", "player19", "player20", "player21", "player22", "player23", "player24" };
        private Field field;
        public string winner;
        public Game(int playersCount, string team1Name, string team2Name, string judgeName)
        {
            field = new Field(playersCount, team1Name, team2Name, judgeName);
            winner = "";
        }

        public void MakeGame()
        {
            field.Judge.InitHonest();
            field.Judge.InitMoneyCoefficient(MaxOffer);
            field.Team1.InitPlayers(Names.ToList());
            field.Team1.InitCoach("coach1");
            field.Team1.CalculateSkill();
            field.Team2.InitPlayers(Names.ToList());
            field.Team2.InitCoach("coach2");
            field.Team2.CalculateSkill();
            field.Team1.GiveMoney(MinOffer, MaxOffer);
            field.Team2.GiveMoney(MinOffer, MaxOffer);
            field.Team1.ViewTeamInfo();
            field.Team2.ViewTeamInfo();
            Console.Write("Team: {0} ", field.Team1.TeamName);
            Console.Write("Give judge {0} $ ", field.Team1.MoneyToJudge);
            Console.Write("with skill {0}", field.Team1.Skill);
            Console.WriteLine();
            Console.Write("Team: {0} ", field.Team2.TeamName);
            Console.Write("Give judge {0} $ ", field.Team2.MoneyToJudge);
            Console.Write("with skill {0}", field.Team2.Skill);
            Console.WriteLine();
            if (field.Team1.MoneyToJudge >= field.Team2.MoneyToJudge)
            {
                if (field.Judge.JudgeGivePerk(field.Team1.MoneyToJudge))
                {
                    Thread.Sleep(20);
                    int score = new Random().Next(100, 900);
                    Console.WriteLine("Judge added {0} {1} scores", field.Team1.TeamName, score);
                    field.Team1.JudgeHint(score);
                    field.Team2.JudgeTicket(score);
                }
                
            }
            else
            {
                if (field.Judge.JudgeGivePerk(field.Team1.MoneyToJudge))
                {
                    int score = new Random().Next(100, 500);
                    Console.WriteLine("Judge added {0} {1} scores", field.Team2.TeamName, score);
                    field.Team2.JudgeHint(score);
                    field.Team1.JudgeTicket(score);
                }
            }
            
            Console.Write("Winner is ");
            if (field.Team1.Skill > field.Team2.Skill)
            {
                Console.Write(field.Team1.TeamName);
                Console.WriteLine();
            }
            else
            {
                Console.Write(field.Team2.TeamName);
                Console.WriteLine();
            }
        }
    }
}
