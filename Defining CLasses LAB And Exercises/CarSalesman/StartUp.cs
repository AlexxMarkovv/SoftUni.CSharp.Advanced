namespace CarSalesman;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Engine> engines = new List<Engine>();
        List<Car> cars = new List<Car>();

        int enginesCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < enginesCount; i++)
        {
            //"{model} {power} {displacement} {efficiency}"
            string[] engineInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Engine engine = CreateEngine(engineInfo);

            engines.Add(engine);
        }

        int carsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < carsCount; i++)
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Car car = CreateCar(carInfo, engines);

            cars.Add(car);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }  

    }

   

    static Engine CreateEngine(string[] engineInfo)
    {
        Engine engine = new(engineInfo[0], int.Parse(engineInfo[1]));

        if (engineInfo.Length > 2)
        {
            int displacement;

            bool isDigit = int.TryParse(engineInfo[2], out displacement);

            if (isDigit)
            {
                engine.Displacement = displacement;
            }
            else
            {
                engine.Efficiency = engineInfo[2];
            }

            if (engineInfo.Length > 3)
            {
                engine.Efficiency = engineInfo[3];
            }
        }

        return engine;
    }

    private static Car CreateCar(string[] carInfo, List<Engine> engines)
    {
        Engine engine = engines.Find(x => x.Model == carInfo[1]);

        Car car = new(carInfo[0], engine);

        if (carInfo.Length > 2)
        {
            int weight;
            bool isDigit = int.TryParse(carInfo[2], out weight);

            if (isDigit)
            {
                car.Weight = weight;
            }
            else
            {
                car.Color = carInfo[2];
            }

            if (carInfo.Length > 3)
            {
                car.Color = carInfo[3];
            }
        }
       
        return car;
    }
}