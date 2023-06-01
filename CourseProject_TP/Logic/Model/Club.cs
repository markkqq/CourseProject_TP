using System.Collections.Generic;
namespace CourseProject_TP.Logic.Model
{
    public class Club
    {
        public List<Player> Players { get; set; } = new();
        public string Name { get; set; }
        public void AddPlayer(Player player)
        {
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