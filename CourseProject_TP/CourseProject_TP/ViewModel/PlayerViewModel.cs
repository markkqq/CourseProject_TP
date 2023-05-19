using CourseProject_TP.Model;

namespace CourseProject_TP.ViewModel
{
    public class PlayerViewModel : ViewModelBase
    {
        private Player player;

        public PlayerViewModel(Player player)
        {
            this.player = player;
        }
        public string Name {
            get => player.Name;
            set
            {
                if(player.Name == value) return;
                player.Name = value;
                OnPropertyChanged();
            }
        }
    }
}