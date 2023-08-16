namespace MilitaryElite.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using MilitaryElite.IO.Contracts;
    using MilitaryElite.Models;
    using MilitaryElite.Models.Contracts;
    using MilitaryElite.Models.Enums;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICollection<ISoldier> allSoldiers;

        private Engine()
        {
            allSoldiers = new HashSet<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            CreateSoldiers();
            PrintSoldiers();
        }

        private void CreateSoldiers()
        {
            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split();

                string soldierType = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];

                ISoldier soldier;
                switch (soldierType)
                {
                    case "Private":
                        decimal salaryP = decimal.Parse(cmdArgs[4]);
                        soldier = new Private(id, firstName, lastName, salaryP);
                        break;
                    case "LieutenantGeneral":
                        decimal salaryL = decimal.Parse(cmdArgs[4]);
                        ICollection<IPrivate> privates = FindPrivates(cmdArgs);

                        soldier = new LieutenantGeneral(id, firstName, lastName, salaryL, privates);
                        break;
                    case "Engineer":
                        decimal salaryE = decimal.Parse(cmdArgs[4]);
                        string corpsText = cmdArgs[5];
                        Corps corps;
                        bool isCorpsValid = Enum.TryParse<Corps>(corpsText, false, out corps);

                        if (!isCorpsValid)
                        {
                            continue;
                        }

                        ICollection<IRepair> repairs = CreateRepairs(cmdArgs);
                        soldier = new Engineer(id, firstName, lastName, salaryE, corps, repairs);
                        break;
                    case "Commando":
                        decimal salaryC = decimal.Parse(cmdArgs[4]);
                        string corpsTextC = cmdArgs[5];
                        Corps corpsC;
                        bool isCorpsValidC = Enum.TryParse<Corps>(corpsTextC, false, out corpsC);

                        if (!isCorpsValidC)
                        {
                            continue;
                        }

                        ICollection<IMission> missions = CreateMisssions(cmdArgs);
                        soldier = new Commando(id, firstName, lastName, salaryC, corpsC, missions);
                        break;
                    case "Spy":
                        int codeNumber = int.Parse(cmdArgs[4]);
                        soldier = new Spy(id, firstName, lastName, codeNumber);
                        break;
                    default:
                        continue;
                }

                allSoldiers.Add(soldier);
            }
        }

        private ICollection<IPrivate> FindPrivates(string[] cmdArgs)
        {
            int[] privatesIds = cmdArgs
                .Skip(5)
                .Select(int.Parse)
                .ToArray();

            ICollection<IPrivate> privates = new HashSet<IPrivate>();

            foreach (int privateId in privatesIds)
            {
                IPrivate currentPrivate = (IPrivate)allSoldiers
                    .FirstOrDefault(s => s.Id == privateId);

                privates.Add(currentPrivate);
            }

            return privates;
        }

        private ICollection<IRepair> CreateRepairs(string[] cmdArgs)
        {
            ICollection<IRepair> repairs = new HashSet<IRepair>();

            string[] repairsInfo = cmdArgs
                .Skip(6)
                .ToArray();

            for (int i = 0; i < repairsInfo.Length; i += 2)
            {
                string partName = repairsInfo[i];
                int hoursWorked = int.Parse(repairsInfo[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);
                repairs.Add(repair);
            }

            return repairs;
        }

        private ICollection<IMission> CreateMisssions(string[] cmdArgs)
        {
            ICollection<IMission> missions = new HashSet<IMission>();

            string[] missionsInfo = cmdArgs
                .Skip(6)
                .ToArray();

            for (int i = 0; i < missionsInfo.Length; i += 2)
            {
                string codeName = missionsInfo[i];
                string stateText = missionsInfo[i + 1];

                bool isStateValid = Enum.TryParse<State>(stateText, false, out State state);

                if (!isStateValid)
                {
                    continue;
                }

                IMission mission = new Mission(codeName, state);
                missions.Add(mission);
            }

            return missions;
        }

        private void PrintSoldiers()
        {
            foreach (ISoldier soldier in allSoldiers)
            {
                writer.WriteLine(soldier.ToString());
            }
        }
    }
}
