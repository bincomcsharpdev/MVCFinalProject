namespace FinalAssProject.Models
{
    public class PortfolioItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageMimeType { get; set; }
        public byte[]? DocumentData { get; set; }
        public string? DocumentMimeType { get; set; }
    }
}
