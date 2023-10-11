
namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "Golf";
            car.Year = 2006;
            car.FuelQuantity = 200;
            car.FuelConsumption = 200;

            car.Drive(2000);

            Console.WriteLine(car.WhoAmI());
        }
    }
}
