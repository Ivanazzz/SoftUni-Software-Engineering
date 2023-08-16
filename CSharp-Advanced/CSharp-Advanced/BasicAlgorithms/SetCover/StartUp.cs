using System;
using System.Collections.Generic;
using System.Linq;

namespace SetCover
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> universe = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int[]> sets = new List<int[]>();

            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                int[] set = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                sets.Add(set);
            }

            List<int[]> result = ChooseSets(sets, universe);

            Console.WriteLine($"Sets to take ({result.Count}):");

            foreach (var set in result)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> result = new List<int[]>();

            while (sets.Count > 0 && universe.Count > 0)
            {
                int[] largestSubsetOfUniverse = sets
                    .OrderByDescending(set => 
                        set.Count(el => universe.Contains(el)))
                    .FirstOrDefault();

                foreach (var item in largestSubsetOfUniverse)
                {
                    universe.Remove(item);
                }

                result.Add(largestSubsetOfUniverse);
                sets.Remove(largestSubsetOfUniverse);
            }

            return result;
        }
    }
}
