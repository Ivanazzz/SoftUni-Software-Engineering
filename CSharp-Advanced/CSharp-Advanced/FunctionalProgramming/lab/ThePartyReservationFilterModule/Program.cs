using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> peopleComing = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, Predicate<string>> allFilters = new Dictionary<string, Predicate<string>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Print")
                {
                    break;
                }

                string method = input[0];
                string operation = input[1];
                string value = input[2];

                if (method == "Add filter")
                {
                    allFilters.Add(operation + value, GetPredicate(operation, value));
                }
                else
                {
                    allFilters.Remove(operation + value);   
                }
            }

            foreach (var filter in allFilters)
            {
                peopleComing.RemoveAll(filter.Value);
            }

            Console.WriteLine(string.Join(' ', peopleComing));
        }

        private static Predicate<string> GetPredicate(string condition, string value)
        {
            if (condition == "Starts with")
            {
                return x => x.StartsWith(value);
            }
            else if (condition == "Ends with")
            {
                return x => x.EndsWith(value);
            }
            else if (condition == "Contains")
            {
                return x => x.Contains(value);
            }
            else
            {
                int valueAsInt = int.Parse(value);

                return x => x.Length == valueAsInt;
            }
        }
    }
}
