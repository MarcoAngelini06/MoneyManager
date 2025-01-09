using Money_Tracker.MVVM.Model;
using Money_Tracker.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

public class MovementViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private ObservableCollection<Movement> _movements;
    public ObservableCollection<Movement> Movements
    {
        get => _movements;
        set
        {
            if (_movements != value)
            {
                _movements = value;
                OnPropertyChanged(nameof(Movements));
            }
        }
    }

    private readonly DatabaseService _databaseService;

    public MovementViewModel()
    {
        _databaseService = new DatabaseService(); // Initialize the service
        Movements = new ObservableCollection<Movement>();
        LoadMovements(); // Fetch data when ViewModel is initialized
    }

    private void LoadMovements()
    {
        var movementsFromDb = _databaseService.GetAllMovements(); // Call the method from DatabaseService

        foreach (var movement in movementsFromDb)
        {
            Movements.Add(movement); // Populate the ObservableCollection
        }
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
