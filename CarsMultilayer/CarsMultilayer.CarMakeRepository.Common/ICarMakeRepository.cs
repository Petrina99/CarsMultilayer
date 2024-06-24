using CarsMultilayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsMultilayer.CarMakeRepository.Common
{
    public interface ICarMakeRepository
    {
        public Task<CarMake> GetCarMakeAsync(int id);
        public Task<List<CarMake>> GetAllCarMakeAsync();
    }
}
