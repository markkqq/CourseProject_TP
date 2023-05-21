using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using CourseProject_TP.Model;
namespace CourseProject_TP.ViewModel
{
    public class TournamentViewModel : ViewModelBase
    {
        Tournament _tournament;
        private readonly MainWindowViewModel mwvm;
        private GameSessionShortViewModel selectedGameSession;
        public TournamentViewModel(Tournament tournament, MainWindowViewModel mainWindowViewModel)
        {
            _tournament = tournament;
            var gameSessionViewModels = from gameSession in tournament.GameSessions select new GameSessionShortViewModel(gameSession);
            GameSessions = new ObservableCollection<GameSessionShortViewModel>(gameSessionViewModels);
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
        public ObservableCollection<GameSessionShortViewModel> GameSessions { get; set; }

        public ICommand ShowGameSession
        {
            get
            {
                return new RelayCommand
                    (
                        (_) => ShowGameSessionImplemention(),
                        (_) => CanShowGameSession()
                    );
            }
        }
        public GameSessionShortViewModel SelectedGameSession
        {
            get => selectedGameSession;
            set
            {
                if (selectedGameSession == value) return;
                selectedGameSession = value;
                OnPropertyChanged();
            }
        }
        private bool CanShowGameSession()
        {
            return selectedGameSession != null;
        }

        private void ShowGameSessionImplemention()
        {
            GameSession gameSession = _tournament.GameSessions.First(x => $"{x.Date.Year}, {x.Date.Month}" == selectedGameSession.Date);
            mwvm.Content = new GameSessionViewModel(gameSession,this,mwvm);
        }
    }
}
