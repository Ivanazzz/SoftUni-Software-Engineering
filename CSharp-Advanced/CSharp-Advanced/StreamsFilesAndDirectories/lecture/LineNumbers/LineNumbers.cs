namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);

            using (reader)
            {
                int index = 1;

                using (writer)
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine($"{index}. {line}");

                        line = reader.ReadLine();
                        index++;
                    }
                }
            }
        }
    }
}
