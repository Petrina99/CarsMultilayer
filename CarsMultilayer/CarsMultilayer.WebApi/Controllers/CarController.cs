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

        [HttpGet]
        public IActionResult GetCars()
        {
            CarServiceClass carServiceClass = new CarServiceClass();

            List<Car> carResult = carServiceClass.GetCars();

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
            if (commits == 0)
            {
                return BadRequest("Error adding a car");
            }
            else
            {

                return Ok(newCar);
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

        

        [HttpDelete]
        public IActionResult DeleteCar(int id)
        {
            string connString = Configuration.GetConnectionString("db");
            using var conn = new NpgsqlConnection(connString);

            conn.Open();
            using var cmd = new NpgsqlCommand(connString, conn);

            cmd.CommandText = "DELETE FROM \"Car\" WHERE \"Id\" = @id";

            cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, id);

            int commits = cmd.ExecuteNonQuery();

            if (commits == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UpdateCar(int id, [FromBody] Car updatedCar)
        {
            string connString = Configuration.GetConnectionString("db");
            using var conn = new NpgsqlConnection(connString);

            conn.Open();
            using var cmd = new NpgsqlCommand(connString, conn);

            cmd.CommandText = "UPDATE \"Car\" " +
                "SET \"CarModel\" = @carModel, \"YearOfMake\" = @year, \"Mileage\" = @mileage, \"Horsepower\" = @hp, \"CarMakeId\" = @carMake" +
                " WHERE \"Id\" = @id";

            cmd.Parameters.AddWithValue("carModel", NpgsqlTypes.NpgsqlDbType.Text, updatedCar.CarModel);
            cmd.Parameters.AddWithValue("year", NpgsqlTypes.NpgsqlDbType.Integer, updatedCar.YearOfMake);
            cmd.Parameters.AddWithValue("mileage", NpgsqlTypes.NpgsqlDbType.Integer, updatedCar.Mileage);
            cmd.Parameters.AddWithValue("hp", NpgsqlTypes.NpgsqlDbType.Integer, updatedCar.Horsepower);
            cmd.Parameters.AddWithValue("carMake", NpgsqlTypes.NpgsqlDbType.Integer, updatedCar.CarMakeId);
            cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, id);

            int commits = cmd.ExecuteNonQuery();

            conn.Close();
            if (commits == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(updatedCar);
            }
        }
         */
    }

}
