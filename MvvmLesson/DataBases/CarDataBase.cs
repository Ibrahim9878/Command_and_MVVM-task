using Microsoft.Win32;
using MvvmLesson.Models;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace MvvmLesson.DataBases;

public static class CarDataBase
{
    public static List<Car>? CarsDB { get; set; } = new List<Car>();
    static CarDataBase()
    {
        CarsDB = new List<Car>
        {
            new Car("Model S", "Tesla", new DateTime(2021, 1, 1), 5),
            new Car("Model 3", "Tesla", new DateTime(2021, 1, 1), 5),
            new Car("Model X", "Tesla", new DateTime(2021, 1, 1), 7),
            new Car("Model Y", "Tesla", new DateTime(2021, 1, 1), 7),
            new Car("Roadster", "Tesla", new DateTime(2021, 1, 1), 2),
            new Car("Cybertruck", "Tesla", new DateTime(2021, 1, 1), 6),
            new Car("Semi", "Tesla", new DateTime(2021, 1, 1), 2),
        };
    }
    public static void WriteToFile()
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        if (saveFileDialog.ShowDialog() == true)
        {
            JsonSerializerOptions op = new JsonSerializerOptions() { WriteIndented = true };
            string json = JsonSerializer.Serialize(CarsDB, op);
            File.WriteAllText(saveFileDialog.FileName, json);
        }
    }
    public static void ReadFromFile()
    {
        SaveFileDialog saveDialog = new();
        JsonSerializerOptions op = new JsonSerializerOptions() { WriteIndented = true };
        if (saveDialog.ShowDialog() == true)
        {
            CarsDB = JsonSerializer.Deserialize<List<Car>>(File.ReadAllText(saveDialog.FileName), op);
        }
    }
}
