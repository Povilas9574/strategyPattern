using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            LoanCalculator loanCalculator = null;
            PotentialLossCalculator lossCalculator = null;
            PrivateClientLoan privateLoan = null;
            CorporateClientLoan corporateLoan = null;
            decimal loanAmount;
            double interestRate;
            int period;

            int i;

            Console.WriteLine("Kiek planuojama pasiskolinti? ");
            loanAmount = Decimal.Parse(Console.ReadLine());

            Console.WriteLine("Kokios metinės palūkanos? ");
            interestRate = Double.Parse(Console.ReadLine());

            Console.WriteLine("Kokiam laikotarpiui planuojama pasiskolinti?");
            period = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Koks paskolos atidavimo būdas: \n 1. Anuitetas \n 2. Linijinis \n");
            i = Int32.Parse(Console.ReadLine());

            switch(i)
            {
                case 1:
                    loanCalculator = new LoanAnnuityCalculator(loanAmount, interestRate, period);
                    break;

                case 2:
                    loanCalculator = new LoanLinearCalculator(loanAmount, interestRate, period);
                    break;
            }

            Console.WriteLine("Koks kliento rizikos lygis: \n 1. Aukštas \n 2. Žemas \n");
            i = Int32.Parse(Console.ReadLine());

            switch(i)
            {
                case 1:
                    lossCalculator = new PotentialLossCalculatorHighRisk();
                    break;

                case 2:
                    lossCalculator = new PotentialLossCalculatorLowRisk();
                    break;
            }

            Console.WriteLine("Kokia paskolos rūšis: \n 1. Privatiems asmenims \n 2. Įmonėms \n");
            i = Int32.Parse(Console.ReadLine());

            switch (i)
            {
                case 1:
                    privateLoan = new PrivateClientLoan(loanAmount, interestRate, period, loanCalculator, lossCalculator);
                    break;

                case 2:
                    corporateLoan = new CorporateClientLoan(loanAmount, interestRate, period, loanCalculator, lossCalculator);
                    break;
            }

            while (true)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("1. Kiek reikės sumokėti iš viso?");
                Console.WriteLine("2. Paskaičiuoti mėnesio įmoką.");
                Console.WriteLine("3. Kiek reikės grąžinti palūkanų iš viso?");
                Console.WriteLine("4. Kiek liko sumokėti?");

                if (privateLoan != null)
                {
                    Console.WriteLine("5. Pridėti užstatą. \n");
                    Console.WriteLine("6. Kiek bankui reikia atidėti pinigų, kad būtų pasirengęs padengti nuostolius?");
                }
                else
                    Console.WriteLine("5. Pridėti laiduotoją. \n");
                i = Int32.Parse(Console.ReadLine());

                if (privateLoan != null)
                {
                    switch(i)
                    {
                        case 1:
                            Console.WriteLine("Reikia sumokėti: {0}", privateLoan.CalculateAmountToPay());
                            break;
                        case 2:
                            Console.WriteLine("Kelintas mėnesis? ");
                            Console.WriteLine("Įmoka: {0}", privateLoan.CalculatePayment(Int32.Parse(Console.ReadLine())));
                            break;
                        case 3:
                            Console.WriteLine("Iš viso reikės grąžinti {0} eurų palūkanų.", privateLoan.CalculateInterestAmount());
                            break;
                        case 4:
                            Console.WriteLine("Už kiek mėnesių jau sumokėta? ");
                            Console.WriteLine("Liko sumokėti {0} eur.", privateLoan.CalculateLeftToPayAmount(Int32.Parse(Console.ReadLine())));
                            break;
                        case 5:
                            Console.WriteLine("Kokia užstato vertė? ");
                            privateLoan.AddCollateralValue(Decimal.Parse(Console.ReadLine()));
                            break;
                        case 6:
                            Console.WriteLine("Bankas turi atidėti {0} eur.", privateLoan.CalculatePotentialLoss());
                            break;
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 1:
                            Console.WriteLine("Reikia sumokėti: {0}", corporateLoan.CalculateAmountToPay());
                            break;
                        case 2:
                            Console.WriteLine("Kelintas mėnesis? ");
                            Console.WriteLine("Įmoka: {0}", corporateLoan.CalculatePayment(Int32.Parse(Console.ReadLine())));
                            break;
                        case 3:
                            Console.WriteLine("Iš viso reikės grąžinti {0} eurų palūkanų.", corporateLoan.CalculateInterestAmount());
                            break;
                        case 4:
                            Console.WriteLine("Už kiek mėnesių jau sumokėta? ");
                            Console.WriteLine("Liko sumokėti {0} eur.", corporateLoan.CalculateLeftToPayAmount(Int32.Parse(Console.ReadLine())));
                            break;
                        case 5:
                            Console.WriteLine("Koks laiduotojo asmens kodas? ");
                            corporateLoan.SetGuarantor(Console.ReadLine());
                            break;
                    }
                }

            }

        }
    }
}
