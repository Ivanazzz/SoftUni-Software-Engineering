using System;
using System.Linq;

namespace KaminoFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //sequence length
            int sequenceLength = int.Parse(Console.ReadLine());

            int[] bestDna = new int[sequenceLength];
            int dnaSum = 0;
            int dnaCount = -1;
            int dnaStartIndex = -1;
            int dnaSamples = 0;
            int sample = 0;

            string input = Console.ReadLine();
            while(input != "Clone them!")
            {
                // Current DNA info
                sample++;
                int[] currentDna = input.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                // Current DNA elements
                int currentCount = 0;
                int currentStartIndex = 0;
                int currentEndIndex = 0;
                int currentDnaSum = 0;
                bool isCurrentDnaBetter = false;

                int count = 0;
                for(int i = 0; i < currentDna.Length; i++)
                {
                    if(currentDna[i] != 1)
                    {
                        count = 0;
                        continue;
                    }
                    count++;
                    if(count > currentCount)
                    {
                        currentCount = count;
                        currentEndIndex = i;
                    }
                }

                currentStartIndex = currentEndIndex - currentCount + 1;
                currentDnaSum = currentDna.Sum();

                // Check current DNA with best DNA
                if(currentCount > dnaCount)
                {
                    isCurrentDnaBetter = true;
                }
                else if(currentCount == dnaCount)
                {
                    if(currentStartIndex < dnaStartIndex)
                    {
                        isCurrentDnaBetter = true;
                    }
                    else if (currentStartIndex == dnaStartIndex)
                    {
                        if (currentDnaSum > dnaSum)
                        {
                            isCurrentDnaBetter = true;
                        }
                    }
                }

                if(isCurrentDnaBetter)
                {
                    bestDna = currentDna;
                    dnaCount = currentCount;
                    dnaStartIndex = currentStartIndex;
                    dnaSum = currentDnaSum;
                    dnaSamples = sample;
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {dnaSamples} with sum: {dnaSum}.");
            Console.WriteLine(string.Join(' ', bestDna));
        }
    }
}
