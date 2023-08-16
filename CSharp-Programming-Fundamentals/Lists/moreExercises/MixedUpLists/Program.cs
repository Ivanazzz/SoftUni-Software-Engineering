using System;
using System.Collections.Generic;
using System.Linq;

namespace MixedUpLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> mixedList = new List<int>();
            int start;
            int end;

            if (firstList.Count > secondList.Count)
            {
                start = Math.Min(firstList[firstList.Count - 1], firstList[firstList.Count - 2]);
                end = Math.Max(firstList[firstList.Count - 1], firstList[firstList.Count - 2]);

                firstList.RemoveRange(firstList.Count - 2, 2);
            }
            else
            {
                start = Math.Min(secondList[0], secondList[1]);
                end = Math.Max(secondList[0], secondList[1]);

                secondList.RemoveRange(0, 2);
            }

            for (int i = 0, j = secondList.Count - 1; i < firstList.Count; i++, j--)
            {
                mixedList.Add(firstList[i]);
                mixedList.Add(secondList[j]);
            }

            List<int> extractedElements = new List<int>();

            foreach (int number in mixedList)
            {
                if(number > start && number < end)
                {
                    extractedElements.Add(number);
                }
            }

            extractedElements.Sort();
            Console.WriteLine(string.Join(" ", extractedElements));
        }
    }
}
