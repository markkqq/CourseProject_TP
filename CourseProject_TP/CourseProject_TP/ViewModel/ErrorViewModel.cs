using System;
using System.Windows.Input;

namespace CourseProject_TP.ViewModel
{
    internal class ErrorViewModel : ViewModelBase
    {
        private ViewModelBase viewModel;
        private MainWindowViewModel mwvm;
        public ErrorViewModel(ViewModelBase viewModel, MainWindowViewModel mainWindowViewModel)
        {
            this.viewModel = viewModel;
            mwvm = mainWindowViewModel;
        }
        public ICommand ReturnToPreviousPage
        {
            get => new RelayCommand(
                (_) => ReturnImplemention()
                );
        }

        private void ReturnImplemention()
        {
            mwvm.Content = viewModel;
        }
    }
}