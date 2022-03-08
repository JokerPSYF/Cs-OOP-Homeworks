namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + 1.4, tankCapacity)
        {
        }

        public void DriveEmpty(double km)
        {
            FuelConsumption -= 1.4;
            base.Drive(km);
            FuelConsumption += 1.4;
        }

    }
}