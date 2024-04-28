using MvvmLesson.Commands;
using MvvmLesson.DataBases;
using MvvmLesson.Models;
using MvvmLesson.Views;
using System.CodeDom;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace MvvmLesson.ViewModels;

public class EnterViewModel : INotifyPropertyChanged
{
    private Car? newCar;
    public Car? NewCar { get => newCar; set { newCar = value;  OnPropertyChanged(); } }

    public ICommand AddCommand { get; set; }
    public ICommand GetAllCarCommand { get; set; }
    public ICommand SaveCommand { get; set; }
    public ICommand LoadCommand { get; set; }
    //tamamla
    public ICommand EditCommand { get; set; } 

    public EnterViewModel()
    {
        NewCar = new Car();
        AddCommand = new RelayCommand(AddCar, IsAddCarEnabled);
        GetAllCarCommand = new RelayCommand(GetAllCars);
        SaveCommand = new RelayCommand(SaveCars);
        LoadCommand = new RelayCommand(LoadCars);
        EditCommand = new RelayCommand(EditCars);
    }

    private void GetAllCars(object? obj)
    {
        GetAllCarView view = new GetAllCarView();
        view.DataContext = new GetAllCarViewModel();

        view.ShowDialog();
    }

    public bool IsAddCarEnabled(object? parameter)
    {
        return NewCar?.Model?.Length >= 3 && NewCar?.Make?.Length >= 3 && NewCar?.Year != null && NewCar?.Passengers != null;
    }
    public void AddCar(object? parameter)
    {
        CarDataBase.CarsDB?.Add(NewCar!);
        //MessageBox.Show(CarDataBase.CarsDB.Count.ToString());
        NewCar = new Car();
    }
    public void SaveCars(object? parameter)
    {
        CarDataBase.WriteToFile();
    }
    public void LoadCars(object? parameter)
    {
        CarDataBase.ReadFromFile();
    }
    public void EditCars(object? parameter)
    {
        EditCarView view = new EditCarView();
        view.DataContext = new EditCarView();
        view.ShowDialog();
    }

    // -----------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName]string? propertyName=null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    // -----------------------------------------------------------
}
