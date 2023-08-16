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
            double sum = 0;
            
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] fileInfos = dir.GetFiles("*", SearchOption.AllDirectories);

            foreach (FileInfo fileInfo in fileInfos)
            {
                sum += fileInfo.Length;
            }

            sum = sum / 1024 / 1024;

            File.WriteAllText(outputFilePath, $"{sum.ToString()} KB");
        }
    }
}
