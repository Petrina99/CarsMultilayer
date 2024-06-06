using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarsMultilayer.Model;
using Npgsql;
using CarsMultilayer.Common;
using CarsMultilayer.CarService.Common;

namespace CarsMultilayer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarsAsync
            (
                int? carMakeId = null, string? carModel = null,
                int? yearOfCar = null, int? minMiles = null, int? maxMiles = null,
                int? minHp = null, int? maxHp = null, decimal? minPrice = null, 
                decimal? maxPrice = null, DateTime? dateStart = null, 
                DateTime? dateEnd = null, int pageSize = 3, int pageNumber = 1, 
                string orderBy = "Price", string sortOrder = "ASC"
            )
        {
            CarFilter filter = new CarFilter(
                carMakeId, carModel, yearOfCar, minMiles, maxMiles,
                minHp, maxHp, minPrice, maxPrice, dateStart, dateEnd
            );
            Paging paging = new Paging(pageSize, pageNumber);
            Sorting sorting = new Sorting(orderBy, sortOrder);
            
            List<Car> carResult = await _carService.GetCarsAsync(filter, paging, sorting);

            if (carResult == null)
            {
                return NotFound("Cars not found");
            }
            else
            {
                return Ok(carResult);
            }
        }

        [HttpGet("/Car/{id}")]
        public async Task<IActionResult> GetCarAsync(int id)
        {
            Car carResult = await _carService.GetCarAsync(id);

            if (carResult == null)
            {
                return BadRequest($"Car with id {id} not found");
            }
            else
            {
                return Ok(carResult);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarAsync([FromBody] Car newCar)
        {
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
        public async Task<IActionResult> UpdateCarAsync(int id, [FromBody] Car updatedCar)
        {
            Car result = await _carService.UpdateCarAsync(id, updatedCar);

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
