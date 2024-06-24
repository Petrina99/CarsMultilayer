using Microsoft.AspNetCore.Mvc;
using CarsMultilayer.Model;
using CarsMultilayer.Common;
using CarsMultilayer.CarService.Common;
using AutoMapper;
using CarsMultilayer.WebApi.Models;
using System.Reflection;

namespace CarsMultilayer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public ICarService _carService;
        private readonly IMapper _mapper;

        public CarController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet("GetAllCarMakes")]

        public async Task<IActionResult> GetCarMakesAsync()
        {
            List<CarMake> result = await _carService.GetCarMakesAsync();

            if (result == null)
            {
                return NotFound("Car makes not found");
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpGet("GetAllCars")]
        public async Task<IActionResult> GetCarsAsync
            (
                int? carMakeId = null, string? carModel = null,
                int? yearOfCar = null, int? minMiles = null, int? maxMiles = null,
                int? minHp = null, int? maxHp = null, decimal? minPrice = null, 
                decimal? maxPrice = null, DateTime? dateStart = null, 
                DateTime? dateEnd = null, int? pageSize = 20, int? pageNumber = 1, 
                string orderBy = "Price", string sortOrder = "ASC"
            )
        {
            CarFilter filter = new CarFilter(
                carMakeId, carModel, yearOfCar, minMiles, maxMiles,
                minHp, maxHp, minPrice, maxPrice, dateStart, dateEnd
            );
            Paging paging = new Paging((int)pageSize, (int)pageNumber);
            Sorting sorting = new Sorting(orderBy, sortOrder);
            
            List<Car> carResult = await _carService.GetCarsAsync(filter, paging, sorting);

            List<CarGetRest> carRest = new List<CarGetRest>();

            _mapper.Map(carResult, carRest);

            if (carRest == null)
            {
                return NotFound("Cars not found");
            }
            else
            {
                return Ok(carRest);
            }
        }

        [HttpGet("/Car/{id}")]
        public async Task<IActionResult> GetCarAsync(int id)
        {
            Car carResult = await _carService.GetCarAsync(id);
            CarGetRest carRest = new CarGetRest();

            _mapper.Map(carResult, carRest);
            if (carRest == null)
            {
                return BadRequest($"Car with id {id} not found");
            }
            else
            {
                return Ok(carRest);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarAsync([FromBody] CarPostRest postCar)
        {
            Car newCar = new Car();
            _mapper.Map(postCar, newCar);

            Car carResult = await _carService.CreateCarAsync(newCar);
            
            if (carResult == null)
            {
                return BadRequest("Error adding a car");
            }
            else
            {
                return Ok(newCar);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCarAsync(int id)
        {
            bool result = await _carService.DeleteCarAsync(id);
            if (result) 
            {
                return Ok($"Car with id {id} deleted succesfully");
            } else
            {
                return BadRequest($"Unable to delete car with id {id}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarAsync(
            int id, int? carMakeId = null, string? carModel = null, int? hp = null,
            int? yearOfCar = null, int? mileage = null, decimal? price = null
            )
        {
            CarUpdateRest updatedCar = new CarUpdateRest(carMakeId, carModel, hp, yearOfCar, mileage, price);
            Car updateCar = new Car();
            
            _mapper.Map(updatedCar, updateCar);

            Car result = await _carService.UpdateCarAsync(id, updateCar);

            if (result != null)
            {
                return Ok($"Car with id {id} updated succesfully");
            } else
            {
                return BadRequest($"Unable to delete car with id {id}");
            }
        }
        
        
        [HttpGet("/Car/Detailed")]
        public async Task<IActionResult> GetCarsDetailedAsync()
        {
            List<CarMakeModelJoin> result = await _carService.GetCarsDetailedAsync();

            if (result == null)
            {
                return BadRequest("No cars found");
            } else
            {
                return Ok(result);
            }
        }

        [HttpGet("/Car/Detailed/{id}")]
        public async Task<IActionResult> GetCarDetailedAsync(int id)
        {
            CarMakeModelJoin result = await _carService.GetCarDetailedAsync(id);

            if (result == null)
            {
                return BadRequest($"No car with id {id} found");
            }
            else
            {
                return Ok(result);
            }

        }
    }

}
