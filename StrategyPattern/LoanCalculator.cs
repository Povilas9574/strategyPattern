using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    interface LoanCalculator
    {
        decimal CalculatePayment(int month);
        decimal CalculateInterestAmount();
        decimal CalculateLeftToPayAmount(int month);
    }
}
