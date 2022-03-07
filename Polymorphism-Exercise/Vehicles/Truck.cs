namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption + 1.6)
        {
        }

        public override void Refuel(double gas)
        {
            base.Refuel(gas * 0.95);
        }
    }
}