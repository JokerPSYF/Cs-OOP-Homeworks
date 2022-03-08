using System;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine().Split();
            string[] truckInput = Console.ReadLine().Split();
            string[] busInput = Console.ReadLine().Split();

            Car car = new Car(double.Parse(carInput[1]),
                double.Parse(carInput[2]),
                double.Parse(carInput[3]));

            Truck truck = new Truck(double.Parse(truckInput[1]),
                double.Parse(truckInput[2]),
                double.Parse(truckInput[3]));

            Bus bus = new Bus(double.Parse(busInput[1]),
                double.Parse(busInput[2]),
                double.Parse(busInput[3]));

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] cmd = Console.ReadLine().Split();

                if (cmd[0] == "Drive")
                {
                    if (cmd[1] == "Car") car.Drive(double.Parse(cmd[2]));

                    else if (cmd[1] == "Bus") bus.Drive(double.Parse(cmd[2]));

                    else truck.Drive(double.Parse(cmd[2]));
                }
                else if (cmd[0] == "DriveEmpty") bus.DriveEmpty(double.Parse(cmd[2]));

                else
                {
                    if (cmd[1] == "Car") car.Refuel(double.Parse(cmd[2]));
                    
                    else if(cmd[1] == "Bus") bus.Refuel(double.Parse(cmd[2]));

                    else truck.Refuel(double.Parse(cmd[2]));
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
