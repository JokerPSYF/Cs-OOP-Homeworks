using System;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine().Split();
            string[] truckInput = Console.ReadLine().Split();

            Car car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]));
            Truck truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]));

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] cmd = Console.ReadLine().Split();

                if (cmd[0] == "Drive")
                {
                    if (cmd[1] == "Car")
                    {
                        car.Drive(double.Parse(cmd[2]));
                    }
                    else
                    {
                        truck.Drive(double.Parse(cmd[2]));
                    }
                }
                else
                {
                    if (cmd[1] == "Car")
                    {
                        car.Refuel(double.Parse(cmd[2]));
                    }
                    else
                    {
                        truck.Refuel(double.Parse(cmd[2]));
                    }
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}
