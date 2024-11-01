namespace JohnPortfolio.Models
{
    public class TaxCalculation
    {
        public decimal MonthlyBasic { get; set; }
        public decimal HousingAllowance { get; set; }
        public decimal TransportAllowance { get; set; }
        public decimal OtherAllowance { get; set; }
        public decimal PensionRate { get; set; } = 8;
        public decimal TaxAmount { get; set; }
    }
}
