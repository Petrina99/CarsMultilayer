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

        public bool DeleteCar(int carId)
        {
            bool deleteResult = CarsRepository.DeleteCar(carId);

            if (deleteResult) 
            {
                return true;
            } else
            {
                return false;
            }
        }

        public Car UpdateCar(int carId, Car updatedCar)
        {
            Car result = CarsRepository.UpdateCar(carId, updatedCar);

            if (result != null) 
            {
                return result;
            } else
            {
                return null;
            }
        }

        public Car GetCar(int carId) 
        {
            Car result = CarsRepository.GetCar(carId);
            return result;
        }

        public List<CarMakeModelJoin> GetCarsDetailed()
        {
            List<CarMakeModelJoin> result = CarsRepository.GetCarsDetailed();
            return result;
        }

        public CarMakeModelJoin GetCarDetailed(int carId)
        {
            CarMakeModelJoin result = CarsRepository.GetCarDetailed(carId);
            return result;
        }
    }
}
