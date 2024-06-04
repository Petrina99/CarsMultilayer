using System.ComponentModel.DataAnnotations;

namespace CarsMultilayer.Model
{
    public class CarMakeModelJoin
    {
        public int MakeId { get; set; }
        public int CarId { get; set; }
        public string? MakeName { get; set; }
        public string? MakeCountry { get; set; }
        public string? CarModel { get; set; }
        public int Horsepower { get; set; }
        public int YearOfMake { get; set; }
        public int Mileage { get; set; }

        public CarMakeModelJoin() { }
    }
}