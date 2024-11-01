namespace JohnPortfolio.Models
{
    public class CreateCarDTO
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public IFormFile ImageFile { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public int Year { get; set; }
    }
}
