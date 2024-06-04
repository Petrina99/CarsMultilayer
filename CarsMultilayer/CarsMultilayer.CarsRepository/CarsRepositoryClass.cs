using CarsMultilayer.CarsRepository.Common;
using CarsMultilayer.Model;
using CarsMultilayer.Common;
using Npgsql;

namespace CarsMultilayer.CarsRepository
{
    public class CarsRepositoryClass : ICarsRepository
    {
        private string cString {  get; set; }

        public CarsRepositoryClass() 
        {
            CommonClass comm = new CommonClass();
            cString = comm.ConnString;
        }

        public List<Car> GetCars()
        {
            using var conn = new NpgsqlConnection(cString);
            conn.Open();

            using var cmd = new NpgsqlCommand(cString, conn);
            cmd.CommandText = $"SELECT * FROM \"Car\"";

            using var reader = cmd.ExecuteReader();

            var carResult = new List<Car>();

            while (reader.Read())
            {
                try
                {
                    carResult.Add(
                        new Car(
                            id: (int)reader[0],
                            carMakeId: (int)reader["CarMakeId"],
                            carModel: reader[1].ToString(),
                            yearOfMake: (int)reader[2],
                            mileage: (int)reader[3],
                            horsepower: (int)reader[4]
                        )
                    );
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            conn.Close();

            return carResult;
        }

        public Car CreateCar(Car newCar)
        {
            using var conn = new NpgsqlConnection(cString);
            conn.Open();

            using var cmd = new NpgsqlCommand(cString, conn);
            cmd.CommandText = "INSERT INTO \"Car\" (\"CarModel\", \"YearOfMake\"," +
                " \"Mileage\", \"Horsepower\", \"CarMakeId\") values (@model, @yearOfMake, " +
                "@mileage, @horsepower, @makeId)";

            cmd.Parameters.AddWithValue("model", NpgsqlTypes.NpgsqlDbType.Text, newCar.CarModel);
            cmd.Parameters.AddWithValue("yearOfMake", NpgsqlTypes.NpgsqlDbType.Integer, newCar.YearOfMake);
            cmd.Parameters.AddWithValue("mileage", NpgsqlTypes.NpgsqlDbType.Integer, newCar.Mileage);
            cmd.Parameters.AddWithValue("horsepower", NpgsqlTypes.NpgsqlDbType.Integer, newCar.Horsepower);
            cmd.Parameters.AddWithValue("makeId", NpgsqlTypes.NpgsqlDbType.Integer, newCar.CarMakeId);

            int commits = cmd.ExecuteNonQuery();

            conn.Close();

            if (commits > 0)
            {
                return newCar;
            }
            else
            {
                throw new Exception("Post failed");
            }
        }

        public bool DeleteCar(int carId) 
        {
            using var conn = new NpgsqlConnection(cString);
            conn.Open();

            using var cmd = new NpgsqlCommand(cString, conn);

            cmd.CommandText = "DELETE FROM \"Car\" WHERE \"Id\" = @id";

            cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, carId);

            int commits = cmd.ExecuteNonQuery();

            if (commits > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Car UpdateCar(int carId, Car updatedCar)
        {
            using var conn = new NpgsqlConnection(cString);
            conn.Open();

            using var cmd = new NpgsqlCommand(cString, conn);

            cmd.CommandText = "UPDATE \"Car\" " +
                "SET \"CarModel\" = @carModel, \"YearOfMake\" = @year, \"Mileage\" = @mileage, \"Horsepower\" = @hp, \"CarMakeId\" = @carMake" +
                " WHERE \"Id\" = @id";

            cmd.Parameters.AddWithValue("carModel", NpgsqlTypes.NpgsqlDbType.Text, updatedCar.CarModel);
            cmd.Parameters.AddWithValue("year", NpgsqlTypes.NpgsqlDbType.Integer, updatedCar.YearOfMake);
            cmd.Parameters.AddWithValue("mileage", NpgsqlTypes.NpgsqlDbType.Integer, updatedCar.Mileage);
            cmd.Parameters.AddWithValue("hp", NpgsqlTypes.NpgsqlDbType.Integer, updatedCar.Horsepower);
            cmd.Parameters.AddWithValue("carMake", NpgsqlTypes.NpgsqlDbType.Integer, updatedCar.CarMakeId);
            cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, carId);

            int commits = cmd.ExecuteNonQuery();

            conn.Close();

            if (commits > 0)
            {
                return updatedCar;
            }
            else
            {
                return null;
            }
        }
    }
}
