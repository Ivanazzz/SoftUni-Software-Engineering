using System;
using System.Collections.Generic;
using System.Linq;

namespace OldestFamilyMember
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var currentFamily =  new Family();

            int numberOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personInfo = Console.ReadLine().Split();

                Person member = new Person(personInfo[0], int.Parse(personInfo[1]));
                currentFamily.AddMember(member);
            }

            if (currentFamily.FamilyList.Count > 0)
            {
                currentFamily.GetOldestMember(currentFamily);
            }
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Family
    {
        public Family()
        {
            this.FamilyList = new List<Person>();
        }

        public List<Person> FamilyList { get; set; }

        public void AddMember(Person member)
        {
            FamilyList.Add(member);
        }

        public Person GetOldestMember(List<Person> familyList)

        {

            var oldestPerson = familyList.OrderByDescending(x.Age => x.Age).FirstOrDefault();

            return oldestPerson;

        }
    }
}
