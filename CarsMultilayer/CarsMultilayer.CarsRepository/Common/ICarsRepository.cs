using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsMultilayer.Common;
using CarsMultilayer.Model;

namespace CarsMultilayer.CarsRepository.Common
{
    public interface ICarsRepository
    {
        public Task<List<Car>> GetCarsAsync(CarFilter filter, Paging paging, Sorting sorting);
        public Task<Car> CreateCarAsync(Car car);
        public Task<bool> DeleteCarAsync(int carId);
        public Task<Car> UpdateCarAsync(int carId, Car updatedCar);
        public Task<Car> GetCarAsync(int carId);
        public Task<List<CarMakeModelJoin>> GetCarsDetailedAsync();
        public Task<CarMakeModelJoin> GetCarDetailedAsync(int carId);
    }
}
