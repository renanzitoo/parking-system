using ParkingProject.Models;
using Xunit;

namespace ParkingProject.Tests;

public class ParkingTests
{
    [Fact]
    public void AddVehicle_ShouldAdd_WhenPlateIsNew()
    {
        var parking = new Parking(10m, 5m);

        bool result = parking.AddVehicle("EX123", "Honda Civic");
        Assert.True(result);
        Assert.Single(parking.GetVehicles());
    }

    [Fact]
    public void AddVehicle_ShouldNotAdd_WhenPlateIsDuplicated()
    {
        var parking = new Parking(10m, 5m);
        
        parking.AddVehicle("EX123", "Honda Civic");
        
        bool result = parking.AddVehicle("EX123", "Toyota Corolla");
        
        Assert.False(result);
        Assert.Single(parking.GetVehicles());
    }

    [Fact]
    public void RemoveVehicle_ShouldRemoveAndCalculate_WhenPlateExists()
    {
        var parking = new Parking(10m, 5m);
        parking.AddVehicle("EX123", "Honda Civic");
        bool removed = parking.tryRemoveVehicle("EX123", 2, out decimal total);
        
        Assert.True(removed);
        Assert.Empty(parking.GetVehicles());
        Assert.Equal(20m, total);
    }

    [Fact]
    public void RemoveVehicle_ShouldNotRemove_WhenPlateDoesNotExist()
    {
        var parking = new Parking(10m, 5m);
        parking.AddVehicle("EX123", "Honda Civic");
        bool removed = parking.tryRemoveVehicle("EX456", 2, out decimal total);
        Assert.False(removed);
    }

    [Fact]
    public void ShouldNotAddVehicle_WhenPlateIsInvalid()
    {
        var parking = new Parking(10m, 5m);
        Assert.Throws<ArgumentException>(() =>
            parking.AddVehicle(null, "Honda Civic")
        );
    }

    [Fact]
    public void ShouldNotRemoveVehicle_WhenPlateIsInvalid()
    {
        var parking = new Parking(10m, 5m);
        Assert.Throws<ArgumentException>(() =>
            parking.tryRemoveVehicle(null, 8, out decimal total)
        );
    }
}
