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
                PlayerRepository playerRepository = new();
                GameSessionRepository gameSessionRepository = new();
                ClubRepository clubRepository = new();
                TournamentRepository tournamentRepository = new();

                foreach(var t in Generator.GenerateTournaments())
                {
                    foreach(var g in Generator.GenerateGameSessions())
                    {
                        t.AddGameSession(g);
                        foreach(var cl in Generator.GenerateClubs())
                        {
                            List<Player> players = Generator.GeneratePlayers();
                            foreach(var p in players)
                            {
                                p.Club = cl;
                                playerRepository.Save(p);
                            }
                            cl.AddPlayers(players);
                            
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
