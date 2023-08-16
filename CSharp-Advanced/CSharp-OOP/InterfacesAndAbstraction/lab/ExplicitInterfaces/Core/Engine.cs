namespace ExplicitInterfaces.Core
{
    using System.Collections.Generic;

    using Contracts;
    using Models;
    using Models.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICollection<Citizen> people;

        private Engine()
        {
            people = new HashSet<Citizen>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            CreatePeople();
            PrintPeopleInfo();
        }

        private void CreatePeople()
        {
            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split();

                string name = cmdArgs[0];
                string country = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);

                Citizen citizen = new Citizen(name, country, age);
                people.Add(citizen);
            }
        }

        private void PrintPeopleInfo()
        {
            foreach (Citizen citizen in people)
            {
                IPerson person = citizen;
                IResident resident = citizen;

                writer.WriteLine(person.GetName());
                writer.WriteLine(resident.GetName());
            }
        }
    }
}
