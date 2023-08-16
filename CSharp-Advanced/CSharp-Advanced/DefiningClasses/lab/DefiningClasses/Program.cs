using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family familyMembers = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(input[0], int.Parse(input[1]));
                familyMembers.AddMember(person);
            }

            List<Person> sortedFamilyMembers = familyMembers.SortFamilyMembers();

            foreach (Person person in sortedFamilyMembers)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
