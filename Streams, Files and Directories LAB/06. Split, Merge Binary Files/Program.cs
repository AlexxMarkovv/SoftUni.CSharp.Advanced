namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            int parts = 2;

            using (FileStream stream = new FileStream(sourceFilePath, FileMode.Open))
            {
                long sizeOfPart = stream.Length / parts;

                for (int i = 0; i < parts; i++)
                {
                    using(FileStream partStream = new FileStream(sourceFilePath + 
                        $"{i + 1}", FileMode.OpenOrCreate))
                    {
                        byte[] buffer = new byte[sizeOfPart];
                        stream.Read(buffer, 0, (int)sizeOfPart);

                        partStream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            // TODO: write your code here…
        }
    }
}