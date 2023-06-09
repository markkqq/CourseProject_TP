﻿using System;//using ЛЮБЛЮ МИЯГИ И ЭНДШПИЛЬ
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DataAccess.Repositories;

namespace CourseProject_TP.ViewModel
{
    public class ClubViewModel : ViewModelBase
    {
        Club club;
        private readonly MainWindowViewModel mwvm;
        private PlayerViewModel selectedPlayer;
        private GameSessionViewModel gameSessionViewModel;
        public ClubViewModel(Club club, GameSessionViewModel gameSessionViewModel, MainWindowViewModel mainWindowViewModel)
        {
            this.club = club;
            this.gameSessionViewModel = gameSessionViewModel;
            PlayerRepository playerRepository = new();
            var playerViewModels = from player in club.Players select new PlayerViewModel(player,this,mainWindowViewModel);
            Players = new ObservableCollection<PlayerViewModel>(playerViewModels);
            mwvm = mainWindowViewModel;
        }
        public string Name
        {
            get { return club.Name; }
            set
            {
                if (club.Name == value)
                {
                    return;
                }
                club.Name = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<PlayerViewModel> Players { get; set; }

        public PlayerViewModel SelectedPlayer
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
        public ICommand AddPlayer
        {
            get => new RelayCommand(
                (_) => AddPlayerImplemention()
                );
        }

        private void AddPlayerImplemention()
        {
            mwvm.Content = new AddingPlayerViewModel(club, gameSessionViewModel, mwvm);
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
