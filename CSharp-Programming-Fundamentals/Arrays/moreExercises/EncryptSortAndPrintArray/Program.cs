using System;

namespace EncryptSortAndPrintArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());
            
            int[] codes = new int[numberOfStrings];
            for (int i = 0; i < numberOfStrings; i++)
            {
                int currentSum = 0;
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                {
                    char letter = input[j];
                    if (letter == 'A' || letter == 'a' ||
                        letter == 'E' || letter == 'e' ||
                        letter == 'I' || letter == 'i' ||
                        letter == 'O' || letter == 'o' ||
                        letter == 'U' || letter == 'u')
                    {
                        currentSum += (int)letter * input.Length;
                    }
                    else
                    {
                        currentSum += (int)letter / input.Length;
                    }
                }
                codes[i] = currentSum;
            }

            Array.Sort(codes);
            for (int i = 0; i < codes.Length; i++)
            {
                Console.WriteLine(codes[i]);
            }
        }
    }
}
