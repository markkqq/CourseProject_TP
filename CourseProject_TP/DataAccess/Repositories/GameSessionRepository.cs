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
    public class GameSessionRepository
    {
        public List<GameSession> GetAll(Tournament tournament)
        {
            List<GameSession> gameSessions= new();
            using (FootballHelperDbContext db = new())
            {
                var list = db.Tournaments.Include(x => x.GameSessions).ThenInclude(z => z.Clubs).ThenInclude(w => w.Players);
                foreach (var t in list)
                {
                    if (tournament.Name == t.Name)
                    {
                        gameSessions = (from g in t.GameSessions select new GameSession()
                        {
                            FirstClubResult = g.FirstClubResult,
                            SecondClubResult = g.SecondClubResult,
                            Tournament = tournament,
                            Clubs = (from club in g.Clubs select new Club(club.Name)
                            {
                                Players = (from player in club.Players select new Player(player.Name, player.Surname)
                                {
                                    Club = new Club(club.Name)
                                }).ToList()
                            }).ToList()

                        }).ToList();
                    }
                }
            }
            return gameSessions;
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
