using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<string>> userBySide = new SortedDictionary<string, SortedSet<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Lumpawaroo")
                {
                    break;
                }

                if (input.Contains('|'))
                {
                    string[] tokensToAdd = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string side = tokensToAdd[0];
                    string user = tokensToAdd[1];

                    if (!userBySide.Values.Any(u => u.Contains(user)))
                    {
                        if (!userBySide.ContainsKey(side))
                        {
                            userBySide.Add(side, new SortedSet<string>());
                        }

                        userBySide[side].Add(user);
                    }
                }
                else
                {
                    string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string user = tokens[0];
                    string side = tokens[1];

                    foreach (var forceSide in userBySide)
                    {
                        if (forceSide.Value.Contains(user))
                        {
                            forceSide.Value.Remove(user);
                            break;
                        }
                    }

                    if (!userBySide.ContainsKey(side))
                    {
                        userBySide.Add(side, new SortedSet<string>());
                    }

                    userBySide[side].Add(user);
                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            var orderedSidesUsers = userBySide.OrderByDescending(p => p.Value.Count);

            foreach (var side in orderedSidesUsers)
            {
                if (side.Value.Any())
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                    foreach (var user in side.Value)
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}
