using CarsMultilayer.CarMakeRepository.Common;
using CarsMultilayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace CarsMultilayer.CarMakeRepository
{
    public class CarMakeRepositories : ICarMakeRepository { 
        private readonly string _connectionString;

        public CarMakeRepositories (string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<CarMake>> GetAllCarMakeAsync()
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand(_connectionString, conn);

            cmd.CommandText = "SELECT * FROM \"CarMake\"";

            using var reader = await cmd.ExecuteReaderAsync();

            List<CarMake> fetchedCarMake = new List<CarMake>();

            while (reader.Read())
            {
                try
                {
                    if ((bool)reader["IsActive"] == true)
                    {
                        CarMake carMake = new CarMake
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            MakeName = reader.GetString(reader.GetOrdinal("MakeName")),
                            MakeCountry = reader.GetString(reader.GetOrdinal("MakeCountry"))
                        };
                          
                        fetchedCarMake.Add(carMake);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            conn.Close();

            return fetchedCarMake;
        }

        public async Task<CarMake> GetCarMakeAsync(int id)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand(_connectionString, conn);

            cmd.CommandText = "SELECT * FROM \"CarMake\" WHERE \"Id\" = @id";

            cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, id);
            using var reader = await cmd.ExecuteReaderAsync();

            CarMake fetchedCarMake = new CarMake();

            while (reader.Read())
            {
                try
                {
                    fetchedCarMake.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    fetchedCarMake.MakeName = reader.GetString(reader.GetOrdinal("MakeName"));
                    fetchedCarMake.MakeCountry = reader.GetString(reader.GetOrdinal("MakeCountry"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            conn.Close();

            return fetchedCarMake;
        }
    }
}
