using CarsMultilayer.CarService.Common;
using CarsMultilayer.Model;
using CarsMultilayer.CarsRepository;
using CarsMultilayer.CarsRepository.Common;

namespace CarsMultilayer.CarService
{
    public class CarServiceClass : ICarService
    {
        public ICarsRepository CarsRepository = new CarsRepositoryClass();

        public CarServiceClass() { }

        public List<Car> GetCars()
        {
            List<Car> carResult = CarsRepository.GetCars();
            
            return carResult;
        }

        public Car CreateCar(Car newCar) 
        {
            Car carResult = CarsRepository.CreateCar(newCar);

            return carResult;
        }
    }
}
