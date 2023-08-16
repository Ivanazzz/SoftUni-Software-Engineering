namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            StreamReader firstFile = new StreamReader(firstInputFilePath);
            StreamReader secondFile = new StreamReader(secondInputFilePath);
            StreamWriter outputFile = new StreamWriter(outputFilePath);

            bool isMoreOfFirstFile = true;
            bool isMoreOfSecondFile = true;

            using (outputFile)
            {
                while (true)
                {
                    string lineOfFirstFile = firstFile.ReadLine();
                    string lineOfSecondFile = secondFile.ReadLine();

                    if (isMoreOfFirstFile)
                    {
                        if (lineOfFirstFile != null)
                        {
                            outputFile.WriteLine(lineOfFirstFile);
                        }
                        else
                        {
                            firstFile.Close();
                            isMoreOfFirstFile = false;
                        }
                    }

                    if (isMoreOfSecondFile)
                    {
                        if (lineOfSecondFile != null)
                        {
                            outputFile.WriteLine(lineOfSecondFile);
                        }
                        else
                        {
                            secondFile.Close();
                            isMoreOfSecondFile = false;
                        }
                    }

                    if (!isMoreOfFirstFile && !isMoreOfSecondFile)
                    {
                        break;
                    }
                }
            }
        }
    }
}
