using System;
using System.Linq;

namespace MagicSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int specialNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length; i++) 
            {
                for (int j = i + 1; j < numbers.Length; j++) 
                {
                    if(numbers[i] + numbers[j] == specialNumber)
                    {
                        Console.Write($"{numbers[i]} {numbers[j]}");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
