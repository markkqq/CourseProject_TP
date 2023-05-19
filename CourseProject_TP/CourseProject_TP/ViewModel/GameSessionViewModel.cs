using CourseProject_TP.Model;

namespace CourseProject_TP.ViewModel
{
    public class GameSessionViewModel : ViewModelBase
    {
        private GameSession gameSession;

        public GameSessionViewModel(GameSession gameSession)
        {
            this.gameSession = gameSession;
        }
        public string Winner 
        {
            get => gameSession.Winner.Name;
            set
            {
                if (gameSession.Winner.Name == value) return;

                gameSession.Winner.Name = value;
                OnPropertyChanged();
            }
        }

    }
}