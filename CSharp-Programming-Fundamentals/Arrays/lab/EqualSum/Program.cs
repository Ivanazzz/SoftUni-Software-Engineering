using System;
using System.Linq;

namespace EqualSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers.Length == 1)
                {
                    Console.WriteLine(0);
                    Environment.Exit(0);
                }

                leftSum = 0;
                for (int sumLeft = i; sumLeft > 0; sumLeft--)
                {
                    int nextLeftElementPosition = sumLeft - 1;
                    if(sumLeft > 0)
                    {
                        leftSum += numbers[nextLeftElementPosition];
;                    }
                }

                rightSum = 0;
                for (int j = i; j < numbers.Length; j++)
                {
                    int nextRightElementPosition = j + 1;
                    if(j < numbers.Length - 1)
                    {
                        rightSum += numbers[nextRightElementPosition];
                    }
                }

                if(leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine("no");
        }
    }
}
