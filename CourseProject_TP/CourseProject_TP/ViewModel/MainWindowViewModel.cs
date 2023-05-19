using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject_TP.Model;
using CourseProject_TP.Repositories;
namespace CourseProject_TP.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            TournamentRepository tournamentRepository = new();
            content = new TournamentViewModel(tournamentRepository.GetTournament(),this);
        }
        private ViewModelBase content;
        public ViewModelBase Content
        {
            get => content;
            set
            {
                if(content==value)
                {
                    return;
                }
                content = value;
                OnPropertyChanged();
            }
        }
    }
}
