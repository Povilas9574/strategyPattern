using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class PotentialLossCalculatorLowRisk : PotentialLossCalculator
    {
        public decimal CalculatePotentilLoss(decimal loanAmount)
        {
            return (decimal)0.2 * loanAmount;
        }
    }
}
