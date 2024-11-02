using System.ComponentModel.DataAnnotations;

namespace MVCFinalProject.Models.DTOs
{
   
    public class PortfolioItemDto
    {
        public Guid Id { get; set; }  

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public Guid UserId { get; set; }


        [Required]
        public DateTime DateCreated { get; set; }

        public string FilePath { get; set; } = string.Empty;


    }
}
