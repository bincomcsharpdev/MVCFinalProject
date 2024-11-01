using JohnPortfolio.Interfaces;
using JohnPortfolio.Models;
using Microsoft.AspNetCore.Mvc;

namespace JohnPortfolio.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public IActionResult Index()
        {
            var myCars = _carRepository.GetAllCars();
            return View(myCars);
        }

        // GET: Create car with image
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create car with image upload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCarDTO carDto)
        {
            if (ModelState.IsValid)
            {
                byte[] imageData = null;

                if (carDto.ImageFile != null && carDto.ImageFile.Length > 0)
                {
                    // Convert the uploaded image into a byte array
                    using (var memoryStream = new MemoryStream())
                    {
                        await carDto.ImageFile.CopyToAsync(memoryStream);
                        imageData = memoryStream.ToArray();
                    }
                }

                // Create a new car object and save it to the database using the repository
                var car = new JohnCar
                {
                    Manufacturer = carDto.Manufacturer,
                    Model = carDto.Model,
                    ImageData = imageData,
                    DateAdded = carDto.DateAdded,
                    Year = carDto.Year
                };

                await _carRepository.AddCarAsync(car);
                return RedirectToAction(nameof(Index));
            }

            return View(carDto);
        }
    }
}
