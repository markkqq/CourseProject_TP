using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using CourseProject_TP.Logic.Model;
namespace CourseProject_TP.ViewModel
{
    public class TournamentViewModel : ViewModelBase
    {
        Tournament _tournament;
        private readonly MainWindowViewModel mwvm;
        private GameSessionViewModel selectedGameSession;
        private StartViewModel startViewModel;
        public TournamentViewModel(Tournament tournament, StartViewModel startViewModel, MainWindowViewModel mainWindowViewModel)
        {
            _tournament = tournament;
            this.startViewModel = startViewModel;
            var gameSessionViewModels = from gameSession in tournament.GameSessions select new GameSessionViewModel(gameSession,this,mainWindowViewModel);
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
        public GameSessionViewModel SelectedGameSession
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
            GameSession gameSession = _tournament.GameSessions.First(x => $"{x.Date.Year} год, месяц {x.Date.Month}." == SelectedGameSession.Date);
            mwvm.Content = new GameSessionViewModel(gameSession,this,mwvm);
        }

        public ICommand ReturnToPreviousPage
        {
            get => new RelayCommand
                (
                    (_) => ReturnImplemention()
                );
        }
        public void ReturnImplemention()
        {
            mwvm.Content = startViewModel; 
        }
    }
}
