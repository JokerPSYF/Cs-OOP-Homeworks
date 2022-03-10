using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.EnterNumbers
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                ReadNumber(1, 100);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ReadNumber(int start, int end)
        {
            Stack<int> numbers = new Stack<int>();

            while (numbers.Count < 10)
            {
                int num;
                try
                {
                    bool success = int.TryParse(Console.ReadLine(), out num);

                    if (success)
                    {
                        int currentNumber = start;

                        if (numbers.Any())
                        {
                            currentNumber = numbers.Peek();
                        }

                        if (num > currentNumber && num < end)
                        {
                            numbers.Push(num);
                        }
                        else
                        {
                            throw new ArgumentException($"Your number is not in range {currentNumber} - 100!");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Invalid Number!");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(", ", numbers.Reverse()));
        }
    }
}
