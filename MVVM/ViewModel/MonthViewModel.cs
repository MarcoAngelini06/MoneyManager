using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Money_Tracker.MVVM.Model;
using Money_Tracker.MVVM.View;
using Money_Tracker.Services;

namespace Money_Tracker.MVVM.ViewModel
{
    public class MonthViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Month> _months;

        public ObservableCollection<Month> Months
        {
            get => _months;
            set
            {
                if (_months != value)
                {
                    _months = value;
                    OnPropertyChanged(nameof(Months));
                }
            }
        }

        private readonly DatabaseService _databaseService;

        // RelayCommand for navigation
        public RelayCommand<Month> NavigateCommand { get; }

        private readonly MainViewModel _mainViewModel;

        public MonthViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            NavigateCommand = new RelayCommand<Month>(NavigateToMonth);

            _databaseService = new DatabaseService();
            Months = new ObservableCollection<Month>(_databaseService.GetAllMonths());
        }



        private Month _selectedMonth;
        public Month SelectedMonth
        {
            get => _selectedMonth;
            set
            {
                if (_selectedMonth != value)
                {
                    _selectedMonth = value;
                    OnPropertyChanged(nameof(SelectedMonth));

                    // Trigger navigation logic when a new month is selected
                    NavigateToMonth(_selectedMonth);
                }
            }
        }

        // Method to handle navigation
        private void NavigateToMonth(Month selectedMonth)
        {
            if (selectedMonth != null)
            {
                SelectedMonth = selectedMonth;
                _mainViewModel.NavigateToDetailedMonthView(selectedMonth);
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
