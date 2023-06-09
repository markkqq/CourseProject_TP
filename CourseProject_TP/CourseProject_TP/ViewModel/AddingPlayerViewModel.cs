using DataAccess.Repositories;
using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseProject_TP.ViewModel
{
    public class AddingPlayerViewModel : ViewModelBase
    {
        GameSessionViewModel _gameSessionViewModel;
        MainWindowViewModel _mainWindowViewModel;
        Player player = new("","");
        Club _club;
        public AddingPlayerViewModel(Club club, GameSessionViewModel gameSessionViewModel, MainWindowViewModel mainWindowViewModel)
        {
            _club = club;
            _gameSessionViewModel = gameSessionViewModel;
            _mainWindowViewModel = mainWindowViewModel;
        }
        public ICommand AddPlayer
        {
            get => new RelayCommand(
                (_) => AddPlayerImplemention()
                );
        }
        public string Name
        {
            get => player.Name;
            set
            {
                if (player.Name == value) return;
                player.Name = value;
            }
        }
        public string Surname
        {
            get => player.Surname;
            set
            {
                if (player.Surname == value) return;
                player.Surname = value;
            }
        }
        private void AddPlayerImplemention()
        {
            if(ContainsCorrentSymbols(Name) && ContainsCorrentSymbols(Surname))
            {
                Player playerToSave = new(Name, Surname);
                _club.AddPlayer(playerToSave);
                PlayerRepository playerRepository = new();
                
                playerRepository.Save(playerToSave);
                _mainWindowViewModel.Content = new ClubViewModel(_club,_gameSessionViewModel,_mainWindowViewModel);
            }
            else
            {
                _mainWindowViewModel.Content = new ErrorViewModel(this,_mainWindowViewModel);
            }
        }
        private bool ContainsCorrentSymbols(string item)
        {
            bool isInfoCorrect = true;
            for(int i = 0; i < item.Length; i++)
            {
                char c = item[i];
                if (char.IsWhiteSpace(c) || char.IsDigit(c) || char.IsNumber(c))
                {
                    isInfoCorrect = false;
                }
            }
            return isInfoCorrect;
        }
    }
}
