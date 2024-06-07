namespace CarsMultilayer.WebApi.Models
{
    public class CarUpdateRest
    {
        public int? CarMakeId { get; set; }
        public string? CarModel { get; set; }
        public int? Horsepower { get; set; }
        public int? YearOfMake { get; set; }
        public int? Mileage { get; set; }
        public decimal? Price { get; set; }

        public CarUpdateRest() {}
        public CarUpdateRest(int? carMakeId, string? carModel, int? horsepower, int? yearOfMake, int? mileage, decimal? price)
        {
            CarMakeId = carMakeId;
            CarModel = carModel;
            Horsepower = horsepower;
            YearOfMake = yearOfMake;
            Mileage = mileage;
            Price = price;
        }
    }
}
