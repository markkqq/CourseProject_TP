using System;
using System.Collections.ObjectModel;
using Logic.Model;
using System.Linq;
using System.Windows.Input;

namespace CourseProject_TP.ViewModel
{
    public class GameSessionViewModel : ViewModelBase
    {
        private GameSession gameSession;
        private MainWindowViewModel mwvm;
        private TournamentViewModel tournamentViewModel;
        private ClubViewModel selectedClub;
        public GameSessionViewModel(GameSession gameSession, TournamentViewModel tournamentViewModel, MainWindowViewModel mainWindowViewModel)
        {
            this.gameSession = gameSession;
            this.tournamentViewModel = tournamentViewModel;
            var clubViewModels = from club in gameSession.Clubs select new ClubViewModel(club,this,mainWindowViewModel);
            Clubs = new ObservableCollection<ClubViewModel>(clubViewModels);
            mwvm = mainWindowViewModel;
        }
        
        public string Opponents
        {
            get => $"Команда ||{gameSession.Clubs[0].Name}|| против Команда ||{gameSession.Clubs[1].Name}||";
        }
        public ObservableCollection<ClubViewModel> Clubs { get; set; }

        public ICommand ShowParticipant
        {
            get
            {
                return new RelayCommand
                    (
                        (_) => ShowParticipantImplemention(),
                        (_) => CanShowParticipant()
                    );
            }
        }
        public ClubViewModel SelectedClub
        {
            get => selectedClub;
            set
            {
                if (selectedClub == value) return;
                selectedClub = value;
                OnPropertyChanged();
            }
        }
        private bool CanShowParticipant()
        {
            return selectedClub != null;
        }

        private void ShowParticipantImplemention()
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