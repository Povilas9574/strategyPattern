using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class LoanAnnuityCalculator : LoanCalculator
    {
        private decimal loanAmount;
        private double interestRate;
        private int period;

        public LoanAnnuityCalculator(decimal loanAmount, double interestRate, int period)
        {
            this.loanAmount = loanAmount;
            this.interestRate = interestRate / 100;
            this.period = period;
        }

        public decimal CalculateInterestAmount()
        {
            return CalculatePayment() * period - loanAmount;
        }

        public decimal CalculateLeftToPayAmount(int month)
        { 
            return loanAmount + CalculateInterestAmount() - CalculatePayment() * month;
        }

        public decimal CalculatePayment(int month = 0)
        {
            double coeff = (interestRate/12 * (Math.Pow(1 + interestRate/12, period)) / (Math.Pow(1 + interestRate/12, period) - 1));
            return loanAmount * (decimal)coeff;
        }

        public decimal CalculateAmountToPay()
        {
            return CalculateInterestAmount() + loanAmount;
        }
    }
}
