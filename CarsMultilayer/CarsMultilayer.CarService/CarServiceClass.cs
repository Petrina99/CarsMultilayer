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

        public async Task<List<Car>> GetCarsAsync()
        {
            List<Car> carResult = await CarsRepository.GetCarsAsync();
            
            return carResult;
        }

        public async Task<Car> CreateCarAsync(Car newCar) 
        {
            Car carResult = await CarsRepository.CreateCarAsync(newCar);

            return carResult;
        }

        public async Task<bool> DeleteCarAsync(int carId)
        {
            bool deleteResult = await CarsRepository.DeleteCarAsync(carId);

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
            Car result = await CarsRepository.UpdateCarAsync(carId, updatedCar);

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
            Car result = await CarsRepository.GetCarAsync(carId);
            return result;
        }

        public async Task<List<CarMakeModelJoin>> GetCarsDetailedAsync()
        {
            List<CarMakeModelJoin> result = await CarsRepository.GetCarsDetailedAsync();
            return result;
        }

        public async Task<CarMakeModelJoin> GetCarDetailedAsync(int carId)
        {
            CarMakeModelJoin result = await CarsRepository.GetCarDetailedAsync(carId);
            return result;
        }
    }
}
