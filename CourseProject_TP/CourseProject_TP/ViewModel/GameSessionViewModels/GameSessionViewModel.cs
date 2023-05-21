using CourseProject_TP.Model;
using CourseProject_TP.ViewModel.ClubViewModels;
using System;
using System.Collections.ObjectModel;

using System.Linq;
using System.Windows.Input;

namespace CourseProject_TP.ViewModel
{
    public class GameSessionViewModel : ViewModelBase
    {
        private GameSession gameSession;
        private MainWindowViewModel mwvm;
        private TournamentViewModel tournamentViewModel;
        private ClubShortViewModel selectedClub;
        public GameSessionViewModel(GameSession gameSession, TournamentViewModel tournamentViewModel, MainWindowViewModel mainWindowViewModel)
        {
            this.gameSession = gameSession;
            this.tournamentViewModel = tournamentViewModel;
            var clubViewModels = from club in gameSession.Clubs select new ClubShortViewModel(club);
            Clubs = new ObservableCollection<ClubShortViewModel>(clubViewModels);
            mwvm = mainWindowViewModel;
        }
        
        public string Winner 
        {
            get => $"Победитель - {gameSession.Winner.Name}";
            set
            {
                if (gameSession.Winner.Name == value) return;

                gameSession.Winner.Name = value;
                OnPropertyChanged();
            }
        }
        public string Date
        {
            get => $"{gameSession.Date.Year} год, месяц {gameSession.Date.Month}.";
            
        }
        public string Opponents
        {
            get => $" {gameSession.Clubs[0].Name} - {gameSession.Clubs[1].Name}.";

        }
        public ObservableCollection<ClubShortViewModel> Clubs { get; set; }

        public ICommand ShowClub
        {
            get
            {
                return new RelayCommand
                    (
                        (_) => ShowClubImplemention(),
                        (_) => CanShowClub()
                    );
            }
        }
        public ClubShortViewModel SelectedClub
        {
            get => selectedClub;
            set
            {
                if (selectedClub == value) return;
                selectedClub = value;
                OnPropertyChanged();
            }
        }
        private bool CanShowClub()
        {
            return selectedClub != null;
        }

        private void ShowClubImplemention()
        {
            Club club = gameSession.Clubs.First(x => x.Name == selectedClub.Name);
            mwvm.Content = new ClubViewModel(club, this, mwvm);
        }

        public ICommand ReturnToPreviousPage
        {
            get => new RelayCommand
                (
                (_) => ReturnImplemention()
                );
        }

        private void ReturnImplemention()
        {
            mwvm.Content = tournamentViewModel;
        }
    }
}