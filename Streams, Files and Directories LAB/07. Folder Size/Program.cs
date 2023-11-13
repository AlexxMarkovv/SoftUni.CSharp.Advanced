namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            long size = GetFolderSize(folderPath);

            File.WriteAllText(outputFilePath, $"{size / 1024} KB");
        }

        public static long GetFolderSize(string path)
        {
            string[] filePaths = Directory.GetFiles(path);

            long size = 0;
            foreach (string filePath in filePaths)
            {
                FileInfo file = new FileInfo(filePath);
                size += file.Length;
                Console.WriteLine(filePath);
            }

            foreach (var dirPath in Directory.GetDirectories(path))
            {
                size += GetFolderSize(dirPath);
            }

            return size;
        }
    }
}