using Microsoft.AspNetCore.Mvc;
using MVCFinalProject.Services.Implementations;
using MVCFinalProject.Services.Interfaces;

namespace MVCFinalProject.Controllers
{
    public class TaxController : Controller
    {
        private readonly ITaxCalculator _taxCalculator;
        public TaxController(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        [HttpGet]
        public IActionResult Calculate() => View();

        [HttpPost]
        public IActionResult Calculate(decimal annualIncome)
        {
            //var calculator = new TaxCalculator();
            //decimal tax = calculator.CalculateTax(annualIncome);
            decimal tax = _taxCalculator.CalculateTax(annualIncome);
            ViewBag.Tax = tax;
            ViewBag.Income = annualIncome;
            return View();
        }
    }

}
