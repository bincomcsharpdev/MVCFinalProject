using Microsoft.EntityFrameworkCore;
using ResumeMangerWebApi.Entities;

namespace ResumeMangerWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Anthonia_Photo> Anthonia_Photos { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
