using Logic;
using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class PlayerRepository
    {
        public List<Player> GetAll(Club club)
        {
            List<Player> players = new();
            using(FootballHelperDbContext db = new())
            {
                var list = db.Clubs.Include(x => x.Players);
                var list1 = db.Clubs;
                foreach(var c in list)
                {
                    if(club.Name == c.Name)
                    {
                        players = (from p in c.Players select new Player(p.Name, p.Surname)
                        {
                            Club = club
                        }).ToList();
                    }
                }
            }
            return players;
        }

        public Player GetById(Club club, int id)
        {
            using(FootballHelperDbContext db = new())
            {
                foreach(var c in db.Clubs)
                {
                    if(club.Name == c.Name)
                    {
                        foreach(var p in c.Players)
                        {
                            if(p.Id == id)
                            {
                                return new Player(p.Name, p.Surname);
                            }
                        }
                    }
                }
            }
            return null;
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
