using System.Collections.Generic;
namespace CourseProject_TP.Model
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
            Players.AddRange(players);
        }
    }
}