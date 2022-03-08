using System;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + 1.6, tankCapacity)
        {
        }

        public override void Refuel(double gas)
        {
            if (gas <= 0) Console.WriteLine("Fuel must be a positive number");

            else if (gas + FuelQuantity <= TankCapacity) FuelQuantity += gas * 0.95;

            else Console.WriteLine($"Cannot fit {gas} fuel in the tank");
        }
    }
}