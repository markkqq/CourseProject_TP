using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject_TP.Logic.Model;
namespace CourseProject_TP
{
    public class ClubRepository
    {
        public Club GetClub()
        {
            List<Player> players = new();
            Player player1 = new("mark", "mirk");
            Player player2 = new("mork", "murk");
            Player player3 = new("merk", "myrk");
            players.Add(player3);
            players.Add(player2);
            players.Add(player1);
            Club club = new() { Name="клуб 1" };
            club.AddPlayers(players);
            return club;
        }
    }
}
