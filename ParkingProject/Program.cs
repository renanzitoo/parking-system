using ParkingProject.Models;
using ParkingProject.UI;

decimal initialPrice = ReadDecimal("Initial price:");
decimal pricePerHour = ReadDecimal("Price per hour:");

var parking = new Parking(initialPrice, pricePerHour);
var ui = new ParkingConsole(parking);

bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("1 - Add vehicle");
    Console.WriteLine("2 - Remove vehicle");
    Console.WriteLine("3 - List vehicles");
    Console.WriteLine("4 - Exit");

    switch (Console.ReadLine())
    {
        case "1": ui.AddVehicle(); break;
        case "2": ui.RemoveVehicle(); break;
        case "3": ui.ListVehicles(); break;
        case "4": running = false; break;
        default: Console.WriteLine("Invalid option"); break;
    }
    
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

static decimal ReadDecimal(string message)
{
    decimal value;
    do
    {
        Console.Write(message + " ");
    } while (!decimal.TryParse(Console.ReadLine(), out value));

    return value;
}