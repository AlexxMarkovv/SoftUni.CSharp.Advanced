using System.Reflection;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Car> carsByNames = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = new()
                {
                    Model = carInfo[0],
                    FuelAmount = double.Parse(carInfo[1]),
                    FuelConsumptionFor1Km = double.Parse(carInfo[2]),
                };

                carsByNames.Add(car.Model, car);
            }

            string command;
            while((command = Console.ReadLine()) != "End")
            {
                string[] cmndArrgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = cmndArrgs[1];
                int amountKm = int.Parse(cmndArrgs[2]);

                Car car = carsByNames[carModel];

                car.Drive(amountKm);
            }

            foreach (var vehicle in carsByNames.Values)
            {
                Console.WriteLine($"{vehicle.Model} " +
                    $"{vehicle.FuelAmount:f2} {vehicle.TravelledDistance}");
            }
        }
    }
}