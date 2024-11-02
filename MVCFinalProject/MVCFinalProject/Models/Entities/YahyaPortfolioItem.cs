namespace MVCFinalProject.Models.Entities
{
    public class YahyaPortfolioItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? FilePath { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public Guid UserId { get; set; }
        public YahyaUser? User { get; set; }  
    }
}
