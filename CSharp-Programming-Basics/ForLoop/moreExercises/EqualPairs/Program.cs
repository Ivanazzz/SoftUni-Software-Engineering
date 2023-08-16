using System;

namespace EqualPairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            bool isValid = true;
            int sum = 0;
            int maxSum = 0;
            int minSum = 0;

            for (int i = 1; i <= n; i++)
            {
                int firstNum = int.Parse(Console.ReadLine());
                int secondNum = int.Parse(Console.ReadLine());

                int numsSum = firstNum + secondNum;
                if (i == 1)
                {
                    sum = numsSum;
                    minSum = numsSum;
                    maxSum = numsSum;
                }
                else
                {
                    if (numsSum != sum)
                    {
                        isValid = false;
                        if (numsSum > maxSum)
                        {
                            maxSum = numsSum;
                        }
                        if (numsSum < minSum)
                        {
                            minSum = numsSum;
                        }
                    }
                }
            }

            if (isValid)
            {
                Console.WriteLine($"Yes, value = {sum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff = {maxSum - minSum}");
            }
        }
    }
}
