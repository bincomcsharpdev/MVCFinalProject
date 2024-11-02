using MVCFinalProject.Services.Interfaces;

namespace MVCFinalProject.Services.Implementations
{
    public class TaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal annualIncome) 
        {
            if (annualIncome < 0)
                throw new ArgumentOutOfRangeException(nameof(annualIncome), "Income cannot be negative.");

            decimal tax = 0;

            if (annualIncome > 0 && annualIncome <= 300000)
                tax = annualIncome * 0.07m;
            else if (annualIncome > 300000 && annualIncome <= 600000)
                tax = (300000 * 0.07m) + ((annualIncome - 300000) * 0.11m);
            else if (annualIncome > 600000 && annualIncome <= 1100000)
                tax = (300000 * 0.07m) + (300000 * 0.11m) + ((annualIncome - 600000) * 0.15m);
            else if (annualIncome > 1100000)
                tax = (300000 * 0.07m) + (300000 * 0.11m) + (500000 * 0.15m) + ((annualIncome - 1100000) * 0.24m);

            return tax;
        }
    }
}
