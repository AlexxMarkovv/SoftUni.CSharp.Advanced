Stack<int> foodPortions = new Stack<int>(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Queue<int> staminaValues = new Queue<int>(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Dictionary<string, int> peaksValues = new Dictionary<string, int>()
{
    {"Vihren", 80 },
    {"Kutelo", 90 },
    {"Banski Suhodol", 100 },
    {"Polezhan", 60 },
    {"Kamenitza", 70 }
};

List<string> peaksConquered = new List<string>();

while (foodPortions.Count > 0)
{
    int foodAndStaminaSum = foodPortions.Pop() + staminaValues.Dequeue();

    if (foodAndStaminaSum >= peaksValues.FirstOrDefault().Value)
    {
        peaksConquered.Add(peaksValues.First().Key);
        peaksValues.Remove(peaksValues.First().Key);
    }

    if (peaksConquered.Count == 5)
    {
        break;
    }
}

if (peaksConquered.Count == 5)
{
    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
}
else
{
    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
}

if (peaksConquered.Any())
{
    Console.WriteLine("Conquered peaks:");
    Console.WriteLine(string.Join(Environment.NewLine, peaksConquered));
}


