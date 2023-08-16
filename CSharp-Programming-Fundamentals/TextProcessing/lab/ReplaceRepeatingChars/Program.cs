using System;
using System.Text;

namespace ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length - 1; i++)
            {
                char currentChar = input[i];
                char nextChar = input[i + 1];

                if (currentChar != nextChar)
                {
                    sb.Append(currentChar);
                }
            }

            sb.Append(input[input.Length - 1]);

            Console.WriteLine(sb);
        }
    }
}
