using System;

namespace ExtractPersonInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string line = Console.ReadLine();

                int indexOfNameStart = line.IndexOf('@');
                int indexOfNameEnd = line.IndexOf('|');
                string name = line.Substring(indexOfNameStart + 1, indexOfNameEnd - indexOfNameStart - 1);

                int indexOfAgeStart = line.IndexOf('#');
                int indexOfAgeEnd = line.IndexOf('*');
                string ageStr = line.Substring(indexOfAgeStart + 1, indexOfAgeEnd - indexOfAgeStart - 1);

                Console.WriteLine($"{name} is {ageStr} years old.");
            }
        }
    }
}
