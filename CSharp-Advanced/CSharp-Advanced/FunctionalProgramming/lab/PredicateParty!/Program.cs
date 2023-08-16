using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> peopleComing = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "Party!")
                {
                    break;
                }

                string action = command[0];
                string condition = command[1];
                string value = command[2];

                if (action == "Double")
                {
                    List<string> doubleNames =  peopleComing.FindAll(GetPredicate(condition, value));

                    if (doubleNames.Any())
                    {
                        int index = peopleComing.FindIndex(GetPredicate(condition, value));
                        peopleComing.InsertRange(index, doubleNames);
                    }
                }
                else
                {
                    peopleComing.RemoveAll(GetPredicate(condition, value));
                }
            }

            if (peopleComing.Any())
            {
                Console.WriteLine($"{string.Join(", ", peopleComing)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string condition, string value)
        {
            if (condition == "StartsWith")
            {
                return x => x.StartsWith(value);
            }
            else if (condition == "EndsWith")
            {
                return x => x.EndsWith(value);
            }
            else
            {
                int valueAsInt = int.Parse(value);

                return x => x.Length == valueAsInt;
            }
        }
    }
}
