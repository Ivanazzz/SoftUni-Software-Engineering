using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return roster.Count; } }

        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player playerToRemove = roster.FirstOrDefault(p => p.Name == name);

            if (playerToRemove != null)
            {
                roster.Remove(playerToRemove);

                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            Player playerToPromote = roster.FirstOrDefault(p => p.Name == name);
            playerToPromote.Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            Player playerToDemote = roster.FirstOrDefault(p => p.Name == name);
            playerToDemote.Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] removedPlayers = roster.Where(p => p.Class == @class).ToArray();
            roster.RemoveAll(p => p.Class == @class);

            return removedPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");

            foreach (Player player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
