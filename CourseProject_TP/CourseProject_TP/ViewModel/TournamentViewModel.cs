using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using CourseProject_TP.Model;
namespace CourseProject_TP.ViewModel
{
    public class TournamentViewModel : ViewModelBase
    {
        Tournament _tournament;
        private readonly MainWindowViewModel mwvm;
        public TournamentViewModel(Tournament tournament, MainWindowViewModel mainWindowViewModel)
        {
            _tournament = tournament;
            var gameSessionViewModels = from gameSession in tournament.GameSessions select new GameSessionViewModel(gameSession);
            GameSessions = new ObservableCollection<GameSessionViewModel>(gameSessionViewModels);
            mwvm = mainWindowViewModel;
        }
        public string Name
        {
            get { return _tournament.Name; }
            set
            {
                if (_tournament.Name == value)
                {
                    return;
                }
                _tournament.Name = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<GameSessionViewModel> GameSessions { get; set; }
    }
}
