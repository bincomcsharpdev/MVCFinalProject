//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using ProjectAPIs.Data;
//using ProjectAPIs.Dtos;
//using ProjectAPIs.Interfaces;
//using ProjectAPIs.Model;

//namespace ProjectAPIs.Controller
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class GalleryController : ControllerBase
//    {
//        private readonly IGalleryService _gallery;
//        private readonly PortfolioContext _portfolioContext;

//        public GalleryController(IGalleryService gallery)
//        {
//            _gallery = gallery;
//        }

//        [HttpPost("uploadPhoto")]
//        public async Task<IActionResult> UploadPhoto([FromForm] UploadPhoto file, string title, string description)
//        {
//            if(file != null && file.File.Length > 0)
//            {
//                using (var streamMemory = new MemoryStream())
//                {
//                    await file.File.CopyToAsync(streamMemory);

//                    var photo = new Gallery
//                    {
//                         = title,
//                        Description = description,
//                        ImageMimeType = file.ContentType,
//                        ImageData = streamMemory.ToArray()
//                    };

//                    var addedPhoto = await _gallery.AddPhotos(photo);
//                    return CreatedAtAction(nameof(GetPhoto), new { id = addedPhoto.Id }, addedPhoto);
//                }
//            }
//            return BadRequest("No upload file.");
            
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetPhoto(int id)
//        {
//            var photo = await _gallery.GetPhoto(id);
//            if (photo == null)
//                return NotFound();

//            return File(photo.ImageData, photo.ImageMimeType);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeletePhoto(int id)
//        {
//            var deletePhoto = await _gallery.DeletePhoto(id);
//            if(!deletePhoto)
//                return NotFound();
//            return NoContent();

//        }
//    }
//}
