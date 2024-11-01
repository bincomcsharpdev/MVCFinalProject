using JohnPortfolio.Models;

namespace JohnPortfolio.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<JohnCar> GetAllCars();
        Task AddCarAsync(JohnCar car);
    }
}
