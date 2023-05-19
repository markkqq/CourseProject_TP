using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject_TP.Model;
namespace CourseProject_TP.Repositories
{
    public class TournamentRepository
    {
        public Tournament GetTournament()
        {
            Club club1 = new() { Name = "Клуб 1 " };
            Club club2 = new() { Name = "Клуб 2 " };
            List<Club> clubs = new();
            clubs.Add(club1);
            clubs.Add(club2);
            GameSession gameSession1 = new() { Winner = club1 };
            GameSession gameSession2 = new() { Winner = club2 };
            List<GameSession> gameSessions = new() { gameSession1, gameSession2 };
            Tournament tournament = new(clubs, gameSessions, club1) { Name = "турнир 1"};
            return tournament;
        }
    }
}
