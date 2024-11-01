using Microsoft.AspNetCore.Mvc;
using ResumeMangerWebApi.Entities;
using ResumeMangerWebApi.Implementation.Interfaces;
using ResumeMangerWebApi.DTO;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PhotoController : ControllerBase
{
    private readonly IPhotoService _photoService;

    public PhotoController(IPhotoService photoService)
    {
        _photoService = photoService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadPhoto([FromForm] PhotoUploadDto upload)
    {
        if (upload.File == null || upload.File.Length == 0)
        {
            return BadRequest("Invalid file.");
        }

        await _photoService.UploadPhoto(upload);
        return Ok(new { Message = "Photo uploaded successfully." });
    }

    [HttpPut("update_photo/{id}")]
    public async Task<IActionResult> UpdatePhotoDetails(int id, [FromBody] Anthonia_Photo updatePhoto)
    {
        var photo = await _photoService.GetPhotoById(id);
        if (photo == null)
        {
            return NotFound("Photo not found");
        }

        await _photoService.UpdatePhoto(id, updatePhoto);
        return Ok(new { Message = "Photo updated Successfully." });
    }

    [HttpDelete("delete_photo/{id}")]
    public async Task<IActionResult> DeletePhoto(int id)
    {
        var photo = await _photoService.GetPhotoById(id);
        if (photo == null)
        {
            return NotFound("Photo not found.");
        }
        await _photoService.DeletePhoto(id);
        return Ok(new { Message = "Photo deleted successfully." });
    }

    [HttpGet("view_details/{id}")]
    public async Task<IActionResult> GetPhotoDetails(int id)
    {
        var photo = await _photoService.GetPhotoById(id);
        if (photo == null)
        {
            return NotFound("Photo not found.");
        }

        return Ok(photo);
    }

    [HttpGet("gallery")]
    public async Task<IActionResult> GetAllPhotos(int page = 1, int pageSize = 10)
    {
        var photos = await _photoService.GetAllPhotos(page, pageSize);
        return Ok(photos);
    }

    [HttpGet("view_photo/image/{id}")]
    public async Task<IActionResult> GetImage(int id)
    {
        var photo = await _photoService.GetPhotoById(id);
        if(photo != null)
        {
            return File(photo.ImageData, photo.ImageMimeType);
        }
        return NotFound("Image not found");
    }

}
