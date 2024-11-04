using FinalAssProject.Data;
using FinalAssProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalAssProject.Controllers
{
    public class AboutMeController : Controller
    {
        private readonly AppDbContext _context;

        public AboutMeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Display the user's bio if it exists
            var aboutMe = await _context.Ken_AboutMe.FirstOrDefaultAsync();
            return View(aboutMe);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(AboutMe aboutMe)
        {
            if (ModelState.IsValid)
            {
                // Add or update bio
                var existingBio = await _context.Ken_AboutMe.FirstOrDefaultAsync();
                if (existingBio != null)
                {
                    existingBio.FullName = aboutMe.FullName;
                    existingBio.Bio = aboutMe.Bio;
                }
                else
                {
                    await _context.Ken_AboutMe.AddAsync(aboutMe);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View("Edit", aboutMe);
        }
    }
}
