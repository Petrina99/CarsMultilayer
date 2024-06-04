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
        /*
        public Car GetCar(int id);
        public List<CarMakeModelJoin> GetCarsDetailed();
        public CarMakeModelJoin GetCarDetailed(int id);
        
        public Car DeleteCar(int id);
        public Car updateCar(int id, Car updatedCar);*/
    }
}
