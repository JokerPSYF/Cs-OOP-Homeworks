using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public virtual void Refuel(double gas) => FuelQuantity += gas;

        private bool CanDrive(double km) => FuelQuantity >= km * FuelConsumption;

        public void Drive(double km)
        {
            if (CanDrive(km))
            {
                FuelQuantity -= km * FuelConsumption;
                Console.WriteLine($"{GetType().Name} travelled {km} km");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }

        public override string ToString() => $"{GetType().Name}: {FuelQuantity:f2}";
    }
}