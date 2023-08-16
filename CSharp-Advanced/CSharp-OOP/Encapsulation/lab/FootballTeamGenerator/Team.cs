using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> playerList;

        private Team()
        {
            playerList = new List<Player>();
        }

        public Team(string name)
            : this()
        {
            Name = name;
        }

        public string Name 
        { 
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.NameCannotBeNullOrWhitespace);
                }

                name = value;
            }
        }

        public int Rating
            => playerList.Any() ? 
            (int)Math.Round(playerList.Average(p => p.OverallRating), 0) :
            0;

        public void AddPlayer(Player player)
        {
            playerList.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = playerList.FirstOrDefault(p => p.Name == playerName);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PlayerIsMissing, playerName, Name));
            }

            playerList.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }
    }
}
