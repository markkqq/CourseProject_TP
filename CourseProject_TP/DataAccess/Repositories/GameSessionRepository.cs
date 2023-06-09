using Logic;
using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
namespace DataAccess.Repositories
{
    public class GameSessionRepository : IRepository<GameSession>
    {
        public List<GameSession> GetAll()
        {
            throw new NotImplementedException();
        }

        public GameSession GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(GameSession item)
        {
            using (FootballHelperDbContext db = new())
            {
                db.GameSessions.Add(new GameSessionEntity(item));
                db.SaveChanges();
            }
        }
    }
}
