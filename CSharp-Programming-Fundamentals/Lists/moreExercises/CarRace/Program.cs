using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            double firstCarSeconds = 0;
            double secondCarSeconds = 0;

            int middle = sequence.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                if(sequence[i] == 0)
                {
                    firstCarSeconds *= 0.8;
                }
                else
                {
                    firstCarSeconds += sequence[i];
                }
            }

            for (int i = sequence.Count - 1; i > middle; i--)
            {
                if (sequence[i] == 0)
                {
                    secondCarSeconds *= 0.8;
                }
                else
                {
                    secondCarSeconds += sequence[i];
                }
            }

            if(firstCarSeconds > secondCarSeconds)
            {
                Console.WriteLine($"The winner is right with total time: {secondCarSeconds}");
            }
            else if(secondCarSeconds > firstCarSeconds)
            {
                Console.WriteLine($"The winner is left with total time: {firstCarSeconds}");
            }
        }
    }
}
