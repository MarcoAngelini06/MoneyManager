using Money_Tracker.MVVM.Model;
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
            NavigateCommand = new RelayCommand<string>(Navigate); //navigateCommand is expecting a string and is going to
                                                                  //pass that parameter to the Navigate method
            var homeView = new HomeView
            {
                DataContext = new MonthViewModel(this) // Pass the current MainViewModel instance
            };
            CurrentView = homeView;
        }

        private void Navigate(string viewName)
        {
            switch (viewName)
            {
                case "MoneyTable":
                    var homeView = new HomeView
                    {
                        DataContext = new MonthViewModel(this) // Pass the current MainViewModel instance
                    };
                    CurrentView = homeView;
                    break;
                case "InvestmentManager":
                    var View = new DetailedMonthView
                    {
                        DataContext = new MonthViewModel(this) // Pass the current MainViewModel instance
                    };
                    CurrentView = View; 
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

        public void NavigateToDetailedMonthView(Month selectedMonth)
        {
            var detailedMonthView = new DetailedMonthView
            {
                DataContext = new DetailedMonthViewModel(selectedMonth)
            };
            CurrentView = detailedMonthView;
        }


    }
}
