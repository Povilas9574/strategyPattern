using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class LoanLinearCalculator : LoanCalculator
    {
        private decimal loanAmount;
        private double interestRate;
        private int period;

        public LoanLinearCalculator(decimal loanAmount, double interestRate, int period)
        {
            this.loanAmount = loanAmount;
            this.interestRate = interestRate / 100;
            this.period = period;
        }

        public decimal CalculateInterestAmount()
        {
            return (decimal)interestRate / 12 * period * (2 * loanAmount - (period - 1) * loanAmount / period) / 2;
        }

        public decimal CalculateLeftToPayAmount(int month)
        {
            decimal leftToPay = loanAmount + CalculateInterestAmount();

            for (int i = 1; i <= month; i++)
            {
                leftToPay -= CalculatePayment(i);
            }
            return leftToPay;
        }

        public decimal CalculatePayment(int month)
        {
            return (loanAmount - (month - 1)* loanAmount / period) * (decimal)interestRate / 12 + loanAmount/period;
        }
    }
}
