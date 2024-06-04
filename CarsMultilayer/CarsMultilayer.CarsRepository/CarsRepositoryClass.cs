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


        }
    }
}
