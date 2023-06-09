using System.Collections.Generic;
namespace Logic.Model
{
    public class Club
    {
        public List<Player> Players { get; set; } = new();
        public string Name { get; set; }
        public Club(string name)
        {
            Name = name;
        }
        public void AddPlayer(Player player)
        {
            player.Club = this;
            Players.Add(player);
        }
        public void AddPlayers(IEnumerable<Player> players)
        {
            foreach(var player in players)
            {
                player.Club = this;
            }
            Players.AddRange(players);
        }
    }
}