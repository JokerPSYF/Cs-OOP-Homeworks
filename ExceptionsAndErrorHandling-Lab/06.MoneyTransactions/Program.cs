using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.MoneyTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> balances = new Dictionary<int, double>();

            string[] firstInput = Console.ReadLine()
                .Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < firstInput.Length; i += 2)
            {
                balances.Add(int.Parse(firstInput[i]), double.Parse(firstInput[i + 1]));
            }

            string[] cmd = Console.ReadLine().Split();

            while (cmd[0] != "End")
            {
                string command = cmd[0];
                int balance = int.Parse(cmd[1]);
                double sum = double.Parse(cmd[2]);
                try
                {
                    switch (command)
                    {
                        case "Deposit":
                            if (balances.ContainsKey(balance)) balances[balance] += sum;
                            else throw new ArgumentException("Invalid account!");
                            break;

                        case "Withdraw":
                            if (balances.ContainsKey(balance))
                            {
                                if (sum <= balances[balance])
                                {
                                    balances[balance] -= sum;
                                }
                                else
                                {
                                    throw new ArgumentException("Insufficient balance!");
                                }
                            }
                            else throw new ArgumentException("Invalid account!");
                            break;

                        default: throw new ArgumentException("Invalid command!");
                    }

                    Console.WriteLine($"Account {balance} has new balance: {balances[balance]:f2}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

                cmd = Console.ReadLine().Split();
            }
        }
    }
}
