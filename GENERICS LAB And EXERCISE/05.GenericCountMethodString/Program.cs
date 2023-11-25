namespace GenericCountMethodString;

public class Program
{
    static void Main(string[] args)
    {
        int elCount = int.Parse(Console.ReadLine());

        Box<double> box = new();

        for (int i = 0; i < elCount; i++)
        {
            double item = double.Parse(Console.ReadLine());

            box.Add(item);
        }

        double valueToCompare = double.Parse(Console.ReadLine());

        int count = box.CountElementsGreaterThanValue(valueToCompare);
        Console.WriteLine(count);
    }
}