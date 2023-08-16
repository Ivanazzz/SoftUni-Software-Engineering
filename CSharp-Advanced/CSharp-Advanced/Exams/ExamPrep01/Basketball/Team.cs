using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private Dictionary<string, Player> players;

        public Team(string name, int openPositions, char group)
        {
            this.Name = name;
            this.OpenPositions = openPositions;
            this.Group = group;
            players = new Dictionary<string, Player>();
        }

        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count { get { return players.Count; } }

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            else if (this.OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }
            else
            {
                this.OpenPositions--;
                this.players.Add(player.Name, player);
                return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
            }
        }

        public bool RemovePlayer(string name)
        {
            if (players.ContainsKey(name))
            {
                players.Remove(name);
                this.OpenPositions++;
                return true;
            }

            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int removedPlayersCount = 0;
            foreach (Player player in players.Values)
            {
                if (player.Position == position)
                {
                    removedPlayersCount++;
                    this.OpenPositions++;
                    players.Remove(player.Name);
                }
            }

            if (removedPlayersCount != 0)
            {
                return removedPlayersCount;
            }

            return 0;
        }

        public Player RetirePlayer(string name)
        {
            if (players.ContainsKey(name))
            {
                players[name].Retired = true;
                return players[name];
            }

            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> awardPlayers = new List<Player>();

            foreach (var player in players.Where(p => p.Value.Games >= games))
            {
                awardPlayers.Add(player.Value);
            }

            return awardPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");

            foreach (var player in players.Where(p => p.Value.Retired == false))
            {
                sb.AppendLine(player.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
