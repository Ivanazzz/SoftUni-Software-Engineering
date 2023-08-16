using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> pointsByUsername = new SortedDictionary<string, int>();
            SortedDictionary<string, int> submissionsByLanguage = new SortedDictionary<string, int>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "exam finished")
                {
                    break;
                }

                string username = tokens[0];

                if (tokens[1] == "banned")
                {
                    pointsByUsername.Remove(username);
                    continue;
                }

                string language = tokens[1];
                int points = int.Parse(tokens[2]);

                ContainsUsername(username, points, pointsByUsername);
                ContainsLanguage(language, submissionsByLanguage);
            }

            var orderedParticipants = pointsByUsername.OrderByDescending(p => p.Value);
            var orderedLanguages = submissionsByLanguage.OrderByDescending(l => l.Value);

            PrintResults(orderedParticipants, orderedLanguages);
        }

        private static void ContainsUsername(string username, int points, SortedDictionary<string, int> pointsByUsername)
        {
            if (!pointsByUsername.ContainsKey(username))
            {
                pointsByUsername.Add(username, points);
            }
            else
            {
                if (pointsByUsername[username] < points)
                {
                    pointsByUsername[username] = points;
                }
            }
        }

        private static void ContainsLanguage(string language, SortedDictionary<string, int> submissionsByLanguage)
        {
            if (!submissionsByLanguage.ContainsKey(language))
            {
                submissionsByLanguage.Add(language, 0);
            }
            submissionsByLanguage[language]++;
        }

        private static void PrintResults(IOrderedEnumerable<KeyValuePair<string, int>> orderedParticipants, IOrderedEnumerable<KeyValuePair<string, int>> orderedLanguages)
        {
            Console.WriteLine("Results:");
            foreach (var participant in orderedParticipants)
            {
                Console.WriteLine($"{participant.Key} | {participant.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var language in orderedLanguages)
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
