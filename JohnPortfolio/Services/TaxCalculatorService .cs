using JohnPortfolio.Interfaces;

namespace JohnPortfolio.Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        public decimal CalculateTax(decimal taxableIncome)
        {
            decimal taxAmount = 0;

            if (taxableIncome <= 300000)
            {
                taxAmount = taxableIncome * 0.07m;  // 7% for income <= 300,000
            }
            else if (taxableIncome <= 600000)
            {
                taxAmount = (300000 * 0.07m) + ((taxableIncome - 300000) * 0.11m);  // 7% for the first 300,000, 11% for the next 300,000
            }
            else if (taxableIncome <= 1100000)
            {
                taxAmount = (300000 * 0.07m) + (300000 * 0.11m) + ((taxableIncome - 600000) * 0.15m);  // 15% for the next 500,000
            }
            else if (taxableIncome <= 1600000)
            {
                taxAmount = (300000 * 0.07m) + (300000 * 0.11m) + (500000 * 0.15m) + ((taxableIncome - 1100000) * 0.19m);  // 19% for the next 500,000
            }
            else if (taxableIncome <= 3200000)
            {
                taxAmount = (300000 * 0.07m) + (300000 * 0.11m) + (500000 * 0.15m) + (500000 * 0.19m) + ((taxableIncome - 1600000) * 0.21m);  // 21% for the next 1,600,000
            }
            else
            {
                taxAmount = (300000 * 0.07m) + (300000 * 0.11m) + (500000 * 0.15m) + (500000 * 0.19m) + (1600000 * 0.21m) + ((taxableIncome - 3200000) * 0.24m);  // 24% for income above 3,200,000
            }

            return taxAmount;
        }
    }
}
