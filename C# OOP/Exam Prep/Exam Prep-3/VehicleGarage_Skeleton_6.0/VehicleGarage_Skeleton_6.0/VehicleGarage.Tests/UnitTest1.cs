using NUnit.Framework;
using System.Linq;

namespace VehicleGarage.Tests
{
    [TestFixture]
    public class GarageTests
    {
        [Test]
        public void AddVehicle_WithAvailableCapacity_ShouldAddVehicle()
        {
            // Arrange
            var garage = new Garage(2);
            var vehicle = new Vehicle("Toyota", "Camry", "ABC123");

            // Act
            bool result = garage.AddVehicle(vehicle);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, garage.Vehicles.Count);
            Assert.AreEqual(vehicle, garage.Vehicles.First());
        }

        [Test]
        public void AddVehicle_WithFullCapacity_ShouldNotAddVehicle()
        {
            // Arrange
            var garage = new Garage(1);
            var vehicle1 = new Vehicle("Toyota", "Camry", "ABC123");
            var vehicle2 = new Vehicle("Honda", "Accord", "XYZ789");
            garage.AddVehicle(vehicle1);

            // Act
            bool result = garage.AddVehicle(vehicle2);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(1, garage.Vehicles.Count);
            Assert.AreEqual(vehicle1, garage.Vehicles.First());
        }

        [Test]
        public void AddVehicle_WithDuplicateLicensePlate_ShouldNotAddVehicle()
        {
            // Arrange
            var garage = new Garage(2);
            var vehicle1 = new Vehicle("Toyota", "Camry", "ABC123");
            var vehicle2 = new Vehicle("Honda", "Accord", "ABC123");
            garage.AddVehicle(vehicle1);

            // Act
            bool result = garage.AddVehicle(vehicle2);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(1, garage.Vehicles.Count);
            Assert.AreEqual(vehicle1, garage.Vehicles.First());
        }

        [Test]
        public void ChargeVehicles_ShouldChargeAppropriateVehicles()
        {
            // Arrange
            var garage = new Garage(3);
            var vehicle1 = new Vehicle("Toyota", "Camry", "ABC123") { BatteryLevel = 50 };
            var vehicle2 = new Vehicle("Honda", "Accord", "XYZ789") { BatteryLevel = 80 };
            var vehicle3 = new Vehicle("Ford", "Focus", "DEF456") { BatteryLevel = 90 };
            garage.Vehicles.AddRange(new[] { vehicle1, vehicle2, vehicle3 });

            // Act
            int chargedVehicles = garage.ChargeVehicles(75);

            // Assert
            Assert.AreEqual(1, chargedVehicles);
            Assert.AreEqual(100, vehicle1.BatteryLevel);
            Assert.AreEqual(80, vehicle2.BatteryLevel);
            Assert.AreEqual(90, vehicle3.BatteryLevel);
        }

        [Test]
        public void DriveVehicle_ValidParameters_ShouldUpdateBatteryLevelAndDamage()
        {
            // Arrange
            var garage = new Garage(1);
            var vehicle = new Vehicle("Toyota", "Camry", "ABC123") { BatteryLevel = 80 };
            garage.AddVehicle(vehicle);

            // Act
            garage.DriveVehicle("ABC123", 20, false);

            // Assert
            Assert.AreEqual(60, vehicle.BatteryLevel);
            Assert.IsFalse(vehicle.IsDamaged);
        }

        [Test]
        public void DriveVehicle_WithAccident_ShouldSetVehicleAsDamaged()
        {
            // Arrange
            var garage = new Garage(1);
            var vehicle = new Vehicle("Toyota", "Camry", "ABC123") { BatteryLevel = 80 };
            garage.AddVehicle(vehicle);

            // Act
            garage.DriveVehicle("ABC123", 20, true);

            // Assert
            Assert.IsTrue(vehicle.IsDamaged);
        }

        [Test]
        public void DriveVehicle_WithInvalidParameters_ShouldNotUpdateBatteryLevelAndDamage()
        {
            // Arrange
            var garage = new Garage(1);
            var vehicle = new Vehicle("Toyota", "Camry", "ABC123") { BatteryLevel = 80, IsDamaged = false };
            garage.AddVehicle(vehicle);

            // Act
            garage.DriveVehicle("ABC123", 120, false);

            // Assert
            Assert.AreEqual(80, vehicle.BatteryLevel);
            Assert.IsFalse(vehicle.IsDamaged);
        }

        [Test]
        public void RepairVehicles_ShouldRepairDamagedVehicles()
        {
            // Arrange
            var garage = new Garage(2);
            var vehicle1 = new Vehicle("Toyota", "Camry", "ABC123") { IsDamaged = true };
            var vehicle2 = new Vehicle("Honda", "Accord", "XYZ789") { IsDamaged = false };
            garage.Vehicles.AddRange(new[] { vehicle1, vehicle2 });

            // Act
            string result = garage.RepairVehicles();

            // Assert
            Assert.AreEqual("Vehicles repaired: 1", result);
            Assert.IsFalse(vehicle1.IsDamaged);
            Assert.IsFalse(vehicle2.IsDamaged);
        }

        [Test]
        public void Garage_Initialization_ShouldSetCapacityAndInitializeVehiclesList()
        {
            // Arrange
            int capacity = 5;

            // Act
            var garage = new Garage(capacity);

            // Assert
            Assert.AreEqual(capacity, garage.Capacity);
            Assert.IsNotNull(garage.Vehicles);
            Assert.AreEqual(0, garage.Vehicles.Count);
        }
    }
}
