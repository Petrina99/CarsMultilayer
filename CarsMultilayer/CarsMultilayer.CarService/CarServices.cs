using CarsMultilayer.CarService.Common;
using CarsMultilayer.Model;
using CarsMultilayer.CarsRepository.Common;
using CarsMultilayer.Common;

namespace CarsMultilayer.CarService
{
    public class CarServices : ICarService
    {
        private readonly ICarsRepository _carsRepository;

        public CarServices(ICarsRepository carsRepository) 
        { 
            _carsRepository = carsRepository;
        }

        public async Task<List<Car>> GetCarsAsync(CarFilter filter, Paging paging, Sorting sorting)
        {
            List<Car> carResult = await _carsRepository.GetCarsAsync(filter, paging, sorting);
            
            return carResult;
        }

        public async Task<Car> CreateCarAsync(Car newCar) 
        {
            Car carResult = await _carsRepository.CreateCarAsync(newCar);

            return carResult;
        }

        public async Task<bool> DeleteCarAsync(int carId)
        {
            bool deleteResult = await _carsRepository.DeleteCarAsync(carId);

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

            if (carId != null)
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
            Car result = await _carsRepository.GetCarAsync(carId);
            return result;
        }

        public async Task<List<CarMakeModelJoin>> GetCarsDetailedAsync()
        {
            List<CarMakeModelJoin> result = await _carsRepository.GetCarsDetailedAsync();
            return result;
        }

        public async Task<CarMakeModelJoin> GetCarDetailedAsync(int carId)
        {
            CarMakeModelJoin result = await _carsRepository.GetCarDetailedAsync(carId);
            return result;
        }
    }
}
