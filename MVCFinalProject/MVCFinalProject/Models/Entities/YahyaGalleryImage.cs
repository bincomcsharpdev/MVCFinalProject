namespace MVCFinalProject.Models.Entities
{
    public class YahyaGalleryImage
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;

        public Guid UserId { get; set; }
        public YahyaUser? User { get; set; }
    }
}
