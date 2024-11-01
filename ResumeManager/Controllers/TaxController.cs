using Microsoft.AspNetCore.Mvc;
using ResumeManager.Implementation;
using ResumeManager.Models;

namespace ResumeManager.Controllers
{
    public class TaxController : Controller
    {
        private readonly TaxService _taxService;

        public TaxController(TaxService taxService)
        {
            _taxService = taxService;
        }

        [HttpPost]
        public async Task<IActionResult> CalculatePAYE(Anthonia_PAYEDto model)
        {
            var result = await _taxService.CalculatePAYEAsync(model);
            if (result == null)
            {
                ModelState.AddModelError("", "Calculation failed.");
                return View(model);
            }

            return View(result);
        }
    }
}
