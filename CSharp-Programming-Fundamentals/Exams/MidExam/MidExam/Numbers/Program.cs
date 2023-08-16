using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();
            while (command != "Finish")
            {
                string[] tokens = command.Split();
                string action = tokens[0];
                int value = int.Parse(tokens[1]);

                switch (action)
                {
                    case "Add":
                        numbers.Add(value);
                        break;
                    case "Remove":
                        numbers.Remove(value);
                        break;
                    case "Replace":
                        int replacement = int.Parse(tokens[2]);

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] == value)
                            {
                                numbers[i] = replacement;
                                break;
                            }
                        }
                        break;
                    case "Collapse":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] < value)
                            {
                                numbers.Remove(numbers[i]);
                                i--;
                            }
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
