using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace football
{
    class Judge : Human
    {
        private double honest; // honest coefficient (from 0.1 to 1)
        private double needMoney;
        private int moneyCoefficient;

        public double Honest
        {
            get { return honest; }
        }
        public Judge() : base()
        {
            this.honest = 0.0;
        }
        public double InitHonest()
        {
            return this.honest = (double) new Random().Next(1, 11) /10;
        }

        public double InitMoneyCoefficient(int moneyCoefficient)
        {
            return this.moneyCoefficient = moneyCoefficient;
        }
        public double InitNeedMoney()
        {
            return this.needMoney = this.honest * this.moneyCoefficient;
        }

        public bool JudgeGivePerk(double offer)
        {
            return offer > this.needMoney;
        }
    }
}
