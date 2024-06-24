using CarsMultilayer.CarService.Common;
using CarsMultilayer.Model;
using CarsMultilayer.CarsRepository.Common;
using CarsMultilayer.Common;
using System.Reflection;
using CarsMultilayer.CarMakeRepository.Common;

namespace CarsMultilayer.CarService
{
    public class CarServices : ICarService
    {
        private readonly ICarsRepository _carsRepository;
        private readonly ICarMakeRepository _carMakeRepository;

        public CarServices(ICarsRepository carsRepository, ICarMakeRepository carMakeRepository) 
        { 
            _carsRepository = carsRepository;
            _carMakeRepository = carMakeRepository;
        }

        public async Task<List<CarMake>> GetCarMakesAsync()
        {
            List<CarMake> result = await _carMakeRepository.GetAllCarMakeAsync();

            return result;
        }

        public async Task<List<Car>> GetCarsAsync(CarFilter filter, Paging paging, Sorting sorting)
        {
            List<Car> carResult = await _carsRepository.GetCarsAsync(filter, paging, sorting);

            foreach (Car car in carResult) 
            {
                car.CarMake = await _carMakeRepository.GetCarMakeAsync((int)car.CarMakeId);
            }
            
            return carResult;
        }

        public async Task<Car> CreateCarAsync(Car newCar) 
        {
            Car carResult = await _carsRepository.CreateCarAsync(newCar);

            return carResult;
        }

        public async Task<bool> DeleteCarAsync(int carId)
        {
            bool deleteResult = false;

            if (carId != null) 
            { 
                deleteResult = await _carsRepository.DeleteCarAsync(carId);
            }

            if (deleteResult) 
            {
                return true;
            } else
            {
                return false;
            }
        }

        public async Task<Car> UpdateCarAsync(int carId, Car updatedCar)
        {
            Car result = new Car();

            Car doesExist = await _carsRepository.GetCarAsync(carId);

            if (doesExist != null) 
            {
                result = await _carsRepository.UpdateCarAsync(carId, updatedCar);
            }
            
            if (result != null) 
            {
                return result;
            } else
            {
                return null;
            }
        }

        public async Task<Car> GetCarAsync(int carId) 
        {
            Car result = new Car();

            if (carId != null)
            {
                result = await _carsRepository.GetCarAsync(carId);
            }

            return result;
        }

        public async Task<List<CarMakeModelJoin>> GetCarsDetailedAsync()
        {
            List<CarMakeModelJoin> result = await _carsRepository.GetCarsDetailedAsync();
            return result;
        }

        public async Task<CarMakeModelJoin> GetCarDetailedAsync(int carId)
        {
            CarMakeModelJoin result = new CarMakeModelJoin();

            if (carId != null)
            {
                result = await _carsRepository.GetCarDetailedAsync(carId);
            }

            return result;
        }
    }
}
