using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject_TP.Model;
using System.Collections.ObjectModel;
namespace CourseProject_TP.ViewModel
{
    public class ClubViewModel : ViewModelBase
    {
        Club club;
        private readonly MainWindowViewModel mwvm;
        public ClubViewModel(Club club, MainWindowViewModel mainWindowViewModel)
        {
            this.club = club;
            var playerViewModels = from player in club.Players select new PlayerViewModel(player);
            Players = new ObservableCollection<PlayerViewModel>(playerViewModels);
            mwvm = mainWindowViewModel;
        }
        public string Name
        {
            get { return club.Name; }
            set
            {
                if(club.Name == value)
                {
                    return;
                }
                club.Name = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<PlayerViewModel> Players { get; set; }
    }
}
