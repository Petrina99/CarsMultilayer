namespace CarsMultilayer.Common
{
    public class CommonClass
    {
        public string ConnString {  get; set; }

        public CommonClass() 
        {
            ConnString = "Server=localhost;port=5432;User Id=postgres;Password=admin;Database=cars";
        }
    }
}
