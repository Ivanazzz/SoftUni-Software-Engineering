using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        private static List<Team> teams;

        static void Main(string[] args)
        {
            teams = new List<Team>();

            RunEngine();
        }

        public static void RunEngine()
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(';');
                string action = commandArgs[0];
                string teamName = commandArgs[1];

                try
                {
                    switch (action)
                    {
                        case "Team":
                            AddNewTeam(teamName);
                            break;
                        case "Add":
                            AddPlayerToTeam(teamName, commandArgs);
                            break;
                        case "Remove":
                            RemovePlayerFromTeam(teamName, commandArgs[2]);
                            break;
                        case "Rating":
                            RateTeam(teamName);
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }

        public static void AddNewTeam(string teamName)
        {
            Team newTeam = new Team(teamName);
            teams.Add(newTeam);
        }

        public static void AddPlayerToTeam(string teamName, string[] commandArgs)
        {
            Team joiningTeam = teams
                            .FirstOrDefault(t => t.Name == teamName);

            if (joiningTeam == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistingTeam, teamName));
            }

            Player joiningPlayer = CreateNewPlayer(commandArgs);
            joiningTeam.AddPlayer(joiningPlayer);
        }

        public static Player CreateNewPlayer(string[] commandArgs)
        {
            string playerName = commandArgs[2];
            int endurance = int.Parse(commandArgs[3]);
            int sprint = int.Parse(commandArgs[4]);
            int dribble = int.Parse(commandArgs[5]);
            int passing = int.Parse(commandArgs[6]);
            int shooting = int.Parse(commandArgs[7]);

            Player newPlayer = new Player(playerName, endurance, sprint, dribble, passing, shooting);

            return newPlayer;
        }

        public static void RemovePlayerFromTeam(string teamName, string playerName)
        {
            Team removingTeam = teams
                            .FirstOrDefault(t => t.Name == teamName);

            if (removingTeam == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistingTeam, teamName));
            }

            removingTeam.RemovePlayer(playerName);
        }

        public static void RateTeam(string teamName)
        {
            Team teamToRate = teams
                            .FirstOrDefault(t => t.Name == teamName);

            if (teamToRate == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistingTeam, teamName));
            }

            Console.WriteLine(teamToRate);
        }
    }
}
