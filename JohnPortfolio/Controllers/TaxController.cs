using JohnPortfolio.Interfaces;
using JohnPortfolio.Models;
using Microsoft.AspNetCore.Mvc;

namespace JohnPortfolio.Controllers
{
    public class TaxController : Controller
    {
        private readonly ITaxCalculatorService _taxCalculatorService;

        public TaxController(ITaxCalculatorService taxCalculatorService)
        {
            _taxCalculatorService = taxCalculatorService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TaxCalculation model)
        {
            if (ModelState.IsValid)
            {
                // Step 1: Calculate Gross Monthly Income
                decimal grossMonthlyIncome = model.MonthlyBasic + model.HousingAllowance + model.TransportAllowance + model.OtherAllowance;

                // Step 2: Calculate Gross Annual Income
                decimal grossAnnualIncome = grossMonthlyIncome * 12;

                // Step 3: Calculate Pension (8% default or custom)
                decimal annualPension = (model.PensionRate / 100) * grossAnnualIncome;

                // Step 4: Adjusted Annual Income after Pension Deduction
                decimal adjustedAnnualIncome = grossAnnualIncome - annualPension;

                // Step 5: Calculate CRA (Consolidated Relief Allowance)
                decimal cra = Math.Max(200000, adjustedAnnualIncome * 0.01m) + (adjustedAnnualIncome * 0.2m);

                // Step 6: Calculate Taxable Income
                decimal taxableIncome = adjustedAnnualIncome - cra;

                // Prepare result to be displayed in the view
                model.TaxAmount = Math.Ceiling(_taxCalculatorService.CalculateTax(taxableIncome) / 12 * 100) / 100;
            }

            return View(model);
        }
    }
}
