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
    }
}
