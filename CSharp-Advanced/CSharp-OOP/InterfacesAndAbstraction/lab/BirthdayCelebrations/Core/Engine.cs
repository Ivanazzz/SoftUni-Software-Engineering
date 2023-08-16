namespace BirthdayCelebrations.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using IO.Contracts;
    using Contracts;
    using BirthdayCelebrations.Models;
    using BirthdayCelebrations.Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICollection<IBirthdateable> birthdateables;

        private Engine()
        {
            birthdateables = new HashSet<IBirthdateable>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            CreateBirthdateables();

            string year = reader.ReadLine();
            ICollection<string> years = TakeYears(year);

            PrintYears(years);
        }

        private void CreateBirthdateables()
        {
            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split();

                string birthdateableType = cmdArgs[0];

                IBirthdateable birthdateable = null;
                switch (birthdateableType)
                {
                    case "Citizen":
                        string citizenName = cmdArgs[1];
                        int citizenAge = int.Parse(cmdArgs[2]);
                        string citizenID = cmdArgs[3];
                        string citizenBirthdate = cmdArgs[4];

                        birthdateable = new Citizen(citizenName, citizenAge, citizenID, citizenBirthdate);
                        break;
                    case "Pet":
                        string petName = cmdArgs[1];
                        string petBirthdate = cmdArgs[2];

                        birthdateable = new Pet(petName, petBirthdate);
                        break;
                }

                if (birthdateable != null)
                {
                    birthdateables.Add(birthdateable);
                }
            }
        }

        private ICollection<string> TakeYears(string year)
        {
            ICollection<string> years = birthdateables
            .Where(b => b.Birthdate.EndsWith(year))
            .Select(b => b.Birthdate)
            .ToList();

            return years;
        }

        private void PrintYears(ICollection<string> years)
        {
            if (years.Any())
            {
                foreach (string year in years)
                {
                    writer.WriteLine(year);
                }
            }
        }
    }
}
