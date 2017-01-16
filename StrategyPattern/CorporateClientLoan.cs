using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class CorporateClientLoan
    {
        private LoanCalculator loanCalculator;
        private PotentialLossCalculator lossCalculator;
        private decimal loanAmount;
        private double interestRate;
        private int period;
        private String guarantorId;

        public CorporateClientLoan(decimal loanAmount, double interestRate, int period, LoanCalculator loanCalculator, PotentialLossCalculator lossCalculator)
        {
            this.loanAmount = loanAmount;
            this.interestRate = interestRate;
            this.period = period;
            this.loanCalculator = loanCalculator;
            this.lossCalculator = lossCalculator;
        }

        public decimal CalculateAmountToPay()
        {
            return loanCalculator.CalculateInterestAmount() + loanAmount;
        }

        public void SetGuarantor(String guarantorId)
        {
            this.guarantorId = guarantorId;
        }

        public decimal CalculatePayment(int month)
        {
            return loanCalculator.CalculatePayment(month);
        }

        public decimal CalculateInterestAmount()
        {
            return loanCalculator.CalculateInterestAmount();
        }

        public decimal CalculateLeftToPayAmount(int month)
        {
            return loanCalculator.CalculateLeftToPayAmount(month);
        }

        public decimal CalculatePotentialLoss()
        {
            return lossCalculator.CalculatePotentilLoss(loanAmount);
        }
    }
}
