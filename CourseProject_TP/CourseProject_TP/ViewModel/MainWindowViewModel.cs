using System.Collections.Generic;
using System.Linq;
using Logic.Model;
using DataAccess;
namespace CourseProject_TP.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {

            Content = new OpeningViewModel(this);
        }
        private ViewModelBase content;
        public ViewModelBase Content
        {
            get => content;
            set
            {
                if (content == value)
                {
                    return;
                }
                content = value;
                OnPropertyChanged();
            }
        }
    }
}
