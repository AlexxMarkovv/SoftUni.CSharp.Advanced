namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using StreamReader reader = new StreamReader(inputFilePath);

            StringBuilder sb = new StringBuilder();
            int count = 0;

            string line = string.Empty;
            while (line != null)
            {
                line = reader.ReadLine();

                if (count % 2 == 0)
                {
                    string replacedSymbols = ReplaceSymbols(line);
                    string reversedWords = ReverseWords(replacedSymbols);
                    sb.AppendLine(reversedWords);
                }

                count++;
            }

            return sb.ToString();
        }

        private static string ReplaceSymbols(string line)
        {
            StringBuilder sb = new StringBuilder(line);

            char[] symbols = { '-', ',', '.', '!', '?' };

            foreach (var symbol in symbols)
            {
                sb.Replace(symbol, '@');
            }

            return sb.ToString();
        }

        private static string ReverseWords(string replacedSymbols)
        {
            string[] reversedWords = replacedSymbols
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            return string.Join(" ", reversedWords);
        }
    }
}
