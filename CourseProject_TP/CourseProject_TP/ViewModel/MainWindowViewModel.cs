using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject_TP.Logic.Model;
using CourseProject_TP.Repositories;
using Microsoft.EntityFrameworkCore;
using CourseProject_TP.DataAccess.AppContext;
using CourseProject_TP.DataAccess.Entities;
namespace CourseProject_TP.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        const int TOURNAMENTS_COUNT = 5;
        public MainWindowViewModel()
        {
            TournamentRepository tournamentRepository = new();
            content = new StartViewModel(tournamentRepository.GetTournaments(TOURNAMENTS_COUNT), this);
            
        }
        private ViewModelBase content;
        public ViewModelBase Content
        {
            get => content;
            set
            {
                if(content==value)
                {
                    return;
                }
                content = value;
                OnPropertyChanged();
            }
        }
    }
}
