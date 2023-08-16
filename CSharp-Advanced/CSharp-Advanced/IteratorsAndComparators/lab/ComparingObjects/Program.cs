using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                
                Person person = new Person
                {
                    Name = tokens[0],
                    Age = int.Parse(tokens[1]),
                    Town = tokens[2]
                };

                people.Add(person);
            }

            int compareIndex = int.Parse(Console.ReadLine()) - 1;

            Person personToCompare = people[compareIndex];

            int equalCount = 0;
            int differentCount = 0;

            foreach (Person person in people)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    equalCount++;
                }
                else
                {
                    differentCount++;
                }
            }

            if (equalCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalCount} {differentCount} {people.Count}");
            }
        }
    }
}
