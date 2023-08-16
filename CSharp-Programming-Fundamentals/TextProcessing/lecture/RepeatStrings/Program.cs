using System;

namespace RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string output = "";

            foreach (string word in words)
            {
                int count = word.Length;

                for (int i = 0; i < count; i++)
                {
                    output += word;
                }
            }

            Console.WriteLine(output);
        }
    }
}
