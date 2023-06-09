using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Entities;
using Logic.Model;
using Logic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ClubRepository : IRepository<Club>
    {
        public List<Club> GetAll()
        {
            using (FootballHelperDbContext db = new())
            {
                var c = db.Clubs;
                return (from club in c select new Club(club.Name) 
                { 
                    Players = (from player in club.Players select new Player(player.Name, player.Surname) 
                    {
                        Club = new Club(club.Name) }
                    )
                    .ToList() 
                })
                .ToList();
            }
        }

        public Club GetById(int id)
        {
            using (FootballHelperDbContext db = new())
            {
                var clubs = db.Clubs;
                foreach(var club in clubs)
                {
                    if (club.Id == id)
                    {
                        return new Club(club.Name) { Players = (from player in club.Players select new Player(player.Name, player.Surname) { Club = new Club(club.Name) }).ToList() };
                    }
                }
            }
            return null;
        }

        public void Save(Club club)
        {
            using(FootballHelperDbContext db = new())
            {
                db.Clubs.Add(new ClubEntity(club));
                db.SaveChanges();
            }
        }
    }
}
