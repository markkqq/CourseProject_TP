using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject_TP.Model;
namespace CourseProject_TP.ViewModel.ClubViewModels
{
    public class ClubShortViewModel : ViewModelBase
    {
        Club club;
        
        public ClubShortViewModel(Club club)
        {
            this.club = club;
        }
        public string Name
        {
            get { return club.Name; }
            set
            {
                if (club.Name == value)
                {
                    return;
                }
                club.Name = value;
                OnPropertyChanged();
            }
        }
    }
}
