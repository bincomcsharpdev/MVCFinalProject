using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ResumeManager.Models;

public class PhotoController : Controller
{
    private readonly PhotoService _photoService;

    public PhotoController(PhotoService photoService)
    {
        _photoService = photoService;
    }

    [HttpGet]
    public async Task<IActionResult> Gallery(int page = 1, int pageSize = 10)
    {
        var photos = await _photoService.GetAllPhotosAsync(page, pageSize);
        return View(photos);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var photo = await _photoService.GetPhotoDetailsAsync(id);
        if (photo == null)
            return NotFound("Photo not found.");

        return View(photo);
    }

    [HttpGet]
    public async Task<IActionResult> ViewImage(int id)
    {
        var imageData = await _photoService.GetImageAsync(id);
        if (imageData == null)
            return NotFound("Image not found.");

        return File(imageData, "image/jpeg"); 
    }

    [HttpGet]
    public IActionResult Upload()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Upload(PhotoUploadDto upload)
    {
        if (upload.File == null || upload.File.Length == 0)
        {
            ModelState.AddModelError("", "Please select a valid file.");
            return View(upload);
        }

        var success = await _photoService.UploadPhotoAsync(upload);
        if (!success)
        {
            ModelState.AddModelError("", "Photo upload failed.");
            return View(upload);
        }

        return RedirectToAction("Gallery");
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var photo = await _photoService.GetPhotoDetailsAsync(id);
        if (photo == null)
            return NotFound("Photo not found.");

        return View(photo);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, Anthonia_PhotohDto updatePhoto)
    {
        var success = await _photoService.UpdatePhotoDetailsAsync(id, updatePhoto);
        if (!success)
        {
            ModelState.AddModelError("", "Failed to update photo.");
            return View(updatePhoto);
        }

        return RedirectToAction("Details", new { id });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _photoService.DeletePhotoAsync(id);
        if (!success)
            ModelState.AddModelError("", "Failed to delete photo.");

        return RedirectToAction("Gallery");
    }
}
