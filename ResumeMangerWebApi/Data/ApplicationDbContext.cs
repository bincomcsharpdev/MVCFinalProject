using Microsoft.EntityFrameworkCore;
using ResumeMangerWebApi.Entities;

namespace ResumeMangerWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Anthonia_Photoh> Anthonia_Photohs { get; set; }
        public DbSet<Anthonia_User> Anthonia_Users { get; set; }
    }
}
