using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    interface PotentialLossCalculator
    {
        decimal CalculatePotentilLoss(decimal loanAmount);
    }
}
