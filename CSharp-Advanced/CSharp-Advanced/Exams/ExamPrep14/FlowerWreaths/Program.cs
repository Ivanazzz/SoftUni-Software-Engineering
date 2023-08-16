using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int neededWreaths = 5;
            int madeWreaths = 0;
            int flowers = 0;
            int neededFlowersPerWreath = 15;

            while (lilies.Any() && roses.Any())
            {
                int sum = lilies.Peek() + roses.Peek();

                if (sum == neededFlowersPerWreath)
                {
                    madeWreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (sum > neededFlowersPerWreath)
                {
                    int temp = lilies.Pop() - 2;
                    lilies.Push(temp);
                }
                else
                {
                    flowers += lilies.Pop() + roses.Dequeue();
                }
            }

            madeWreaths += flowers / neededFlowersPerWreath;

            if (madeWreaths >= neededWreaths)
            {
                Console.WriteLine($"You made it, you are going to the competition with {madeWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {neededWreaths - madeWreaths} wreaths more!");
            }
        }
    }
}
