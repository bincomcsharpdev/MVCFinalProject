using System.ComponentModel.DataAnnotations;

namespace ResumeMangerWebApi.Model
{
    public class PhotoUpload
    {
        [Required(ErrorMessage = "File is required.")]
        public IFormFile File { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }
    }
}
