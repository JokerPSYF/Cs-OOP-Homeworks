using System;

namespace _04.SumОfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            long sum = 0;

            string[] input = Console.ReadLine().Split();

            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    int result;
                    if (int.TryParse(input[i], out result))
                    {
                        sum += result;
                    }
                    else
                    {
                        long lomgNum;
                        if (long.TryParse(input[i], out lomgNum))
                        {
                            throw new OverflowException();
                        }
                        else
                        {
                            throw new FormatException();
                        }
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"The element '{input[i]}' is in wrong format!");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine($"The element '{input[i]}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{input[i]}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
