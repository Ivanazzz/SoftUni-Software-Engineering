using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamsCount; i++)
            {
                string[] line = Console.ReadLine().Split("-");
                string creator = line[0];
                string nameOfTeam = line[1];

                if (teams.Any(team => team.TeamsName == nameOfTeam))
                {
                    Console.WriteLine($"Team {nameOfTeam} was already created!");
                    continue;
                }
                if (teams.Any(team => team.CreatorsName == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                List<string> participants = new List<string>();
                Team team = new Team(creator, nameOfTeam, participants);
                teams.Add(team);
                Console.WriteLine($"Team {nameOfTeam} has been created by {creator}!");
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split("->");
                if (tokens[0] == "end of assignment")
                {
                    break;
                }

                string user = tokens[0];
                string teamToJoin = tokens[1];

                if (!teams.Any(currentTeam => currentTeam.TeamsName == teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                    continue;
                }
                if (teams.Any(member => member.Participants.Contains(user)) ||
                    teams.Any(member => member.CreatorsName == user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamToJoin}!");
                    continue;
                }

                var currentTeam = teams.Find(team => team.TeamsName == teamToJoin);
                currentTeam.Participants.Add(user);
            }

            var completedTeams = teams.Where(x => x.Participants.Count > 0);
            var disbandTeams = teams.Where(x => x.Participants.Count == 0);

            foreach (var team in completedTeams.OrderByDescending(x => x.Participants.Count).ThenBy(y => y.TeamsName))
            {
                Console.WriteLine($"{team.TeamsName}");
                Console.WriteLine($"- {team.CreatorsName}");
                foreach (var member in team.Participants.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (var team in disbandTeams.OrderBy(x => x.Participants.Count).ThenBy(y => y.TeamsName))
            {
                Console.WriteLine($"{team.TeamsName}");
            }
        }
    }

    class Team
    {
        public Team(string creatorsName, string teamsName, List<string> participants)
        {
            this.CreatorsName = creatorsName;
            this.TeamsName = teamsName;
            this.Participants = participants;
        }

        public string CreatorsName { get; set; }
        public string TeamsName { get; set; }
        public List<string> Participants { get; set; }
    }
}
