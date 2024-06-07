using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace CarsMultilayer.Model
{
    public class Car
    {
        [Required]
        public int Id { get; set; }
        public int? CarMakeId { get; set; }
        public string? CarModel { get; set; }
        public int? Horsepower { get; set; }
        public int? YearOfMake { get; set; }
        public int? Mileage { get; set; }
        public decimal? Price { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool? IsActive { get; set; }

        public Car() { }
        public Car(int id, int carMakeId, string? carModel, int horsepower, int yearOfMake, int mileage, decimal price, DateTime dateCreated, DateTime dateUpdated, bool? isActive)
        {
            Id = id;
            CarMakeId = carMakeId;
            CarModel = carModel;
            Horsepower = horsepower;
            YearOfMake = yearOfMake;
            Mileage = mileage;
            Price = price;
            DateCreated = dateCreated.Date;
            DateUpdated = dateUpdated.Date;
            IsActive = isActive;
        }
    }
}
