﻿namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();
            StreamReader reader = new StreamReader(inputFilePath);

            using (reader)
            {
                string line = string.Empty;
                int count = 0;

                while (line != null)
                {
                    line = reader.ReadLine();

                    if (count % 2 == 0)
                    {
                        string replacedSymbols = ReplaceSymbols(line);
                        string reversedWords = ReverseWords(replacedSymbols);
                        sb.AppendLine(reversedWords);
                    }

                    count++;
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string ReplaceSymbols(string line)
        {
            string[] symbolsToReplace = { "-", ",", ".", "!", "?" };

            foreach (var symbol in symbolsToReplace)
            {
                line = line.Replace(symbol, "@");
            }

            return line;
        }

        public static string ReverseWords(string replacedSymbols)
        {
            string[] reversedWords = replacedSymbols
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();
            return string.Join(' ', reversedWords);
        }
    }
}
