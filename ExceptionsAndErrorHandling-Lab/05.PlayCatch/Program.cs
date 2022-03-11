using System;
using System.Linq;

namespace _05.PlayCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int exceptionsCount = 0;

            while (exceptionsCount < 3)
            {
                try
                {
                    string[] cmd = Console.ReadLine().Split();

                    switch (cmd[0])
                    {
                        case "Replace":
                            int index;
                            int replace;
                            if (int.TryParse(cmd[1], out index) && int.TryParse(cmd[2], out replace))
                            {
                                if (index >= 0 && index < nums.Length)
                                {
                                    nums[index] = replace;
                                }
                                else
                                {
                                    throw new ArgumentException("The index does not exist!");
                                }
                            }
                            else
                            {
                                throw new ArgumentException("The variable is not in the correct format!");
                            }
                            break;

                        case "Print":
                            int startIndex;
                            int endIndex;
                            if (int.TryParse(cmd[1], out startIndex) && int.TryParse(cmd[2], out endIndex))
                            {
                                if (startIndex >= 0 && startIndex < endIndex && endIndex < nums.Length)
                                {
                                    //for (int i = startIndex; i <= endIndex; i++)
                                    //{
                                    //    if(i == endIndex) Console.Write(nums[i]);
                                    //    else Console.Write(nums[i] + ", ");
                                    //}

                                    //Console.WriteLine();

                                    string result = string.Join(", ", nums.Select(x => x.ToString()).ToArray()
                                        , startIndex, (endIndex - startIndex + 1));
                                      Console.WriteLine(result);
                                }
                                else
                                {
                                    throw new ArgumentException("The index does not exist!");
                                }
                            }
                            else
                            {
                                throw new ArgumentException("The variable is not in the correct format!");
                            }
                            break;

                        case "Show":
                            int showIndex;
                            if (int.TryParse(cmd[1], out showIndex))
                            {
                                if (showIndex >= 0 && showIndex < nums.Length)
                                {
                                    Console.WriteLine(nums[showIndex]);
                                }
                                else
                                {
                                    throw new ArgumentException("The index does not exist!");
                                }
                            }
                            else
                            {
                                throw new ArgumentException("The variable is not in the correct format!");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    exceptionsCount++;
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
