namespace BorderControl.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using IO.Contracts;
    using Contracts;
    using BorderControl.Models;
    using BorderControl.Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICollection<IIDable> idables;

        private Engine()
        {
            idables = new HashSet<IIDable>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            CreateIdeable();

            string idEndDigits = reader.ReadLine();

            ICollection<string> fakeIDs = TakeFakeIDs(idEndDigits);

            PrintFakeIDs(fakeIDs);
        }

        private void CreateIdeable()
        {
            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split();

                IIDable idable = null;
                if (cmdArgs.Length == 3)
                {
                    string citizenName = cmdArgs[0];
                    int citizenAge = int.Parse(cmdArgs[1]);
                    string citizenID = cmdArgs[2];

                    idable = new Citizen(citizenName, citizenAge, citizenID);
                }
                else
                {
                    string robotModel = cmdArgs[0];
                    string robotID = cmdArgs[1];

                    idable = new Robot(robotModel, robotID);
                }

                idables.Add(idable);
            }
        }

        private ICollection<string> TakeFakeIDs(string idEndDigits)
        {
            ICollection<string> fakeIDs = idables
            .Where(i => i.Id.EndsWith(idEndDigits))
            .Select(i => i.Id)
            .ToHashSet();

            return fakeIDs;
        }

        private void PrintFakeIDs(ICollection<string> fakeIDs)
        {
            if (fakeIDs.Any())
            {
                foreach (string id in fakeIDs)
                {
                    writer.WriteLine(id);
                }
            }
        }
    }
}
