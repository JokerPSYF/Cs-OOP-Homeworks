using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public double TankCapacity { get; set; }

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;

            if (fuelQuantity <= tankCapacity)
            {
                FuelQuantity = fuelQuantity;
            }
            else
            {
                FuelQuantity = 0;
              //  Console.WriteLine($"Cannot fit {fuelQuantity} fuel in the tank");
            }

        }

        public virtual void Refuel(double gas)
        {
            if (gas <= 0) Console.WriteLine("Fuel must be a positive number");

            else if (gas + FuelQuantity <= TankCapacity) FuelQuantity += gas;

            else Console.WriteLine($"Cannot fit {gas} fuel in the tank");

        }

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