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
        private Tournament GetTournament()
        {
            Club club1 = new();
            club1.Name = "Спартак Москва";
            club1.Players = new List<Player>()
            {
                new Player("Иван","Иванов","Иванов"){ Club = club1 },
                new Player("Петр", "Петров"){ Club = club1 },
                new Player("Андрей", "Андреев","Андреевич"){ Club = club1 }
            };

            Club club2 = new();
            club2.Name = "ЦСКА";
            club2.Players = new List<Player>()
            {
                new Player("Иван","Иванов"){ Club = club2 },
                new Player("Петр", "Петров"){ Club = club2 },
                new Player("Андрей", "Андреев","Андреевич"){ Club = club2 }
            };

            List<Club> clubs = new();
            clubs.Add(club1);
            clubs.Add(club2);

            GameSession gameSession1 = new() { Winner = club1, Date = new DateTime(1000, 2, 10), Clubs = clubs };
            GameSession gameSession2 = new() { Winner = club2, Date = new DateTime(1900, 3, 15) };
            List<GameSession> gameSessions = new() { gameSession1, gameSession2 };
            Tournament tournament = new(clubs, gameSessions, club1) {Name = "Кубок России"};
            return tournament;
        }
        public List<Tournament> GetTournaments(int count)
        {
            List<Tournament> tournaments = new();
            for(int i=0;i<count;i++)
            {
                tournaments.Add(GetTournament());
            }
            return tournaments;
        }
    }
}
