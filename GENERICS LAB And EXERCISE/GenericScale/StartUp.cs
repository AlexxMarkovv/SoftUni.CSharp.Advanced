using System.Collections.Immutable;

namespace GenericScale;

public class StartUp
{
    public static void Main(string[] args)
    {
        EqualityScale<int> equalityScale = new(5 ,5);

        Console.WriteLine(equalityScale.AreEqual());
    }
}