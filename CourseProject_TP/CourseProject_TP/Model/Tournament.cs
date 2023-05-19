using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_TP.Model
{
    public class Tournament
    {
        List<Club> Clubs { get; }
        List<GameSession> GameSessions { get; }
        Club Winner { get; }
        public Tournament(List<Club> clubs, List<GameSession> gameSessions, Club winner)
        {
            Clubs = clubs;
            GameSessions = gameSessions;
            Winner = winner;
        }
    }
}
