namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = "C:\\Users\\Lenovo\\OneDrive\\Pictures";  //@$"{Console.ReadLine()}";
            string outputPath = "../../../output.txt";  /*@$"{Console.ReadLine()}";*/

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (File.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }

            Directory.CreateDirectory(outputPath);

            string[] files = Directory.GetFiles(inputPath);

            foreach (string file in files) 
            {
                string fileName = Path.GetFileName(file);

                string destination = Path.Combine(outputPath, fileName);
            
                File.Copy(file, destination);
            }
        }
    }
}
