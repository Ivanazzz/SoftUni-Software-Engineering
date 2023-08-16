using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfCoins
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] coins = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int targetSum = int.Parse(Console.ReadLine());

            Dictionary<int, int> result = ChooseCoins(coins, targetSum);

            Console.WriteLine($"Number of coins to take: {result.Values.Sum()}");

            foreach (var coin in result.OrderByDescending(c => c.Key))
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            coins = coins.OrderBy(c => c).ToArray();
            Dictionary<int, int> coinsCount = new Dictionary<int, int>();
            int index = coins.Count - 1;

            while (index > -1)
            {
                int currentCoin = coins[index];
                int result = targetSum / currentCoin;

                if (result < 1)
                {
                    index--;
                    continue;
                }

                coinsCount.Add(currentCoin, result);
                targetSum -= result * currentCoin;

                if (targetSum == 0)
                {
                    break;
                }
            }

            if (targetSum > 0)
            {
                throw new InvalidOperationException();
            }

            return coinsCount;
        }
    }
}
