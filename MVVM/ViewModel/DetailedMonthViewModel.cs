using Money_Tracker.MVVM.Model;
using System.ComponentModel;

namespace Money_Tracker.MVVM.ViewModel
{
    public class DetailedMonthViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Month _month;
        public Month Month
        {
            get => _month;
            set
            {
                if (_month != value)
                {
                    _month = value;
                    OnPropertyChanged(nameof(Month));
                }
            }
        }

        public DetailedMonthViewModel(Month month)
        {
            Month = month;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
