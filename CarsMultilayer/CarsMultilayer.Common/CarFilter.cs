using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsMultilayer.Common
{
    public class CarFilter
    {
        public int? CarMakeId { get; set; }
        public string? CarModel {  get; set; }
        public int? Year { get; set; }
        public int? MinMiles {  get; set; }
        public int? MaxMiles { get; set; }
        public int? MinHorsepower { get; set; }
        public int? MaxHorsepower { get; set; }
        public decimal? MinPrice { get; set; } 
        public decimal? MaxPrice { get; set; } 
        public DateTime? DateStart { get; set; } 
        public DateTime? DateEnd { get; set; }
        public CarFilter() { }

        public CarFilter (int? carMakeId, string? carModel, int? year, int? minMiles, int? maxMiles, int? minHorsepower, int? maxHorsepower, decimal? minPrice, decimal? maxPrice, DateTime? dateStart, DateTime? dateEnd)
        {
            CarMakeId = carMakeId;
            CarModel = carModel;
            Year = year;
            MinMiles = minMiles;
            MaxMiles = maxMiles;
            MinHorsepower = minHorsepower;
            MaxHorsepower = maxHorsepower;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            DateStart = dateStart;
            DateEnd = dateEnd;
        }
    }
}
