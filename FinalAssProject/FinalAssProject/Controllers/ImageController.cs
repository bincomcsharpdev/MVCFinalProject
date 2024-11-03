using FinalAssProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalAssProject.Controllers
{
    public class ImageController : Controller
    {
        private readonly IGalleryService _galleryService;

        public ImageController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var galleryItems = await _galleryService.GetAllImageItemsAsync();
            return View(galleryItems);
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile imageFile, string title, string description)
        {
            if (ModelState.IsValid)
            {
                await _galleryService.UploadImageAsync(imageFile, title, description);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var image = await _galleryService.DeleteImage(id);
            if(image)
                return RedirectToAction("Index");
            return NotFound();

        }
    }
}
