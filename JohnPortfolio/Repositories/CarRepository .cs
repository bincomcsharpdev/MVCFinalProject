using JohnPortfolio.Data;
using JohnPortfolio.Interfaces;
using JohnPortfolio.Models;

namespace JohnPortfolio.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly BincomDb _dbConn;

        public CarRepository(BincomDb dbConn)
        {
            _dbConn = dbConn;
        }

        public IEnumerable<JohnCar> GetAllCars()
        {
            return _dbConn.JohnCars.AsEnumerable();
        }

        public async Task AddCarAsync(JohnCar car)
        {
            _dbConn.JohnCars.Add(car);
            await _dbConn.SaveChangesAsync();
        }
    }
}
