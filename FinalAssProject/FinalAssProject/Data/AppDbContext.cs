using FinalAssProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalAssProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>option) : base(option) 
        {
            
        }
        public DbSet<Gallery> Ken_Galleries { get; set; }
    }
}
