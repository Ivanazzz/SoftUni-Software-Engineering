using System;
using System.Collections.Generic;
using System.Linq;

namespace TheAngryCat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] priceRatings = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int entryPoint = int.Parse(Console.ReadLine());
            string typeOfItems = Console.ReadLine();

            string leftOrRight = "";
            int maxSumOfPriceRatings = 0;
            int leftSum = 0;
            int rightSum = 0;

            if (typeOfItems == "cheap")
            {
                for (int i = 0; i < entryPoint; i++)
                {
                    if (priceRatings[i] < priceRatings[entryPoint])
                    {
                        leftSum += priceRatings[i];
                    }
                }

                for (int i = entryPoint + 1; i < priceRatings.Length; i++)
                {
                    if (priceRatings[i] < priceRatings[entryPoint])
                    {
                        rightSum += priceRatings[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < entryPoint; i++)
                {
                    if (priceRatings[i] >= priceRatings[entryPoint])
                    {
                        leftSum += priceRatings[i];
                    }
                }

                for (int i = entryPoint + 1; i < priceRatings.Length; i++)
                {
                    if (priceRatings[i] >= priceRatings[entryPoint])
                    {
                        rightSum += priceRatings[i];
                    }
                }
            }

            if (leftSum >= rightSum)
            {
                maxSumOfPriceRatings = leftSum;
                leftOrRight = "Left";
            }
            else
            {
                maxSumOfPriceRatings = rightSum;
                leftOrRight = "Right";
            }

            Console.WriteLine($"{leftOrRight} - {maxSumOfPriceRatings}");
        }
    }
}
