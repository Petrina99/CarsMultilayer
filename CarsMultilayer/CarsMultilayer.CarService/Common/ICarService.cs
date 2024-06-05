using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsMultilayer.Model;

namespace CarsMultilayer.CarService.Common
{
    public interface ICarService
    {
        public Task<List<Car>> GetCarsAsync();
        public Task<Car> CreateCarAsync(Car newCar);
        public Task<bool> DeleteCarAsync(int carId);
        public Task<Car> UpdateCarAsync(int carId, Car updatedCar);
        public Task<Car> GetCarAsync(int carId);
        public Task<List<CarMakeModelJoin>> GetCarsDetailedAsync();
        public Task<CarMakeModelJoin> GetCarDetailedAsync(int carId);
    }
}
