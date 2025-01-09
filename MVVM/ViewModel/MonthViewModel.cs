using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Money_Tracker.MVVM.Model;
using Money_Tracker.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

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
        public MonthViewModel()
        {
            _databaseService = new DatabaseService();
            Months = new ObservableCollection<Month>();
            LoadMonths();
        }
        private void LoadMonths()
        {
            var monthsFromDb = _databaseService.GetAllMonths(); // Call the method from DatabaseService

            foreach (var movement in monthsFromDb)
            {
                Months.Add(movement); // Populate the ObservableCollection
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
