namespace MVCFinalProject.Models.Entities
{
    public class YahyContactMessage
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = default!;
        public string Subject { get; set; } = default!;
        public string Message { get; set; } = default!;
        public DateTime SentAt { get; set; } = DateTime.UtcNow;

    }
}
