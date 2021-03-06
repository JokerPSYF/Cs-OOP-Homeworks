using System;

namespace _01.SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }
                else
                {
                    Console.WriteLine(Math.Sqrt(num));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }

        }
    }
}
