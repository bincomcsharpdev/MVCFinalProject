using System.ComponentModel.DataAnnotations;

namespace ResumeMangerWebApi.DTO
{
    public class Anthonia_PAYEDto
    {
        [Required(ErrorMessage = "Annual Income is required.")]
        public decimal Income { get; set; }
        public decimal Tax { get; set; }
    }
}
