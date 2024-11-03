using System.ComponentModel.DataAnnotations;

namespace ProjectAPIs.Dtos
{
    public class UploadPhoto
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }
        public string? FileDiscription { get; set; }
    }
}
