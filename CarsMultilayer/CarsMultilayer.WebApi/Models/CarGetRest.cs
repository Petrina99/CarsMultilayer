namespace CarsMultilayer.WebApi.Models
{
    public class CarGetRest
    {
        public int Id { get; set; }
        public int CarMakeId { get; set; }
        public string? CarModel { get; set; }
        public int Horsepower { get; set; }
        public int YearOfMake { get; set; }
        public int Mileage { get; set; }
        public decimal Price { get; set; }
    }
}
