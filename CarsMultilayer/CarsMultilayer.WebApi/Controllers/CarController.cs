using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CarsMultilayer.Model;
using CarsMultilayer.CarService;
using Npgsql;
using CarsMultilayer.Common;

namespace CarsMultilayer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public CarServiceClass CarService = new CarServiceClass();

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
            Console.WriteLine(yearOfCar);
            CarFilter filter = new CarFilter(
                carMakeId, carModel, yearOfCar, minMiles, maxMiles,
                minHp, maxHp, minPrice, maxPrice, dateStart, dateEnd
            );
            Paging paging = new Paging(pageSize, pageNumber);
            Sorting sorting = new Sorting(orderBy, sortOrder);
            
            List<Car> carResult = await CarService.GetCarsAsync(filter, paging, sorting);

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
            Car carResult = await CarService.GetCarAsync(id);

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
            Car carResult = await CarService.CreateCarAsync(newCar);
            
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
            bool result = await CarService.DeleteCarAsync(id);
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
            Car result = await CarService.UpdateCarAsync(id, updatedCar);

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
            List<CarMakeModelJoin> result = await CarService.GetCarsDetailedAsync();

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
            CarMakeModelJoin result = await CarService.GetCarDetailedAsync(id);

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
