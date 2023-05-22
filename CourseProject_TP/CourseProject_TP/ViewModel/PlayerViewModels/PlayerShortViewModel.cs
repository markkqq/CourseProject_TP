using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject_TP.Model;
namespace CourseProject_TP.ViewModel.PlayerViewModels
{
    public class PlayerShortViewModel : ViewModelBase
    {
        private Player player;

        public PlayerShortViewModel(Player player)
        {
            this.player = player;
        }
        public string PersonDetails
        {
            get
            {
                return $"{player.Name} {player.Surname}";
            }
        }
    }
}
