using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondPlayerHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while(firstPlayerHand.Count > 0 && secondPlayerHand.Count > 0)
            {
                int winnerCard = 0;
                int loserCard = 0;

                if(firstPlayerHand[0] > secondPlayerHand[0])
                {
                    winnerCard = firstPlayerHand[0];
                    loserCard = secondPlayerHand[0];
                    firstPlayerHand.Add(winnerCard);
                    firstPlayerHand.Add(loserCard);
                }
                else if(secondPlayerHand[0] > firstPlayerHand[0])
                {
                    winnerCard = secondPlayerHand[0];
                    loserCard = firstPlayerHand[0];
                    secondPlayerHand.Add(winnerCard);
                    secondPlayerHand.Add(loserCard);
                }

                firstPlayerHand.RemoveAt(0);
                secondPlayerHand.RemoveAt(0);
            }

            if(firstPlayerHand.Count != 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayerHand.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayerHand.Sum()}");
            }
        }
    }
}
