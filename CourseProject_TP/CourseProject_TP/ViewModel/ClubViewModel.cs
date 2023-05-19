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
        public ClubViewModel(Club club)
        {
            this.club = club;
            var playerViewModels = from player in club.Players select new PlayerViewModel(player);
            Players = new ObservableCollection<PlayerViewModel>(playerViewModels);
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
                OnPropertyChanged();
                club.Name = value;
            }
        }
        public ObservableCollection<PlayerViewModel> Players { get; set; }
    }
}
