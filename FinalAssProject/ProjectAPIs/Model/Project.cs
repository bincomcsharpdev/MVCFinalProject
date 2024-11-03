namespace ProjectAPIs.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; } // Stores the path to the uploaded image
        public DateTime CreatedAt { get; set; }
    }
}
