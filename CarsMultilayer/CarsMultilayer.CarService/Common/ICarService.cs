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
        public List<Car> GetCars();
        public Car CreateCar(Car newCar);
        public bool DeleteCar(int carId);
        public Car UpdateCar(int carId, Car updatedCar);
        public Car GetCar(int carId);
        public List<CarMakeModelJoin> GetCarsDetailed();
        public CarMakeModelJoin GetCarDetailed(int carId);
    }
}
