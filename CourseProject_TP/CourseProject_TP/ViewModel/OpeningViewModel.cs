using System;//using ЛЮБЛЮ АК47
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataAccess;
using Logic;
using Logic.Model;
using DataAccess.Repositories;
namespace CourseProject_TP.ViewModel
{
    public class OpeningViewModel : ViewModelBase
    {
        private MainWindowViewModel mainWindowViewModel;
        const int CLUBS_COUNT = 10;
        private readonly int PLAYERS_COUNT = 10;

        public OpeningViewModel(MainWindowViewModel mainWindowViewModel)
        {

            this.mainWindowViewModel = mainWindowViewModel;
        }

        public ICommand Load
        {
            get => new RelayCommand(
                async(_) => await LoadImplemention()
                );
        }
        public async Task LoadImplemention()
        {
            await Task.Run(() =>
            {
                TournamentRepository tournamentRepository = new();
                mainWindowViewModel.Content = new StartViewModel(tournamentRepository.GetAll(),mainWindowViewModel);
            }
            );
        }
    }
}
