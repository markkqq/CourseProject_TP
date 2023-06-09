using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class Tournament
    {
        public List<Club> Clubs { get; set; } = new List<Club>();
        public List<GameSession> GameSessions { get; set; } = new List<GameSession>();
        public string Name { get; set; }
        public Tournament()
        {

        }
        public void AddGameSession(GameSession gameSession)
        {
            gameSession.Tournament = this;
            GameSessions.Add(gameSession);
        }
    }
}
