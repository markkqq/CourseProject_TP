using System;
using System.Collections.ObjectModel;
using Logic.Model;
using System.Linq;
using System.Windows.Input;
using DataAccess.Repositories;

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

        public string Result
        {
            get => $"Результат игры - {gameSession.FirstClubResult}:{gameSession.SecondClubResult}";
        }

        public ObservableCollection<ClubViewModel> Clubs { get; set; }

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
        public string Winner
        {
            get
            {
                if (gameSession.FirstClubResult > gameSession.SecondClubResult)
                {
                    return $"Победила команда {gameSession.Clubs[0].Name}";
                }
                else if(gameSession.FirstClubResult < gameSession.SecondClubResult)
                {
                    return $"Победила команда {gameSession.Clubs[1].Name}";
                }
                else
                {
                    return "Ничья";
                }
            }
            set
            {

            }
        }
        private void ReturnImplemention()
        {
            mwvm.Content = tournamentViewModel;
        }
    }
}