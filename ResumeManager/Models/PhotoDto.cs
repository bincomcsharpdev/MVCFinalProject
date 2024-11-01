namespace ResumeManager.Models
{
    public class PhotoDto
    {
        public int Id { get; set; }   
        public string? Title { get; set; }     
        public string? Description { get; set; } 
        public string? ImageMimeType { get; set; } 
        public byte[]? ImageData { get; set; }
    }
}
