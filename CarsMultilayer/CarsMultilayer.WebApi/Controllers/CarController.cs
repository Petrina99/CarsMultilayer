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
        /*
        [HttpGet("/Car/{id}")]
        public IActionResult GetCar(int id)
        {
            string connString = Configuration.GetConnectionString("db");
            using var conn = new NpgsqlConnection(connString);

            conn.Open();
            using var cmd = new NpgsqlCommand(connString, conn);

            cmd.CommandText = "SELECT * FROM \"Car\" WHERE \"Id\" = @id";

            cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, id);
            using var reader = cmd.ExecuteReader();

            Car fetchedCar = new Car();
            while (reader.Read())
            {
                try
                {
                    fetchedCar.Id = (int)reader[0];
                    fetchedCar.CarMakeId = (int)reader["CarMakeId"];
                    fetchedCar.CarModel = reader[1].ToString();
                    fetchedCar.YearOfMake = (int)reader[2];
                    fetchedCar.Mileage = (int)reader[3];
                    fetchedCar.Horsepower = (int)reader[4];
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            conn.Close();

            if (fetchedCar == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(fetchedCar);
            }
        }

        [HttpGet("/Car/Detailed")]
        public IActionResult GetCarAndMake()
        {
            string connString = this.Configuration.GetConnectionString("db");
            using var conn = new NpgsqlConnection(connString);

            conn.Open();

            using var cmd = new NpgsqlCommand(connString, conn);
            cmd.CommandText = $"SELECT * FROM \"Car\" c FULL JOIN \"CarMake\" cm on cm.\"Id\" = c.\"CarMakeId\"";

            using var reader = cmd.ExecuteReader();

            List<CarMakeCarModelJoin> joinResult = new List<CarMakeCarModelJoin>();

            while (reader.Read())
            {
                try
                {
                    CarMakeCarModelJoin join = new CarMakeCarModelJoin();
                    join.CarId = (int)reader[0];
                    join.CarModel = (string)reader[1];
                    join.YearOfMake = (int)reader[2];
                    join.Mileage = (int)reader[3];
                    join.Horsepower = (int)reader[4];
                    join.MakeId = (int)reader[7];
                    join.MakeName = (string)reader[8];
                    join.MakeCountry = (string)reader[9];

                    joinResult.Add(join);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            conn.Close();

            if (joinResult.Count > 0)
            {
                return Ok(joinResult);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("/Car/Detailed/{id}")]
        public IActionResult GetCarDetailed(int id)
        {
            string connString = Configuration.GetConnectionString("db");
            using var conn = new NpgsqlConnection(connString);

            conn.Open();
            using var cmd = new NpgsqlCommand(connString, conn);

            cmd.CommandText = "SELECT * FROM \"Car\" c FULL JOIN \"CarMake\" cm on cm.\"Id\" = c.\"CarMakeId\" where c.\"Id\" = @id";

            cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, id);
            using var reader = cmd.ExecuteReader();

            CarMakeCarModelJoin joinResult = new CarMakeCarModelJoin();

            while (reader.Read())
            {
                try
                {
                    joinResult.CarId = (int)reader[0];
                    joinResult.CarModel = (string)reader[1];
                    joinResult.YearOfMake = (int)reader[2];
                    joinResult.Mileage = (int)reader[3];
                    joinResult.Horsepower = (int)reader[4];
                    joinResult.MakeId = (int)reader[7];
                    joinResult.MakeName = (string)reader[8];
                    joinResult.MakeCountry = (string)reader[9];
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            if (joinResult == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(joinResult);
            }
        }

        

        

        
         */
    }

}
