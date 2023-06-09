using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CourseProject_TP.ViewModel;
using DataAccess;
using DataAccess.Repositories;
using Logic.Model;
using DataAccess.Entities;
namespace CourseProject_TP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            using(FootballHelperDbContext db = new())
            {
                if (db.Tournaments.Count() == 0)
                {
                    PlayerRepository playerRepository = new();
                    GameSessionRepository gameSessionRepository = new();
                    ClubRepository clubRepository = new();
                    TournamentRepository tournamentRepository = new();

                    foreach (var t in Generator.GenerateTournaments())
                    {
                        if (!db.Tournaments.Contains(new TournamentEntity(t)))
                        {
                            foreach (var g in Generator.GenerateGameSessions())
                            {
                                foreach (var cl in Generator.GenerateClubs())
                                {
                                    if (!db.Clubs.Contains(new ClubEntity(cl)))
                                    {
                                        List<Player> players = Generator.GeneratePlayers();
                                        foreach (var p in players)
                                        {
                                            p.Club = cl;
                                            playerRepository.Save(p);
                                        }

                                        cl.AddPlayers(players);

                                        clubRepository.Save(cl);

                                        g.Clubs.Add(cl);
                                    }

                                }
                                gameSessionRepository.Save(g);
                                t.AddGameSession(g);
                            }
                            tournamentRepository.Save(t);
                        }
                    }
                }
            }
            MainWindow window = new();
            window.DataContext = new MainWindowViewModel();
            window.Show();
        }
    }
}
