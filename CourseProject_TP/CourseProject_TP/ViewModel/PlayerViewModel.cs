using CourseProject_TP.Model;

namespace CourseProject_TP.ViewModel
{
    public class PlayerViewModel
    {
        private Player player;

        public PlayerViewModel(Player player)
        {
            this.player = player;
        }
        public string Name
        {
            get => player.Name;
        }
    }
}