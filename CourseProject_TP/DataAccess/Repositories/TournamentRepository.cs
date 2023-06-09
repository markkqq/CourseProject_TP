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
                var list = db.Tournaments.Include(x => x.GameSessions).ThenInclude(y => y.Clubs).ThenInclude(z => z.Players);
                tournaments = (from tournament in list select new Tournament()
                {
                    Name = tournament.Name,
                    GameSessions = (from gamesession in tournament.GameSessions select new GameSession()
                    {
                        Clubs = (from club in gamesession.Clubs select new Club(club.Name) 
                        {
                            Players = (from player in club.Players select new Player(player.Name, player.Surname) {
                             Club = new Club(club.Name)
                            })
                            .ToList()
                        }
                        
                        ).ToList()
                        ,
                        FirstClubResult = gamesession.FirstClubResult,
                        SecondClubResult = gamesession.SecondClubResult,
                        Id = gamesession.Id
                    }).ToList()
                }).ToList();
            }
            return tournaments;
        }

        public Tournament GetById(int id)
        {
            using(FootballHelperDbContext db = new())
            {
                foreach(var t in db.Tournaments)
                {
                    if(t.Id == id)
                    {
                        return new Tournament()
                        {
                            Name = t.Name,
                            GameSessions = (from gamesession in t.GameSessions
                                            select new GameSession()
                                            {
                                                Clubs = (from club in gamesession.Clubs
                                                         select new Club(club.Name)
                                                         {
                                                             Players = (from player in club.Players select new Player(player.Name, player.Surname)).ToList()
                                                         }).ToList()
                                            }).ToList()
                        };
                    }
                }
            }
            return null;
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
