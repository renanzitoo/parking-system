namespace ParkingProject.Models;

public class Parking
{
    private readonly decimal _initialPrice;
    private readonly decimal _pricePerHour;
    private readonly Dictionary<string,string> _vehicles = new Dictionary<string,string>();

    public Parking(decimal initialPrice, decimal pricePerHour)
    {
        _initialPrice = initialPrice;
        _pricePerHour = pricePerHour;
    }

    public bool AddVehicle(string licensePlate, string model)
    {
        if (string.IsNullOrEmpty(licensePlate))
        {
            throw new ArgumentException("Plate cannot be empty");
        }
        licensePlate = licensePlate.ToLower();

        if (_vehicles.ContainsKey(licensePlate))
        {
            return false;
        }
        _vehicles.Add(licensePlate, model);
        return true;
    }

    public bool tryRemoveVehicle(string licensePlate, int hours, out decimal total)
    {
        if (string.IsNullOrEmpty(licensePlate))
        {
            throw new ArgumentException("Plate cannot be empty");
        }
        
        total = 0;
        licensePlate = licensePlate.ToLower();
        

        if (!_vehicles.ContainsKey(licensePlate))
        {
            return false;
        }

        total = _initialPrice + (_pricePerHour * hours);
        _vehicles.Remove(licensePlate);
        return true;
    }

    public IReadOnlyDictionary<string, string> GetVehicles()
    {
        return _vehicles;
    }
    
}