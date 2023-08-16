namespace OddLines
{
    using System.IO;
	
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);

            using (reader)
            {
                int index = 0;
                string line = reader.ReadLine();

                using (writer)
                {
                    while (line != null)
                    {
                        if (index % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }

                        index++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
