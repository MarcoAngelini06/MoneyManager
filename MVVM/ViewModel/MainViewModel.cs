using Money_Tracker.MVVM.View;
using System.ComponentModel;
using System.Windows.Input;

namespace Money_Tracker.MVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object _currentView;

        public event PropertyChangedEventHandler PropertyChanged;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    OnPropertyChanged(nameof(CurrentView));
                }
            }
        }

        public ICommand NavigateCommand { get; }

        public MainViewModel()
        {
            NavigateCommand = new RelayCommand<string>(Navigate);

            // Set the default view
            CurrentView = new HomeView();
        }

        private void Navigate(string viewName)
        {
            switch (viewName)
            {
                case "MoneyTable":
                    var homeView = new HomeView
                    {
                        DataContext = new MovementViewModel() // Use the existing MovementViewModel
                    };
                    CurrentView = new HomeView();
                    break;
                case "InvestmentManager":
                    CurrentView = new HomeView();
                    break;
                case "Future":
                    CurrentView = new HomeView();
                    break;
                case "Charts":
                    CurrentView = new HomeView();
                    break;
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
