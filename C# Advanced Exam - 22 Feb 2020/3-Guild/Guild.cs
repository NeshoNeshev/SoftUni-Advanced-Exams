using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> Players;
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Players = new List<Player>();

        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        //public List<Player> Players;
        public Player[] KickedPlayrs { get; set; }
        public int Count { get { return this.Players.Count(); } }
        public void AddPlayer(Player player)
        {
            
            if (Capacity > 0)
            {
                Players.Add(player);
            }
            this.Capacity--;
        }
        public bool RemovePlayer(string name)
        {
            var exist = Players.Where(x => x.Name == name).FirstOrDefault();
            if (exist != null)
            {
                Players.Remove(exist);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            var exist = Players.Where(x => x.Name == name).Where(r => r.Rank != "Member").FirstOrDefault();
            if (exist != null)
            {
                exist.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            var exist = Players.Where(x => x.Name == name).Where(r => r.Rank == "Member").FirstOrDefault();
            if (exist != null)
            {
                exist.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string classs)
        {

            Player[] kickedPlayers = Players.Where(c => c.Class == classs).ToArray();
            foreach (var item in kickedPlayers)
            {
                Players.Remove(item);
            }
            return kickedPlayers;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var item in Players)
            {
                sb.AppendLine(item.ToString());
            }
            

            return sb.ToString().Trim();

        }

    }
}
