using Microsoft.AspNetCore.Identity;

namespace MVCFinalProject.Models.Entities
{
    public class YahyaUser : IdentityUser<Guid>  
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        public ICollection<YahyaPortfolioItem>? PortfolioItems { get; set; }
    }
}
