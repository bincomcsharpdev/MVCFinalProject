using Microsoft.EntityFrameworkCore;
using JohnPortfolio.Models;

namespace JohnPortfolio.Data
{
    public class BincomDb : DbContext
    {
        public BincomDb(DbContextOptions<BincomDb> options) : base(options)
        {
        }


        public DbSet<Car> Cars { get; set; }
        public DbSet<JohnCar> JohnCars { get; set; }
    }
}
