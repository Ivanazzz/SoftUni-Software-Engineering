using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwordByContest = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> candidatesContestsPoints = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "end of contests")
                {
                    break;
                }

                if (!passwordByContest.ContainsKey(input[0]))
                {
                    passwordByContest.Add(input[0], input[1]);
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "end of submissions")
                {
                    break;
                }

                string contest = input[0];
                string password = input[1];
                string username = input[2];
                int points = int.Parse(input[3]);

                if (passwordByContest.ContainsKey(contest) && passwordByContest[contest] == password)
                {
                    UpsertUsername(username, points, contest, candidatesContestsPoints);
                }
            }

            string bestCandidateName = candidatesContestsPoints
                .OrderByDescending(c => c.Value.Values.Sum())
                .First().Key;
            int bestCandidateTotalPoints = candidatesContestsPoints[bestCandidateName].Values.Sum();

            Console.WriteLine($"Best candidate is {bestCandidateName} with total {bestCandidateTotalPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var username in candidatesContestsPoints)
            {
                var orderedByPointsDescending = username.Value.OrderByDescending(c => c.Value);

                Console.WriteLine(username.Key);
                foreach (var contest in orderedByPointsDescending)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

        private static void UpsertUsername(string username, int points, string contest, SortedDictionary<string, Dictionary<string, int>> candidatesContestsPoints)
        {
            if (!candidatesContestsPoints.ContainsKey(username))
            {
                candidatesContestsPoints.Add(username, new Dictionary<string, int>());
            }

            if (!candidatesContestsPoints[username].ContainsKey(contest))
            {
                candidatesContestsPoints[username][contest] = 0;    
            }

            if (candidatesContestsPoints[username][contest] < points)
            {
                candidatesContestsPoints[username][contest] = points;
            }
        }
    }
}
