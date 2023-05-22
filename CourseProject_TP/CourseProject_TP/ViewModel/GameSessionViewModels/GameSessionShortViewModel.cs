using CourseProject_TP.Model;

namespace CourseProject_TP.ViewModel
{
    public class GameSessionShortViewModel : ViewModelBase
    {
        private GameSession gameSession;

        public GameSessionShortViewModel(GameSession gameSession)
        {
            this.gameSession = gameSession;
        }
        public string Date
        {
            get => $"{gameSession.Date.Year }, {gameSession.Date.Month}";
        }
    }
}