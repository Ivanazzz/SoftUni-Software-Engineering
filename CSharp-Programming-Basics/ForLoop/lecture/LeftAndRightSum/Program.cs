using System;

namespace LeftAndRightSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < n * 2; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (i < n)
                {
                    leftSum += number;
                }
                else
                {
                    rightSum += number;
                }
            }

            int diff = Math.Abs(leftSum - rightSum);
            if (diff == 0)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {diff}");
            }
        }
    }
}
