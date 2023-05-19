using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_TP.Model
{
    public class Tournament
    {
        public List<Club> Clubs { get; }
        public List<GameSession> GameSessions { get; }
        public Club Winner { get; }
        public string Name { get; set; }
        public Tournament(List<Club> clubs, List<GameSession> gameSessions, Club winner)
        {
            Clubs = clubs;
            GameSessions = gameSessions;
            Winner = winner;
        }
    }
}
