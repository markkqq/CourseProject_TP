using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_TP.DataAccess.Entities
{
    public class TournamentEntity
    {
        public int ID { get; set; }
        public List<ClubEntity> Clubs { get; }
        public List<GameSessionEntity> GameSessions { get; }
        public ClubEntity Winner { get; }
        public string Name { get; set; }
    }
}
