using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Models.Entities;

namespace MVCFinalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<YahyaUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

        public DbSet<YahyaPortfolioItem> YahyaPortfolioItems { get; set; }
        public DbSet<YahyContactMessage> YahyContactMessages { get; set; }

        
    }

   
  
}
