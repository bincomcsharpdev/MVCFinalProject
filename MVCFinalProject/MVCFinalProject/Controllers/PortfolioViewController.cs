using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCFinalProject.Models.DTOs;
using MVCFinalProject.Services.Interfaces;
using System.Security.Claims;

namespace MVCFinalProject.Controllers
{
    //[Authorize]
    public class PortfolioViewController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioViewController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<IActionResult> Index()
        {
            var portfolioItems = await _portfolioService.GetAllPortfolioItemsAsync();
            return View(portfolioItems);
        }

        public IActionResult Create()
        {
            return View("Edit", new PortfolioItemDto());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(PortfolioItemDto portfolioItemDto, IFormFile file)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["ErrorMessage"] = "Please correct the errors and try again.";
                    return View("_PortfolioForm", portfolioItemDto);
                }

                var userId = GetUserId(); 
                if (userId == null)
                {
                    TempData["ErrorMessage"] = "You must be logged in to create a portfolio item.";
                    return RedirectToAction("Login", "Account"); 
                }

                var success = await _portfolioService.SavePortfolioItemAsync(portfolioItemDto, userId, file);
                TempData["SuccessMessage"] = success ? "Portfolio item saved successfully." : "Failed to save portfolio item.";
                return RedirectToAction("Index"); 
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
            }
            return View("_PortfolioForm", portfolioItemDto);
        }




        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var portfolioItem = await _portfolioService.GetPortfolioItemByIdAsync(id);
            if (portfolioItem == null)
            {
                TempData["ErrorMessage"] = "Portfolio item not found.";
                return RedirectToAction("Index");
            }
            return View("Edit", portfolioItem); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, PortfolioItemDto portfolioItemDto, IFormFile? file)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Please correct the errors and try again.";
                return View("Edit", portfolioItemDto); 
            }

            await _portfolioService.UpdatePortfolioItemAsync(id, portfolioItemDto, file);
            TempData["SuccessMessage"] = "Portfolio item updated successfully.";
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var portfolioItem = await _portfolioService.GetPortfolioItemByIdAsync(id);
            if (portfolioItem == null)
            {
                TempData["ErrorMessage"] = "Portfolio item not found.";
                return RedirectToAction(nameof(Index));
            }

            return View(portfolioItem);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                bool success = await _portfolioService.DeletePortfolioItemAsync(id);
                TempData["SuccessMessage"] = success ? "Portfolio item deleted successfully." : "Failed to delete portfolio item.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }





        private Guid GetUserId()
        {
            //return Guid.Parse(User.Claims.First(c => c.Type == "sub").Value);
            return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new UnauthorizedAccessException("User not logged in"));
        }

    }
}
