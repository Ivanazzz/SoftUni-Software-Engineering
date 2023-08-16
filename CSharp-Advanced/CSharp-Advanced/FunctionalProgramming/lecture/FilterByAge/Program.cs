using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people.Add(new Person(input[0], int.Parse(input[1])));
            }

            string filterInput = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string formatInput = Console.ReadLine();

            Func<Person, int, bool> filter = GetFilter(filterInput);
            people = people.Where(p => filter(p, ageFilter)).ToList();
            Action<Person> printer = GetPrinter(formatInput);
            people.ForEach(printer);
        }

        private static Func<Person, int, bool> GetFilter(string filterInput)
        {
            switch (filterInput)
            {
                case "older":
                    return (p, age) => p.Age >= age;
                case "younger":
                    return (p, age) => p.Age < age;
                default:
                    return null;
            }
        }

        private static Action<Person> GetPrinter(string formatInput)
        {
            switch (formatInput)
            {
                case "name":
                    return p => Console.WriteLine(p.Name);
                case "age":
                    return p => Console.WriteLine(p.Age);
                case "name age":
                    return p => Console.WriteLine($"{p.Name} - {p.Age}");
                default:
                    return null;
            }
        }
    }

    internal class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
