using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CarsMultilayer.Model;
using CarsMultilayer.CarService;
using Npgsql;

namespace CarsMultilayer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public CarServiceClass CarService = new CarServiceClass();

        [HttpGet]
        public IActionResult GetCars()
        {
            List<Car> carResult = CarService.GetCars();

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
        public IActionResult GetCar(int id)
        {
            Car carResult = CarService.GetCar(id);

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
        public IActionResult CreateCar([FromBody] Car newCar)
        {
            Car carResult = CarService.CreateCar(newCar);
            
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
        public IActionResult DeleteCar(int id)
        {
            bool result = CarService.DeleteCar(id);
            if (result) 
            {
                return Ok($"Car with id {id} deleted succesfully");
            } else
            {
                return BadRequest($"Unable to delete car with id {id}");
            }
        }

        [HttpPut]
        public IActionResult UpdateCar(int id, [FromBody] Car updatedCar)
        {
            Car result = CarService.UpdateCar(id, updatedCar);

            if (result != null)
            {
                return Ok($"Car with id {id} updated succesfully");
            } else
            {
                return BadRequest($"Unable to delete car with id {id}");
            }
        }
        
        
        [HttpGet("/Car/Detailed")]
        public IActionResult GetCarAndMake()
        {
            List<CarMakeModelJoin> result = CarService.GetCarsDetailed();

            if (result == null)
            {
                return BadRequest("No cars found");
            } else
            {
                return Ok(result);
            }
        }

        [HttpGet("/Car/Detailed/{id}")]
        public IActionResult GetCarDetailed(int id)
        {
            CarMakeModelJoin result = CarService.GetCarDetailed(id);

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
