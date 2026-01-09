using ParkingProject.Models;

namespace ParkingProject.UI;

public class ParkingConsole
{
    private readonly Parking _parking;
    private readonly IReadOnlyDictionary<int, string> _vehicleModels;
    private readonly Random _random = new();

    public ParkingConsole(Parking parking)
    {
        _parking = parking;
        _vehicleModels = new Dictionary<int, string>
        {
            { 1, "Honda Civic" },
            { 2, "Toyota Corolla" },
            { 3, "Volkswagen Golf" },
            { 4, "Ford Focus" },
            { 5, "Chevrolet Cruze" },
            { 6, "Hyundai Elantra" },
            { 7, "Nissan Sentra" },
            { 8, "Kia Cerato" },
            { 9, "Mazda 3" },
            { 10, "Peugeot 308" }
        };
    }

    public void AddVehicle()
    {
        string plate = ReadPlate();
        
        string model = _vehicleModels[_random.Next(1, _vehicleModels.Count+1)];
        if (_parking.AddVehicle(plate, model))
        {
            Console.WriteLine("Vehicle successfully added");
        }
        else
        {
            Console.WriteLine("Vehicle could not be added or already exists");
        }
    }

    public void RemoveVehicle()
    {
        string plate = ReadPlate();
        Console.WriteLine("How many hours the vehicle stayed on the parking?");
        int hours = int.Parse(Console.ReadLine());
        if (_parking.tryRemoveVehicle(plate, hours, out decimal total))
        {
            Console.WriteLine($"Vehicle successfully removed the price is U${total}");
        }
        else
        {
            Console.WriteLine("Vehicle could not be removed");
        }
        
    }

    public void ListVehicles()
    {
        foreach (var vehicle in _parking.GetVehicles())
        {
            Console.WriteLine($"Plate: {vehicle.Key} | Model: {vehicle.Value}");
        }
    }
    
    
    private string ReadPlate()
    {
        string plate;

        do
        {
            Console.WriteLine("Please enter the license plate:");
            plate = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(plate))
                Console.WriteLine("Plate cannot be empty.");

        } while (string.IsNullOrWhiteSpace(plate));

        return plate.ToLower();
    }
    
    
}