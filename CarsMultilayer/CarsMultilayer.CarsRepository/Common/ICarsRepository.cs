using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsMultilayer.Model;
namespace CarsMultilayer.CarsRepository.Common
{
    public interface ICarsRepository
    {
        public List<Car> GetCars();
        public Car CreateCar(Car car);
        public bool DeleteCar(int carId);
        public Car UpdateCar(int carId, Car updatedCar);
        public Car GetCar(int carId);
        public List<CarMakeModelJoin> GetCarsDetailed();
        public CarMakeModelJoin GetCarDetailed(int carId);
    }
}
