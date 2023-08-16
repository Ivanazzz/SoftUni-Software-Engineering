using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string[] personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (personInfo[0] == "End")
                {
                    break;
                }

                string name = personInfo[0];
                string id = personInfo[1];
                int age = int.Parse(personInfo[2]);

                Person person = new Person(name, id, age);
                people.Add(person);
            }

            foreach (Person person in people.OrderBy(person => person.Age))
            {
                Console.WriteLine(person);
            }
        }
    }

    class Person
    {
        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public override string ToString() => $"{this.Name} with ID: {this.ID} is {this.Age} years old.";
    }
}
