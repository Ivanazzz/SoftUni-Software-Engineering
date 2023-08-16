using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    internal class Family
    {
        public Family()
        {
            FamilyMembers = new List<Person>();
        }

        private List<Person> familyMembers;

        public List<Person> FamilyMembers { get { return this.familyMembers; } set { this.familyMembers = value; } }

        public void AddMember(Person person)
        {
            this.FamilyMembers.Add(person);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = FamilyMembers
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();

            return oldestPerson;
        }

        public List<Person> SortFamilyMembers()
        {
            List<Person> sortedMembers = FamilyMembers
                .OrderBy(p => p.Name)
                .Where(x => x.Age > 30)
                .ToList();

            return sortedMembers;
        }
    }
}
