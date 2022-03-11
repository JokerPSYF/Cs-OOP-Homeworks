using System;
using System.Linq;

namespace _06.MoneyTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            string[] array = {"lazy", "dog", "jumps", "Over",
                "the", "Lazy", "fox" };

            Console.WriteLine(string.Join(", ", nums.Select(x => x.ToString()).ToArray(), 3, 5));
            Console.WriteLine(string.Join(", ", array, 1, 3));

            var result = string.Join(", ", nums.Select(x => x.ToString()).ToArray());
            Console.WriteLine(result);
        }
    }
}
