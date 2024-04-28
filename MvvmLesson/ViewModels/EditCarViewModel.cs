using MvvmLesson.Commands;
using MvvmLesson.DataBases;
using MvvmLesson.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MvvmLesson.ViewModels;

public class EditCarViewModel:INotifyPropertyChanged
{
    private Car? newCar;
    public Car? NewCar { get => newCar; set { newCar = value; OnPropertyChanged(); } }

    private List<Car>? cars;

    public List<Car>? Cars { get => cars; set { cars = value; OnPropertyChanged(); } }

    public ICommand EditCommand { get; set; }
    public EditCarViewModel()
    {
        Cars = CarDataBase.CarsDB;
        EditCommand = new RelayCommand();
    }

    public void EditCar(object? parametr)
    {
        
    }

    // ------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    // ------------------------------------------------------
}
