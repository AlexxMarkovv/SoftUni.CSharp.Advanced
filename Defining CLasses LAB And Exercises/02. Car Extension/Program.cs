using System.Linq.Expressions;

namespace CarEngineAndTires
{
    static void Main()
    {
        Engine engine = new Engine(265, 2);

        var tires = new Tire[4]
        {
            new Tire(1, 2.5),
            new Tire(1, 2.1),
            new Tire(2, 2.2),
            new Tire(2, 2.2),
        };

        Car car = new Car("BMW", "X3", 2023, 70, 5, engine, tires);
    }
}