using System;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();

            string[] webSites = Console.ReadLine().Split();

            Smartphone smpartphone = new Smartphone();

            StationaryPhone stationaryPhone = new StationaryPhone();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                string num = phoneNumbers[i];
                if (num.Length == 7)
                {
                    Console.WriteLine(stationaryPhone.Call(num));
                }
                else if (num.Length == 10)
                {
                    Console.WriteLine(smpartphone.Call(num));
                    
                }
            }

            for (int i = 0; i < webSites.Length; i++)
            {
                Console.WriteLine(smpartphone.Browse(webSites[i]));
            }
        }
    }
}
