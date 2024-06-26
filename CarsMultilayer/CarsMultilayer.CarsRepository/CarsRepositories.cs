﻿using CarsMultilayer.CarsRepository.Common;
using CarsMultilayer.Model;
using CarsMultilayer.Common;
using Npgsql;
using System.Text;
using System.Reflection;

namespace CarsMultilayer.CarsRepository
{
    public class CarsRepositories : ICarsRepository
    {
        private readonly string _connectionString;

        public CarsRepositories(string connectionString) 
        {
            _connectionString = connectionString;
        }

        private string QueryBuilder(CarFilter filter, Sorting sorting, Paging paging, NpgsqlCommand cmd) {
            StringBuilder sb = new StringBuilder("SELECT * FROM \"Car\" WHERE 1=1");

            if (filter.CarMakeId != null)
            {
                sb.Append(" AND \"CarMakeId\" = @makeId");
                cmd.Parameters.AddWithValue("makeId", filter.CarMakeId);
            }
                
            if (filter.CarModel != null)
            {
                sb.Append(" AND \"CarModel\" = @model");
                cmd.Parameters.AddWithValue("model", filter.CarModel);
            }

            if (filter.Year != null)
            {
                sb.Append(" AND \"YearOfMake\" = @year");
                cmd.Parameters.AddWithValue("year", (int)filter.Year);
            }

            if (filter.MinMiles != null)
            {
                sb.Append($" AND \"Mileage\" > @minMiles");
                cmd.Parameters.AddWithValue("minMiles", filter.MinMiles);
            }

            if (filter.MaxMiles != null)
            {
                sb.Append(" AND \"Mileage\" < @maxMiles");
                cmd.Parameters.AddWithValue("maxMiles", filter.MaxMiles);
            }

            if (filter.MinHorsepower != null)
            {
                sb.Append(" AND \"Horsepower\" > @minHp");
                cmd.Parameters.AddWithValue("minHp", filter.MinHorsepower);
            }

            if (filter.MaxHorsepower != null)
            {
                sb.Append(" AND \"Horsepower\" < @maxHp");
                cmd.Parameters.AddWithValue("maxHp", filter.MaxHorsepower);
            }

            if (filter.MinPrice != null)
            {
                sb.Append(" AND \"Price\" > @minPrice");
                cmd.Parameters.AddWithValue("minPrice", filter.MinPrice);
            }

            if (filter.MaxPrice != null)
            {
                sb.Append(" AND \"Price\" < @maxPrice");
                cmd.Parameters.AddWithValue("maxPrice", filter.MaxPrice);
            }

            if (filter.DateStart != null)
            {
                sb.Append(" AND \"DateCreated\" > @dateStart");
                cmd.Parameters.AddWithValue("dateStart", filter.DateStart);
            }

            if (filter.DateEnd != null)
            {
                sb.Append(" AND \"DateCreated\" < @dateEnd");
                cmd.Parameters.AddWithValue("dateEnd", filter.DateEnd);
            }

            if (sorting.OrderBy != null && sorting.SortOrder != null) 
            {
                sb.Append($" ORDER BY \"{sorting.OrderBy}\" {sorting.SortOrder}");
            }
            
            if (paging.PageNumber != null && paging.PageSize != null)
            {
                int offsetNum = (int)paging.PageNumber == 1 ? 0 : (int)paging.PageSize * ((int)paging.PageNumber - 1);

                sb.Append(" LIMIT @pageSize");
                cmd.Parameters.AddWithValue("pageSize", paging.PageSize);

                sb.Append(" OFFSET @offsetNum;");
                cmd.Parameters.AddWithValue("offsetNum", offsetNum);
            }
           
            return sb.ToString();
        }

        private Car CarChanger(Car currentCar, Car updatedCar)
        {
            Car changedCar = currentCar;

            foreach (PropertyInfo prop in updatedCar.GetType().GetProperties()) 
            {
                var propValue = prop.GetValue(updatedCar, null);

                if (propValue != null) 
                {
                    changedCar.GetType().GetProperty(prop.Name).SetValue(changedCar, propValue, null);
                }
            }
            
            return changedCar;
        }
        public async Task<List<Car>> GetCarsAsync(CarFilter filter, Paging paging, Sorting sorting)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand(_connectionString, conn);
            cmd.CommandText = QueryBuilder(filter, sorting, paging, cmd);
            Console.WriteLine(cmd.CommandText);
            Console.WriteLine(sorting.SortOrder);
            await using var reader = await cmd.ExecuteReaderAsync();

            var carResult = new List<Car>();

            while (reader.Read())
            {
                try
                {
                    if ((bool)reader[8] == true) 
                    { 
                        Car car = new Car(
                            id: (int)reader[0],
                            carMakeId: (int)reader["CarMakeId"],
                            carModel: reader[1].ToString(),
                            yearOfMake: (int)reader[2],
                            mileage: (int)reader[3],
                            horsepower: (int)reader[4],
                            price: (decimal)reader[5],
                            dateCreated: (DateTime)reader[6],
                            dateUpdated: (DateTime)reader[7],
                            isActive: (bool)reader[8]
                        );

                        carResult.Add(car);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            conn.Close();

            return carResult;
        }

        public async Task<Car> CreateCarAsync(Car newCar)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand(_connectionString, conn);
            cmd.CommandText = "INSERT INTO \"Car\" (\"CarModel\", \"YearOfMake\"," +
                " \"Mileage\", \"Horsepower\", \"CarMakeId\", \"Price\") values (@model, @yearOfMake, " +
                "@mileage, @horsepower, @makeId, @price)";

            cmd.Parameters.AddWithValue("model", NpgsqlTypes.NpgsqlDbType.Text, newCar.CarModel);
            cmd.Parameters.AddWithValue("yearOfMake", NpgsqlTypes.NpgsqlDbType.Integer, newCar.YearOfMake);
            cmd.Parameters.AddWithValue("mileage", NpgsqlTypes.NpgsqlDbType.Integer, newCar.Mileage);
            cmd.Parameters.AddWithValue("horsepower", NpgsqlTypes.NpgsqlDbType.Integer, newCar.Horsepower);
            cmd.Parameters.AddWithValue("makeId", NpgsqlTypes.NpgsqlDbType.Integer, newCar.CarMakeId);
            cmd.Parameters.AddWithValue("price", NpgsqlTypes.NpgsqlDbType.Numeric, newCar.Price);

            int commits = await cmd.ExecuteNonQueryAsync();

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

        public async Task<bool> DeleteCarAsync(int carId) 
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand(_connectionString, conn);

            cmd.CommandText = "UPDATE \"Car\" SET \"IsActive\" = @boolValue WHERE \"Id\" = @id";

            Console.WriteLine(cmd.CommandText);
            cmd.Parameters.AddWithValue("boolValue", false);
            cmd.Parameters.AddWithValue("id", carId);

            
            int commits = await cmd.ExecuteNonQueryAsync();

            conn.Close();

            if (commits > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Car> UpdateCarAsync(int carId, Car updatedCar)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand(_connectionString, conn);

            Car currentCar = await GetCarAsync(carId);

            currentCar = CarChanger(currentCar, updatedCar);

            cmd.CommandText = "UPDATE \"Car\" " +
                "SET \"CarModel\" = @carModel, \"YearOfMake\" = @year, \"Mileage\" = @mileage, \"Horsepower\" = @hp, \"Price\" = @price," +
                " \"CarMakeId\" = @carMake," +
                " \"DateUpdated\" = @dateUpdated" +
                " WHERE \"Id\" = @id";

            DateTime currentDate = DateTime.Now;

            cmd.Parameters.AddWithValue("carModel", NpgsqlTypes.NpgsqlDbType.Text, currentCar.CarModel);
            cmd.Parameters.AddWithValue("year", NpgsqlTypes.NpgsqlDbType.Integer, currentCar.YearOfMake);
            cmd.Parameters.AddWithValue("mileage", NpgsqlTypes.NpgsqlDbType.Integer, currentCar.Mileage);
            cmd.Parameters.AddWithValue("hp", NpgsqlTypes.NpgsqlDbType.Integer, currentCar.Horsepower);
            cmd.Parameters.AddWithValue("carMake", NpgsqlTypes.NpgsqlDbType.Integer, currentCar.CarMakeId);
            cmd.Parameters.AddWithValue("price", currentCar.Price);
            cmd.Parameters.AddWithValue("dateUpdated", currentDate);
            cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, carId);

            int commits = await cmd.ExecuteNonQueryAsync();

            conn.Close();

            if (commits > 0)
            {
                return currentCar;
            }
            else
            {
                return null;
            }
        }

        public async Task<Car> GetCarAsync(int carId)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand(_connectionString, conn);

            cmd.CommandText = "SELECT * FROM \"Car\" WHERE \"Id\" = @id";

            cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, carId);
            using var reader = await cmd.ExecuteReaderAsync();

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
                    fetchedCar.Price = (decimal)reader["Price"];
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            conn.Close();

            return fetchedCar;
        }

        public async Task<List<CarMakeModelJoin>> GetCarsDetailedAsync()
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand(_connectionString, conn);

            cmd.CommandText = $"SELECT * FROM \"Car\" c INNER JOIN \"CarMake\" cm on cm.\"Id\" = c.\"CarMakeId\"";

            using var reader = await cmd.ExecuteReaderAsync();

            List<CarMakeModelJoin> joinResult = new List<CarMakeModelJoin> ();

            while (reader.Read())
            {
                try
                {
                    CarMakeModelJoin join = new CarMakeModelJoin();
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
                    throw new Exception(ex.Message);
                }
            }

            conn.Close();


            return joinResult;
        }

        public async Task<CarMakeModelJoin> GetCarDetailedAsync(int carId)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand(_connectionString, conn);

            cmd.CommandText = "SELECT * FROM \"Car\" c FULL JOIN \"CarMake\" cm on cm.\"Id\" = c.\"CarMakeId\" where c.\"Id\" = @id";

            cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, carId);
            using var reader = await cmd.ExecuteReaderAsync();

            CarMakeModelJoin joinResult = new CarMakeModelJoin();

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
                    throw new Exception(ex.Message);
                }
            }

            return joinResult;
        }
    }
}
