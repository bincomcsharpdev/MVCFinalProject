using Microsoft.EntityFrameworkCore;
using ProjectAPIs.Model;

namespace ProjectAPIs.Data
{
    public class PortfolioContext : DbContext 
    {
        public PortfolioContext(DbContextOptions<PortfolioContext>option) : base(option)
        {
            
        }

        public DbSet<Project> Ken_Projects { get; set; }
        public DbSet<Gallery> Ken_Galleries { get; set; }
        public DbSet<Profile> Ken_Profiles { get; set; }
    }
}
