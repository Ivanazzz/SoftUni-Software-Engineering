using System;

namespace ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] filePath = Console.ReadLine().Split('\\');

            string[] info = filePath[filePath.Length - 1].Split('.');
            string fileName = info[0];
            string extension = info[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
