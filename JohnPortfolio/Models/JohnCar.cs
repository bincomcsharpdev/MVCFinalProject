using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JohnPortfolio.Models
{
    public class JohnCar
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; } 
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public byte[] ImageData { get; set; }
        public DateTime DateAdded { get; set; }
        public int Year { get; set; }
    }
}
