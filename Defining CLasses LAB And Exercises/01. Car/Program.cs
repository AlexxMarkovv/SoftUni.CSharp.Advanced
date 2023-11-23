using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string tireInfo = Console.ReadLine();

            List<double> tires = new List<double>();

            while (tireInfo != "No more tires")
            {
                double[] tireArrgs = tireInfo
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                double pressSum = 0;
                for (int i = 0; i < tireArrgs.Length; i++)
                {
                    if (i % 2 != 0)
                    {
                        pressSum += tireArrgs[i];
                    }
                }

                tires.Add(pressSum);

                tireInfo = Console.ReadLine();
            }

            string engineInfo = Console.ReadLine();

            List<int> engines = new List<int>();

            while (engineInfo != "Engines done")
            {
                string[] engineArrgs = engineInfo
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsepower = int.Parse(engineArrgs[0]);

                engines.Add(horsepower);

                engineInfo = Console.ReadLine();
            }

            string carInfo = Console.ReadLine();

            List<Car> cars = new List<Car>();

            while (carInfo != "Show special")
            {
                string[] carArrgs = carInfo
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                cars.Add(new Car(carArrgs[0], carArrgs[1],
                    int.Parse(carArrgs[2]),
                    double.Parse(carArrgs[3]),
                    double.Parse(carArrgs[4]),
                    int.Parse(carArrgs[5]),
                    int.Parse(carArrgs[6])));

                carInfo = Console.ReadLine();
            }

            List<Car> specialCars = new List<Car>();

            foreach (var car in cars)
            {
                if (car.Year >= 2017 && engines[car.EngineIndex] > 330
                    && tires[car.TiresIndex] >= 9 && tires[car.TiresIndex] <= 10)
                {
                    specialCars.Add(car);
                }
            }

            foreach (var car in specialCars)
            {
                car.FuelQuantity -= car.FuelConsumption / 5;
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Make: {car.Make}");
                sb.AppendLine($"Model: {car.Model}");
                sb.AppendLine($"Year: {car.Year}");
                sb.AppendLine($"HorsePowers: {engines[car.EngineIndex]}");
                sb.AppendLine($"FuelQuantity: {car.FuelQuantity}");

                Console.WriteLine(sb);
            }
        }
    }
}
