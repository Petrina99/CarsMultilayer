using CarsMultilayer.CarService.Common;
using CarsMultilayer.Model;
using CarsMultilayer.CarsRepository;
using CarsMultilayer.CarsRepository.Common;

namespace CarsMultilayer.CarService
{
    public class CarServiceClass : ICarService
    {
        public List<Car> GetCars()
        {
            ICarsRepository carRepository = new CarsRepositoryClass();
            List<Car> carResult = carRepository.GetCars();
            
            return carResult;
        }
    }
}
