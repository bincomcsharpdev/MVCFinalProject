using FinalAssProject.Data;
using FinalAssProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalAssProject.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _context;

        public PortfolioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var projects = _context.Ken_Portolios.ToList();
            return View(projects);
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile imageFile, IFormFile documentFile, string title, string description)
        {
            var project = new PortfolioItem
            {
                Title = title,
                Description = description,
                ImageMimeType = imageFile?.ContentType,
                DocumentMimeType = documentFile?.ContentType
            };

            if (imageFile != null)
            {
                using var ms = new MemoryStream();
                imageFile.CopyTo(ms);
                project.ImageData = ms.ToArray();
            }

            if (documentFile != null)
            {
                using var ms = new MemoryStream();
                documentFile.CopyTo(ms);
                project.DocumentData = ms.ToArray();
            }

            _context.Ken_Portolios.Add(project);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
