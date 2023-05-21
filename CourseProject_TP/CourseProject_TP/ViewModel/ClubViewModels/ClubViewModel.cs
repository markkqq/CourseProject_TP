using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject_TP.Model;
using CourseProject_TP.ViewModel.PlayerViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CourseProject_TP.ViewModel
{
    public class ClubViewModel : ViewModelBase
    {
        Club club;
        private readonly MainWindowViewModel mwvm;
        private PlayerShortViewModel selectedPlayer;
        private GameSessionViewModel gameSessionViewModel;
        public ClubViewModel(Club club, GameSessionViewModel gameSessionViewModel, MainWindowViewModel mainWindowViewModel)
        {
            this.club = club;
            this.gameSessionViewModel = gameSessionViewModel;
            var playerViewModels = from player in club.Players select new PlayerShortViewModel(player);
            Players = new ObservableCollection<PlayerShortViewModel>(playerViewModels);
            mwvm = mainWindowViewModel;
        }
        public string Name
        {
            get { return club.Name; }
            set
            {
                if(club.Name == value)
                {
                    return;
                }
                club.Name = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<PlayerShortViewModel> Players { get; set; }

        public PlayerShortViewModel SelectedPlayer
        {
            get => selectedPlayer;
            set
            {
                if (selectedPlayer == value) return;
                selectedPlayer = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowPlayer
        {
            get
            {
                return new RelayCommand
                (
                    (_) => ShowPlayerImplemention(),
                    (_) => CanShowPlayer()
                );
            }
        }
        public bool CanShowPlayer()
        {
            return selectedPlayer != null;
        }

        public void ShowPlayerImplemention()
        {
            Player player = club.Players.First(x => $"{x.Name} {x.Surname}" == SelectedPlayer.PersonDetails);
            mwvm.Content = new PlayerViewModel(player,this, mwvm);
        }
        public ICommand ReturnToPreviousPage
        {
            get
            {
                return new RelayCommand
                    (
                        (_) => ReturnImplemention()
                    );
            }
        }
        private void ReturnImplemention()
        {
            mwvm.Content = gameSessionViewModel;
        }
    }
}
