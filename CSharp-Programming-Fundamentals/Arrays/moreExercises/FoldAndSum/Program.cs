using System;
using System.Linq;

namespace FoldAndSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int subarrayLength = numbers.Length / 2;
            int[] nums1 = new int[subarrayLength];
            int[] nums2 = new int[subarrayLength];
            
            int indexInNums1 = 0;
            int indexInNums2 = 0;
            int start = numbers.Length / 4;
            int end = (start - 1) + subarrayLength;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i >= start && i <= end)
                {
                    nums1[indexInNums1] = numbers[i];
                    indexInNums1++;
                }
                else
                {
                    nums2[indexInNums2] = numbers[i];
                    indexInNums2++;
                }
            }
            
            for (int i = 0; i < subarrayLength; )
            {
                if(i < subarrayLength / 2)
                {
                    for (int j = (subarrayLength / 2) - 1; j > -1; j--)
                    {
                        int result = nums1[i] + nums2[j];
                        Console.Write($"{result} ");
                        i++;
                    }
                }
                else
                {
                    for (int j = subarrayLength - 1; j >= (subarrayLength - (subarrayLength / 2)); j--)
                    {
                        int result = nums1[i] + nums2[j];
                        Console.Write($"{result} ");
                        i++;
                    }
                }
            }
        }
    }
}
