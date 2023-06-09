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
    public class ClubRepository
    {
        public List<Club> GetAll(GameSession gameSession)
        {
            List<Club> clubs = new();
            using (FootballHelperDbContext db = new())
            {
                var list = db.GameSessions.Include(x => x.Clubs).ThenInclude(y => y.Players);
                foreach(var gs in list)
                {
                    if(gs.Id == gameSession.Id)
                    {
                        clubs = (from club in gs.Clubs select new Club(club.Name)
                        {
                            Players = (from player in club.Players select new Player(player.Name, player.Surname)
                            {
                                Club = new Club(club.Name)
                            }).ToList()
                        }).ToList();
                    }
                }
            }
            return new List<Club>();
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
    
        public void Delete(Club club)
        {
            using (FootballHelperDbContext db = new())
            {
                foreach(var c in db.Clubs)
                {
                    if(c.Name == club.Name)
                    {
                        db.Remove(c);
                    }
                }
            }
        }
    }
}
