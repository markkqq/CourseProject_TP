using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Entities;
using Logic;
using Logic.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class TournamentRepository : IRepository<Tournament>
    {
        public int Id { get; set; }

        public List<Tournament> GetAll()
        {
            List<Tournament> tournaments = new();
            using (FootballHelperDbContext db = new())
            {
                
            }
            return tournaments;
        }

        public Tournament GetById(int id)
        {
            using(FootballHelperDbContext db = new())
            {

                return null;
            }
        }
        public void Save(Tournament item)
        {
            using (FootballHelperDbContext db = new())
            {
                db.Tournaments.Add(new TournamentEntity(item));
                db.SaveChanges();
            }

        }

    }

}
