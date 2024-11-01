namespace JohnPortfolio.Interfaces
{
    public interface ITaxCalculatorService
    {
        decimal CalculateTax(decimal taxableIncome);
    }
}
