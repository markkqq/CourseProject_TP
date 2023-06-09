using Logic.Model;  
using System.Windows.Input;

namespace CourseProject_TP.ViewModel
{
    public class PlayerViewModel : ViewModelBase
    {
        private Player player;
        ClubViewModel clubViewModel;
        MainWindowViewModel mwvm;
        public PlayerViewModel(Player player, ClubViewModel clubViewModel,MainWindowViewModel mwvm)
        {
            this.player = player;
            this.clubViewModel = clubViewModel;
            this.mwvm = mwvm;
        }
        public string PersonDetails 
        {
            get
            {
                return $"{player.Name} {player.Surname}";
            }
            set
            {
                if(player.Name == value) return;
                player.Name = value;
                OnPropertyChanged();
            }
        }
        public string Club
        {
            get
            {
                return player.Club.Name;
            }
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
            mwvm.Content = clubViewModel;
        }
    }
}