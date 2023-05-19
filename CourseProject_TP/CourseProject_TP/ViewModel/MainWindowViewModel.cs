using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject_TP.Model;
namespace CourseProject_TP.ViewModel
{
    public class MainWindowViewModel
    {
        public ClubViewModel Club { get; set; }
        public MainWindowViewModel()
        {
            ClubRepository clubRepository = new();
            Club club = clubRepository.GetPlayers();
            Club = new ClubViewModel(club);
        }
    }
}
