namespace ResumeManager.Models
{
    public class PhotoUploadDto
    {
        public IFormFile File { get; set; }  
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
