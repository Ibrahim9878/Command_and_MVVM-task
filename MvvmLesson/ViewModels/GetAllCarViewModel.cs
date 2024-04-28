using MvvmLesson.DataBases;
using MvvmLesson.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmLesson.ViewModels;

public class GetAllCarViewModel : INotifyPropertyChanged
{
    private List<Car>? cars;

    public List<Car>? Cars { get => cars; set { cars = value; OnPropertyChanged(); } }

    public GetAllCarViewModel()
    {
        Cars = CarDataBase.CarsDB;
    }



    // ------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    // ------------------------------------------------------
}
