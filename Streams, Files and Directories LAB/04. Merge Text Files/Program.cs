namespace MergeFiles
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            string[] readFirst = File.ReadAllText("FileOne.txt").Split();
            string[] readSecond = File.ReadAllText("FileTwo.txt").Split('\r', '\n');

            //File.WriteAllText("result.txt", "");

            //for (int i = 0; i < readFirst.Length; i++)
            //{
            //    File.AppendAllText("result.txt", readFirst[i] + "\r\n" + readSecond[i]);
            //}

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            var list = File.ReadAllLines(@"..\..\FileOne.txt").ToList();
            list.AddRange(File.ReadAllLines(@"..\..\FileTwo.txt"));
            list.Sort();
            File.WriteAllLines(@"..\..\Output.txt", list);
        }
    }
}