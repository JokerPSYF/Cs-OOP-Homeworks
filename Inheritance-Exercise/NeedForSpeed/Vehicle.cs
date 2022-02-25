namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;

            Fuel = fuel;

        }

        public double DefaultFuelConsumption => 1.25;

        private double fuelConsumption;

        public virtual double FuelConsumption => DefaultFuelConsumption;

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers) => Fuel -= FuelConsumption * kilometers;
        
    }
}