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
    public class PlayerRepository : IRepository<Player>
    {
        public List<Player> GetAll()
        {
            throw new NotImplementedException();
        }

        public Player GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Player item)
        {
            using(FootballHelperDbContext db = new())
            {
                db.Players.Add(new PlayerEntity(item));
                db.SaveChanges();
            }
        }
    }
}
