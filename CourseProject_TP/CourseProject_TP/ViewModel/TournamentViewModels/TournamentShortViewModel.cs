using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject_TP.Model;
namespace CourseProject_TP.ViewModel.TournamentViewModels
{
    public class TournamentShortViewModel : ViewModelBase
    {
        private Tournament _tournament;
        public TournamentShortViewModel(Tournament tournament, MainWindowViewModel mwvm)
        {
            this._tournament = tournament;

        }
        public string Name
        {
            get { return _tournament.Name; }
            set
            {
                if (_tournament.Name == value)
                {
                    return;
                }
                _tournament.Name = value;
                OnPropertyChanged();
            }
        }
    }
}
