using AutoMapper;
using CarsMultilayer.Model;

namespace CarsMultilayer.WebApi.Models
{
    public class CarMappingProfile : Profile
    {
        public CarMappingProfile() 
        {
            CreateMap<Car, CarGetRest>();
            CreateMap<CarPostRest, Car>();
            CreateMap<CarUpdateRest, Car>();
        }
    }
}
