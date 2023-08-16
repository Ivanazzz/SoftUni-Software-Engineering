namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            StreamReader wordsReader = new StreamReader(wordsFilePath);
            using (wordsReader)
            {
                string line = wordsReader.ReadLine();
                while (line != null)
                {
                    string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        if (!wordsCount.ContainsKey(word))
                        {
                            wordsCount.Add(word, 0);
                        }
                    }

                    line = wordsReader.ReadLine();
                }
            }

            StreamReader reader = new StreamReader(textFilePath);
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] words = line.Split(new char[] { ' ', '.', ',', '-', '!', '?'}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        if (wordsCount.ContainsKey(word.ToLower()))
                        {
                            wordsCount[word.ToLower()]++;
                        }
                    }

                    line = reader.ReadLine();
                }
            }

            wordsCount = wordsCount.OrderByDescending(w => w.Value).ToDictionary(w => w.Key, w => w.Value);

            StreamWriter writer = new StreamWriter(outputFilePath);
            using (writer)
            {
                foreach (var word in wordsCount)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
