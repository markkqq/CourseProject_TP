//using ЛЮБЛЮ КАСПИЙСКИЙ ГРУС
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Logic;
using Logic.Model;
namespace CourseProject_TP.ViewModel
{
    public class StartViewModel : ViewModelBase
    {
        private MainWindowViewModel mwvm;
        private TournamentViewModel selectedTournament;
        private List<Tournament> _tournaments;
        public StartViewModel(List<Tournament> tournaments, MainWindowViewModel mwvm)
        {
            this.mwvm = mwvm;
            _tournaments = tournaments;
            var tournamentViewModels = from tournament in tournaments select new TournamentViewModel(tournament, this ,mwvm);
            Tournaments = new ObservableCollection<TournamentViewModel>(tournamentViewModels);
        }
        public ObservableCollection<TournamentViewModel> Tournaments { get; set; }

        public ICommand ShowTournament
        {
            get
            {
                return new RelayCommand
                    (
                        (_) => ShowTournamentImplemention(),
                        (_) => CanShowTournament()
                    );
            }
        }
        public TournamentViewModel SelectedTournament
        {
            get => selectedTournament;
            set 
            {
                if (selectedTournament == value) return;
                selectedTournament = value;
                OnPropertyChanged();
            }
        }
        private bool CanShowTournament()
        {
            return selectedTournament != null;
        }
        private void ShowTournamentImplemention()
        {
            Tournament tournament = _tournaments.First(x => x.Name == SelectedTournament.Name);
            mwvm.Content = new TournamentViewModel(tournament, this,mwvm);
        }
    }
}
