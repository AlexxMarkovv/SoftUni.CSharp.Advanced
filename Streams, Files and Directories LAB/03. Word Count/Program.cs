namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            Dictionary<string, int> wordAndFrequency = new Dictionary<string, int>();

            CalculateWordCounts(wordPath, textPath, outputPath, wordAndFrequency);
        }

        public static void CalculateWordCounts(string wordsFilePath,
            string textFilePath, string outputFilePath, Dictionary<string,int> wordAndFrequency)
        {
            string[] words = File.ReadAllText(wordsFilePath).Split();
            using (StreamReader reader = new StreamReader(textFilePath))
            {
                string currentLine = reader.ReadLine();

                while (currentLine != null)
                {
                    string[] wordsInCurrentLine = currentLine
                        .ToLower()
                        .Split(new[] { ' ', '.', ',', '-', '?', '!', ':', ';' }, 
                        StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in words)
                    {
                        foreach (var item in wordsInCurrentLine)
                        {
                            if (word == item)
                            {
                                if (wordAndFrequency.ContainsKey(item) == false)
                                {
                                    wordAndFrequency.Add(item, 0);
                                }
                                wordAndFrequency[item]++;
                            }
                        }
                    }

                    currentLine = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter("../../../output.txt"))
            {
                foreach (var item in wordAndFrequency.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}